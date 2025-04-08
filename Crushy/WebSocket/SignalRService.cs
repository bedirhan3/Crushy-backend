using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Crushy.WebSocket
{
    public class SignalRService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public SignalRService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // Belirli bir kullanıcıya mesaj gönderme
        public async Task SendMessageToUserAsync(int userId, string methodName, object message)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync(methodName, message);
        }

        // Tüm kullanıcılara mesaj gönderme
        public async Task SendMessageToAllAsync(string methodName, object message)
        {
            await _hubContext.Clients.All.SendAsync(methodName, message);
        }

        // Bildirim gönderme
        public async Task SendNotificationAsync(int userId, string message)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("ReceiveNotification", message);
        }

        // Yeni mesaj bildirimi
        public async Task NotifyNewMessageAsync(int userId, object messageData)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("NewMessage", messageData);
        }

        // Kullanıcı durum değişikliği bildirimi
        public async Task NotifyUserStatusChangeAsync(int userId, bool isOnline)
        {
            await _hubContext.Clients.All.SendAsync("UserStatusChanged", new { UserId = userId, IsOnline = isOnline });
        }

        // Hata mesajı gönderme
        public async Task SendErrorAsync(int userId, string errorMessage)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("ErrorNotification", errorMessage);
        }
    }
} 