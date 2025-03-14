using Crushy.Data;
using Crushy.Models;
using Microsoft.EntityFrameworkCore;

namespace Crushy.Services
{
    public class BlockedUserService
    {
        private readonly ApplicationDbContext _context;

        public BlockedUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlockedUser>> GetBlockedUsersAsync(int userId)
        {
            return await _context.BlockedUsers
                .Include(b => b.Blocked)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<BlockedUser> BlockUserAsync(int userId, int blockedUserId)
        {
            var existingBlock = await _context.BlockedUsers
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BlockedUserId == blockedUserId);

            if (existingBlock != null)
            {
                throw new InvalidOperationException("Bu kullanıcı zaten engellenmiş.");
            }

            var blockedUser = new BlockedUser
            {
                UserId = userId,
                BlockedUserId = blockedUserId,
                BlockedAt = DateTime.UtcNow
            };

            await _context.BlockedUsers.AddAsync(blockedUser);
            await _context.SaveChangesAsync();

            return blockedUser;
        }

        public async Task UnblockUserAsync(int userId, int blockedUserId)
        {
            var blockedUser = await _context.BlockedUsers
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BlockedUserId == blockedUserId);

            if (blockedUser == null)
            {
                throw new InvalidOperationException("Böyle bir engelleme bulunamadı.");
            }

            blockedUser.UpdatedAt= DateTime.Now;
            blockedUser.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUserBlockedAsync(int userId, int blockedUserId)
        {
            return await _context.BlockedUsers
                .AnyAsync(b => b.UserId == userId && b.BlockedUserId == blockedUserId);
        }
    }
} 