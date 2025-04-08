using Crushy.Models;
using Crushy.Services;
using Crushy.WebSocket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Crushy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly MessageService _messageService;
        private readonly SignalRService _signalRService;

        public ChatController(MessageService messageService, SignalRService signalRService)
        {
            _messageService = messageService;
            _signalRService = signalRService;
        }

        // Kullanıcının konuşmalarını getir
        [HttpGet("conversations")]
        public async Task<IActionResult> GetConversations()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var conversations = await _messageService.GetUserConversationsAsync(userId);
            return Ok(conversations);
        }

        // İki kullanıcı arasındaki mesajları getir
        [HttpGet("messages/{receiverId}")]
        public async Task<IActionResult> GetMessagesBetweenUsers(int receiverId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var messages = await _messageService.GetMessagesBetweenUsersAsync(userId, receiverId);
            return Ok(messages);
        }

        // Mesaj gönder (HTTP ile, SignalR'ye alternatif olarak)
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            try
            {
                var senderId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var message = await _messageService.SendMessageAsync(senderId, request.ReceiverId, request.Content);

                // SignalR ile alıcıya bildirim gönder
                await _signalRService.NotifyNewMessageAsync(request.ReceiverId, new
                {
                    message.Id,
                    message.SenderId,
                    message.ReceiverId,
                    message.Content,
                    message.SentAt
                });

                return Ok(message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Mesaj silme
        [HttpDelete("delete/{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                await _messageService.DeleteMessageAsync(messageId, userId);
                return Ok(new { success = true, message = "Mesaj silindi." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Okunmamış mesaj sayısı
        [HttpGet("unread")]
        public async Task<IActionResult> GetUnreadMessageCount()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var count = await _messageService.GetUnreadMessageCountAsync(userId);
            return Ok(new { count });
        }
    }

    public class SendMessageRequest
    {
        public int ReceiverId { get; set; }
        public string Content { get; set; }
    }
} 