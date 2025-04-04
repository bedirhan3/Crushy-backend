using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Crushy.Models;
using Crushy.Data;
using Microsoft.EntityFrameworkCore;

namespace Crushy.Services
{
	public class AdminService
	{
		private readonly ApplicationDbContext _context;

		public AdminService(ApplicationDbContext context)
		{
			_context = context;
		}

		// Dashboard Statistics
		public async Task<object> GetDashboardStatsAsync()
		{
			var totalUsers = await _context.Users.CountAsync();
			var blockedUsers = await _context.BlockedUsers.Select(b => b.BlockedUserId).Distinct().CountAsync();
			var activeSubscriptions = await _context.UserSubscriptions.CountAsync(s => s.Status == "active");
			var matchCount = await _context.MatchedUsers.CountAsync();

			return new
			{
				TotalUsers = totalUsers,
				BlockedUsers = blockedUsers,
				ActiveSubscriptions = activeSubscriptions,
				TotalMatches = matchCount
			};
		}

		// User Management
		public async Task<List<User>> GetAllUsersAsync()
		{
			return await _context.Users
				.Include(u => u.Profile)
				.OrderByDescending(u => u.CreatedAt)
				.ToListAsync();
		}

		public async Task<User> GetUserByIdAsync(int userId)
		{
			return await _context.Users
				.Include(u => u.Profile)
				.Include(u => u.Subscriptions)
					.ThenInclude(s => s.Plan)
				.FirstOrDefaultAsync(u => u.Id == userId);
		}

		public async Task<List<User>> GetSubscribedUsersAsync()
		{
			return await _context.Users
				.Include(u => u.Profile)
				.Include(u => u.Subscriptions)
				.Where(u => u.Subscriptions.Any(s => s.Status == "active"))
				.ToListAsync();
		}

		public async Task<List<User>> GetBlockedUsersAsync()
		{
			var blockedUserIds = await _context.BlockedUsers
				.Select(b => b.BlockedUserId)
				.Distinct()
				.ToListAsync();

			return await _context.Users
				.Include(u => u.Profile)
				.Where(u => blockedUserIds.Contains(u.Id))
				.ToListAsync();
		}

		public async Task<bool> DeleteUserAsync(int userId)
		{
			var user = await _context.Users.FindAsync(userId);
			if (user == null) return false;

			user.IsDeleted = true;
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> ToggleBlockUserAsync(int userId, int blockedById)
		{
			var user = await _context.Users.FindAsync(userId);
			var blockingUser = await _context.Users.FindAsync(blockedById);
			
			if (user == null || blockingUser == null) return false;

			var existingBlock = await _context.BlockedUsers
				.FirstOrDefaultAsync(b => b.UserId == blockedById && b.BlockedUserId == userId);

			if (existingBlock != null)
			{
				_context.BlockedUsers.Remove(existingBlock);
			}
			else
			{
				_context.BlockedUsers.Add(new BlockedUser
				{
					UserId = blockedById,
					BlockedUserId = userId,
					CreatedAt = DateTime.UtcNow
				});
			}

			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> UpdateUserSubscriptionAsync(int userId, int planId, int durationInMonths)
		{
			var user = await _context.Users.FindAsync(userId);
			var plan = await _context.SubscriptionPlans.FindAsync(planId);
			
			if (user == null || plan == null) return false;

			var activeSubscription = await _context.UserSubscriptions
				.FirstOrDefaultAsync(s => s.UserId == userId && s.Status == "active");
			
			if (activeSubscription != null)
			{
				activeSubscription.Status = "canceled";
				activeSubscription.EndDate = DateTime.UtcNow;
			}

			var subscription = new UserSubscription
			{
				UserId = userId,
				PlanId = planId,
				StartDate = DateTime.UtcNow,
				EndDate = DateTime.UtcNow.AddMonths(durationInMonths),
				Status = "active"
			};

			_context.UserSubscriptions.Add(subscription);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<List<MatchedUser>> GetAllMatchesAsync()
		{
			return await _context.MatchedUsers
				.Include(m => m.User1)
					.ThenInclude(u => u.Profile)
				.Include(m => m.User2)
					.ThenInclude(u => u.Profile)
				.OrderByDescending(m => m.MatchedAt)
				.ToListAsync();
		}
	}
}
