using Microsoft.AspNetCore.SignalR;
using Crushy.Models;
using Crushy.Services;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Crushy.WebSocket
{
    public class ChatHub : Hub
    {
        private readonly MessageService _messageService;
        private readonly BlockedUserService _blockedUserService;
        private static readonly ConcurrentDictionary<int, string> _userConnectionMap = new ConcurrentDictionary<int, string>();

        public ChatHub(MessageService messageService, BlockedUserService blockedUserService)
        {
            _messageService = messageService;
            _blockedUserService = blockedUserService;
        }

        // Kullanıcı bağlantı kurduğunda çağrılır
        public async Task RegisterConnection(int userId)
        {
            _userConnectionMap.AddOrUpdate(userId, Context.ConnectionId, (key, oldValue) => Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
        }

        // Kullanıcı bağlantı kestiğinde çağrılır
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = _userConnectionMap.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            if (userId != 0)
            {
                _userConnectionMap.TryRemove(userId, out _);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User_{userId}");
            }
            await base.OnDisconnectedAsync(exception);
        }

        // Mesaj gönderme
        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            // Engellenme kontrolü
            var isBlocked = await _blockedUserService.IsUserBlockedAsync(receiverId, senderId);
            if (isBlocked)
            {
                await Clients.Caller.SendAsync("MessageError", "Bu kullanıcı tarafından engellendiniz.");
                return;
            }

            try
            {
                // Mesajı veritabanına kaydet
                var savedMessage = await _messageService.SendMessageAsync(senderId, receiverId, message);
                
                // Mesaj göndereni ve alıcısını içerecek şekilde dönüş mesajını oluştur
                var messageDto = new 
                {
                    savedMessage.Id,
                    savedMessage.SenderId,
                    savedMessage.ReceiverId,
                    savedMessage.Content,
                    savedMessage.SentAt,
                    Sender = savedMessage.Sender != null ? new { savedMessage.Sender.Id, savedMessage.Sender.Username } : null,
                    Receiver = savedMessage.Receiver != null ? new { savedMessage.Receiver.Id, savedMessage.Receiver.Username } : null
                };

                // Mesajı gönderen ve alıcıya bildir
                await Clients.Group($"User_{senderId}").SendAsync("ReceiveMessage", messageDto);
                await Clients.Group($"User_{receiverId}").SendAsync("ReceiveMessage", messageDto);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("MessageError", ex.Message);
            }
        }

        // Okundu bilgisi gönderme
        public async Task MarkMessageAsRead(int messageId, int userId)
        {
            // Burada mesajın okundu olarak işaretlenme işlemi yapılabilir
            // Bu örnekte sadece karşı tarafa bilgi gönderiyoruz
            await Clients.OthersInGroup($"User_{userId}").SendAsync("MessageRead", messageId);
        }

        // Kullanıcının çevrimiçi durumunu kontrol etme
        public bool IsUserOnline(int userId)
        {
            return _userConnectionMap.ContainsKey(userId);
        }
    }
} 