using Microsoft.AspNetCore.SignalR;
using Crushy.Models;
using Crushy.Services;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Crushy.WebSocket
{
    public class ChatHub : Hub
    {
        private readonly MessageService _messageService;
        private readonly BlockedUserService _blockedUserService;
        private readonly MatchingService _matchingService;
        private readonly FirebaseNotificationService _firebaseNotificationService;
        private readonly UserProfileService _profileService;


        private static readonly ConcurrentDictionary<int, string> _userConnectionMap =
            new ConcurrentDictionary<int, string>();

        public ChatHub(MessageService messageService,
            BlockedUserService blockedUserService,
            MatchingService matchingService,
            FirebaseNotificationService firebaseNotificationService,
            UserProfileService userProfileService)
        {
            _messageService = messageService;
            _blockedUserService = blockedUserService;
            _matchingService = matchingService;
            _firebaseNotificationService = firebaseNotificationService;
            _profileService = userProfileService;
        }

        public async Task RegisterConnection(int userId)
        {
            _userConnectionMap.AddOrUpdate(userId, Context.ConnectionId, (key, oldValue) => Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = _userConnectionMap.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            if (userId != 0)
            {
                _userConnectionMap.TryRemove(userId, out _);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User_{userId}");
                _matchingService.RemoveUserFromPool(userId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task RequestMatchAsync(int userId, int age, double latitude, double longitude)
        {
            var connectionId = Context.ConnectionId;
            if (_userConnectionMap.ContainsKey(userId) && _userConnectionMap[userId] == connectionId)
            {
                await _matchingService.FindMatchForUserAsync(userId, connectionId, age, latitude, longitude);
            }
            else
            {
                await Clients.Caller.SendAsync("MatchRequestError",
                    "Eşleşme talebi için geçerli bir kullanıcı değilsiniz veya bağlantı sorunu var.");
            }
        }

        public async Task GetPoolStatusAsync(int userId)
        {
            var connectionId = Context.ConnectionId;
            if (_userConnectionMap.ContainsKey(userId) && _userConnectionMap[userId] == connectionId)
            {
                await _matchingService.GetPoolStatusAsync(userId);
            }
            else
            {
                await Clients.Caller.SendAsync("MatchRequestError",
                    "Pool durumu için geçerli bir kullanıcı değilsiniz.");
            }
        }

        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            var isBlocked = await _blockedUserService.IsUserBlockedAsync(receiverId, senderId);
            if (isBlocked)
            {
                await Clients.Caller.SendAsync("MessageError", "Bu kullanıcı tarafından engellendiniz.");
                return;
            }

            try
            {
                var isNewUser = !await _messageService.HasPreviousMessagesAsync(senderId, receiverId);

                var savedMessage = await _messageService.SendMessageAsync(senderId, receiverId, message);

                var messageDto = new
                {
                    savedMessage.Id,
                    savedMessage.SenderId,
                    savedMessage.ReceiverId,
                    savedMessage.Content,
                    savedMessage.SentAt,
                    Sender = savedMessage.Sender != null
                        ? new { savedMessage.Sender.Id, savedMessage.Sender.Username }
                        : null,
                    Receiver = savedMessage.Receiver != null
                        ? new { savedMessage.Receiver.Id, savedMessage.Receiver.Username }
                        : null,
                    isNewUser
                };

                await Clients.Group($"User_{senderId}").SendAsync("ReceiveMessage", messageDto);
                await Clients.Group($"User_{receiverId}").SendAsync("ReceiveMessage", messageDto);

                Console.WriteLine("[SignalR] Message sent to both sender and receiver groups.");

                if (!_userConnectionMap.ContainsKey(receiverId))
                {
                    Console.WriteLine($"[SignalR] Receiver {receiverId} is offline. Sending FCM push...");
                    
                    var profile = await _profileService.GetProfileById(receiverId);
                    if (profile == null)
                    {
                        Console.WriteLine("profile yok ");
                        return;
                    }
                    
                    var fcmToken = profile.Map;
                    Console.WriteLine($"fcmtoken === {fcmToken}");

                    if (!string.IsNullOrWhiteSpace(fcmToken))
                    {
                        await _firebaseNotificationService.SendPushNotificationAsync(
                            fcmToken,
                            title: messageDto.Sender?.Username ?? "Yeni mesaj",
                            message: messageDto.Content
                        );
                    }
                    else
                    {
                        Console.WriteLine("[SignalR] FCM token is empty.");
                    }
                }
                else
                {
                    Console.WriteLine($"[SignalR] Receiver {receiverId} is online. No FCM push needed.");
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("MessageError", ex.Message);
            }
        }

        /*
             public async Task<string> GetFcmTokenAsync(int userId)
             {
                 var user = await _dbContext.Users.FindAsync(userId);
                 return user?.FcmToken;
             }
     */
        
        
        public async Task MarkMessageAsRead(long messageId, long senderId)
        {
            await Clients.Group($"User_{senderId}").SendAsync("MessageRead", messageId);
        }

        public async Task MessageDelivered(long messageId, long senderId)
        {
            await Clients.Group($"User_{senderId}").SendAsync("MessageDelivered", messageId);
        }

        public bool IsUserOnline(int userId)
        {
            return _userConnectionMap.ContainsKey(userId);
        }
        
        public async Task Ping (int userId)
        {
            await Clients.Group($"User_{userId}").SendAsync("Pong");
        }
        
    }
}