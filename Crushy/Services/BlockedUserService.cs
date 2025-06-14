using Crushy.Data;
using Crushy.Dtos;
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

        public async Task<List<BlockedUserDTO>> GetBlockedUsersAsync(int userId)
        {
            return await _context.BlockedUsers
                .Where(b => b.UserId == userId && !b.IsDeleted)
                .Include(b => b.Blocked)
                .ThenInclude(u => u.Profile)
                .Select(b => new BlockedUserDTO
                {
                    UserId = b.Blocked.Id,
                    FullName = b.Blocked.Profile != null ? b.Blocked.Profile.Fullname : "", 
                    ImageUrl = b.Blocked.Profile != null ? b.Blocked.Profile.ImageUrl : ""
                })
                .ToListAsync();
        }

        public async Task<BlockedUser> BlockUserAsync(int userId, int blockedUserId)
        {
            var existingBlock = await _context.BlockedUsers
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BlockedUserId == blockedUserId && !b.IsDeleted);

            if (existingBlock != null)
            {
                throw new InvalidOperationException("Bu kullanıcı zaten engellenmiş.");
            }

            var blockedUser = new BlockedUser
            {
                UserId = userId,
                BlockedUserId = blockedUserId,
                BlockedAt = DateTime.Now
            };

            await _context.BlockedUsers.AddAsync(blockedUser);
            await _context.SaveChangesAsync();

            return blockedUser;
        }

        public async Task UnblockUserAsync(int userId, int blockedUserId)
        {
            var blockedUser = await _context.BlockedUsers
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BlockedUserId == blockedUserId && !b.IsDeleted);

            if (blockedUser == null)
            {
                throw new InvalidOperationException("Böyle bir engelleme bulunamadı.");
            }

            blockedUser.UpdatedAt = DateTime.Now;
            blockedUser.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUserBlockedAsync(int userId, int blockedUserId)
        {
            return await _context.BlockedUsers
                .AnyAsync(b => b.UserId == userId && b.BlockedUserId == blockedUserId && !b.IsDeleted);
        }

        public async Task<bool> IsBlockedByUserAsync(int userId, int otherUserId)
        {
            return await _context.BlockedUsers
                .AnyAsync(b => b.UserId == otherUserId && b.BlockedUserId == userId && !b.IsDeleted);
        }
    }
}