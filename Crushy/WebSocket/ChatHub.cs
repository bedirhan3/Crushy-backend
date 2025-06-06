using Microsoft.AspNetCore.SignalR;
using Crushy.Models;
using Crushy.Services;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Crushy.WebSocket
{
    public class ChatHub : Hub
    {
        private readonly MessageService _messageService;
        private readonly BlockedUserService _blockedUserService;
        private readonly MatchingService _matchingService;

        private static readonly ConcurrentDictionary<int, string> _userConnectionMap =
            new ConcurrentDictionary<int, string>();

        public ChatHub(MessageService messageService, BlockedUserService blockedUserService,
            MatchingService matchingService)
        {
            _messageService = messageService;
            _blockedUserService = blockedUserService;
            _matchingService = matchingService;
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

                if (!_userConnectionMap.ContainsKey(receiverId))
                {
                    // var fcmToken = await _messageService.GetFcmTokenAsync(receiverId); 
                    const string fcmToken =
                        "eEIR7_49DU0cs6gZbu8w90:APA91bEnl8k5JLe7WlzO0ii-uSiv8YftG5K6EiFGBhTdDe-nMww1kWRuwNujB0Eg02K5txFK5b7taFFAWxEkvGMX3Jvof3IthDrNzGT9h2lmtZHUkkgH7Iw";
                    if (!string.IsNullOrWhiteSpace(fcmToken))
                    {
                        var firebaseService = new FirebaseNotificationService();
                        await firebaseService.SendPushNotificationAsync(fcmToken, title: messageDto.Receiver?.Username,
                            message: messageDto.Content);
                    }
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
    }
}