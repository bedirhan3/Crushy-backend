using Crushy.Data;
using Crushy.Models;
using Microsoft.EntityFrameworkCore;

namespace Crushy.Services
{
    public class MessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly BlockedUserService _blockedUserService;

        public MessageService(ApplicationDbContext context, BlockedUserService blockedUserService)
        {
            _context = context;
            _blockedUserService = blockedUserService;
        }

        public async Task<Message> SendMessageAsync(int senderId, int receiverId, string content)
        {
            // Engellenme kontrolü
            var isBlocked = await _blockedUserService.IsUserBlockedAsync(receiverId, senderId);
            if (isBlocked)
            {
                throw new InvalidOperationException("Bu kullanıcı tarafından engellendiniz.");
            }

            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                SentAt = DateTime.Now
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            // Mesajı, sender ve receiver ilişkileriyle beraber tekrar yükle
            var savedMessage = await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .FirstOrDefaultAsync(m => m.Id == message.Id);

            return savedMessage!;
        }

        // İki kullanıcı arasındaki mesajları getirme
        public async Task<List<Message>> GetMessagesBetweenUsersAsync(int userId1, int userId2)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                    .ThenInclude(s => s.Profile)
                .Include(m => m.Receiver)
                    .ThenInclude(r => r.Profile)
                .Where(m => 
                    (m.SenderId == userId1 && m.ReceiverId == userId2) || 
                    (m.SenderId == userId2 && m.ReceiverId == userId1))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        // Kullanıcının tüm mesajlaşmalarını getirme
        public async Task<List<Message>> GetUserConversationsAsync(int userId)
        {
            var messages = await _context.Messages
				.Include(m => m.Sender)
					.ThenInclude(s => s.Profile)
				.Include(m => m.Receiver)
					.ThenInclude(r => r.Profile)
				.Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();

            // Her konuşmadan son mesajı al
            var conversations = messages
                .GroupBy(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
                .Select(g => g.First())
                .ToList();

            return conversations;
        }

        // Mesajı silme soft delete
        public async Task DeleteMessageAsync(int messageId, int userId)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == messageId && 
                    (m.SenderId == userId || m.ReceiverId == userId));

            if (message == null)
            {
                throw new InvalidOperationException("Mesaj bulunamadı.");
            }

            message.IsDeleted = true;
            message.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        // Okunmamış mesaj sayısını getirme
        public async Task<int> GetUnreadMessageCountAsync(int userId)
        {
            return await _context.Messages
                .CountAsync(m => m.ReceiverId == userId && !m.IsDeleted);
        }
        
        // daha önce mesajlaşma var mı kontrol
        public async Task<bool> HasPreviousMessagesAsync(int userId1, int userId2)
        {
            return await _context.Messages.AnyAsync(m =>
                (m.SenderId == userId1 && m.ReceiverId == userId2) ||
                (m.SenderId == userId2 && m.ReceiverId == userId1));
        }
    }
} 