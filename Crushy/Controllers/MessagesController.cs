using Crushy.Models;
using Crushy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Crushy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
        }

        // Mesaj gönderme
        [HttpPost("send/{receiverId}")]
        public async Task<IActionResult> SendMessage(int receiverId, [FromBody] string content)
        {
            var senderId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            try
            {
                var message = await _messageService.SendMessageAsync(senderId, receiverId, content);
                return Ok(message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // İki kullanıcı arasındaki mesajları getirme
        [HttpGet("conversation/{otherUserId}")]
        public async Task<IActionResult> GetConversation(int otherUserId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var messages = await _messageService.GetMessagesBetweenUsersAsync(userId, otherUserId);

            var resultMessages = messages.Select(m => new
            {
                SenderFullname = m.Sender.Profile?.Fullname ?? null,
                SenderImageUrl = m.Sender.Profile?.ImageUrl ?? "default_image_url.png", 
                SenderUsername = m.Sender.Username,
                ReceiverFullname = m.Receiver.Profile?.Fullname ?? null,
                ReceiverImageUrl = m.Receiver.Profile?.ImageUrl ?? "default_image_url.png", 
                m.Content,
                m.SentAt
            }).ToList();

            return Ok(resultMessages);
        }

        // Kullanıcının tüm mesajlaşmalarını getirme
        [HttpGet("conversations")]
        public async Task<IActionResult> GetConversations()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var conversations = await _messageService.GetUserConversationsAsync(userId);

			var resultMessages = conversations.Select(m => new
			{
				SenderFullname = m.Sender.Profile?.Fullname ?? null,
				SenderImageUrl = m.Sender.Profile?.ImageUrl ?? "default_image_url.png",
				SenderUsername = m.Sender.Username,
				ReceiverFullname = m.Receiver.Profile?.Fullname ?? null,
				ReceiverImageUrl = m.Receiver.Profile?.ImageUrl ?? "default_image_url.png",
				m.Content,
				m.SentAt
			}).ToList();
			return Ok(resultMessages);
        }

        // Mesaj silme
        [HttpDelete("{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            try
            {
                await _messageService.DeleteMessageAsync(messageId, userId);
                return Ok(new { message = "Mesaj başarıyla silindi." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Okunmamış mesaj sayısını getirme
        [HttpGet("unread-count")]
        public async Task<IActionResult> GetUnreadMessageCount()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var count = await _messageService.GetUnreadMessageCountAsync(userId);
            return Ok(new { count });
        }
    }
} 