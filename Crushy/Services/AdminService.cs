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
				.Include(u => u.Subscriptions)
					.ThenInclude(s => s.Plan)
				.OrderByDescending(u => u.Id)
				.ToListAsync();
		}

		public async Task<User> GetUserByIdAsync(int userId)
		{
			return await _context.Users
				.Include(u => u.Profile)
				.Include(u => u.Subscriptions)
					.ThenInclude(s => s.Plan)
				.Include(u => u.MatchesAsUser1)
					.ThenInclude(m => m.User2)
						.ThenInclude(u => u.Profile)
				.Include(u => u.MatchesAsUser2)
					.ThenInclude(m => m.User1)
						.ThenInclude(u => u.Profile)
				.Include(u => u.SentMessages)
				.Include(u => u.ReceivedMessages)
				.Include(u => u.BlockedUsers)
					.ThenInclude(b => b.Blocked)
						.ThenInclude(u => u.Profile)
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

			// Soft delete
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
				// Unblock
				_context.BlockedUsers.Remove(existingBlock);
			}
			else
			{
				// Block
				_context.BlockedUsers.Add(new BlockedUser
				{
					UserId = blockedById,
					BlockedUserId = userId,
					CreatedAt = DateTime.Now
				});
			}

			await _context.SaveChangesAsync();
			return true;
		}

		// Subscription Management
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
				activeSubscription.EndDate = DateTime.Now;
			}

			var subscription = new UserSubscription
			{
				UserId = userId,
				PlanId = planId,
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddMonths(durationInMonths),
				Status = "active"
			};

			_context.UserSubscriptions.Add(subscription);
			await _context.SaveChangesAsync();
			return true;
		}

		// Match Management
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

		public async Task<object> GetUserDetailedReportAsync(int userId)
		{
			var user = await GetUserByIdAsync(userId);
			if (user == null) return null;

			// Count active subscriptions
			var activeSubscription = user.Subscriptions
				.FirstOrDefault(s => s.Status == "active");

			var totalMatches = user.MatchesAsUser1.Count + user.MatchesAsUser2.Count;

			// Get unique matched users
			var matchedUsersIds = new HashSet<int>();
			foreach (var match in user.MatchesAsUser1)
				matchedUsersIds.Add(match.User2Id);
			foreach (var match in user.MatchesAsUser2)
				matchedUsersIds.Add(match.User1Id);

			var sentMessages = user.SentMessages.Count;
			var receivedMessages = user.ReceivedMessages.Count;
			var totalMessages = sentMessages + receivedMessages;

			var respondedToMessages = 0;
			var uniqueConversations = new HashSet<int>();

			// Count unique senders who received replies
			foreach (var message in user.SentMessages)
			{
				uniqueConversations.Add(message.ReceiverId);
			}

			var uniqueReceivers = new HashSet<int>();
			foreach (var message in user.ReceivedMessages)
			{
				uniqueReceivers.Add(message.SenderId);
				if (uniqueConversations.Contains(message.SenderId))
					respondedToMessages++;
			}

			// Message response rate
			double responseRate = uniqueReceivers.Count > 0 
				? (double)respondedToMessages / uniqueReceivers.Count * 100 
				: 0;

			var daysSinceRegistration = (DateTime.Now - user.CreatedAt).TotalDays;
			
			var messagesPerDay = daysSinceRegistration > 0 
				? Math.Round(totalMessages / daysSinceRegistration, 2) 
				: 0;
			var matchesPerDay = daysSinceRegistration > 0 
				? Math.Round(totalMatches / daysSinceRegistration, 2) 
				: 0;

			var blockedUsers = user.BlockedUsers.Count;

			var engagementScore = CalculateEngagementScore(
				new Dictionary<string, double> {
					{ "messagesSent", sentMessages },
					{ "messagesReceived", receivedMessages },
					{ "matches", totalMatches },
					{ "responseRate", responseRate },
					{ "blockedUsers", blockedUsers },
					{ "daysActive", daysSinceRegistration }
				}
			);

			return new
			{
				UserId = user.Id,
				Username = user.Username,
				FullName = user.Profile.Fullname,
				Role = user.Role,
				RegistrationDate = user.CreatedAt,
				DaysActive = Math.Round(daysSinceRegistration, 0),
				Profile = new
				{
					Email = user.Profile.Email,
					Gender = user.Profile.Gender ? "Male" : "Female",
					Age = user.Profile.Age,
					Coins = user.Profile.Coin,
					ImageUrl = user.Profile.ImageUrl,
					Location = user.Profile.Map
				},
				Subscription = activeSubscription != null ? new
				{
					PlanName = activeSubscription.Plan.Name,
					StartDate = activeSubscription.StartDate,
					EndDate = activeSubscription.EndDate,
					RemainingDays = (activeSubscription.EndDate - DateTime.Now).TotalDays > 0 
						? Math.Round((activeSubscription.EndDate - DateTime.Now).TotalDays, 0) 
						: 0,
					Status = activeSubscription.Status
				} : null,
				MessageStats = new
				{
					TotalSent = sentMessages,
					TotalReceived = receivedMessages,
					Total = totalMessages,
					AveragePerDay = messagesPerDay,
					ResponseRate = Math.Round(responseRate, 0),
					UniqueConversations = uniqueConversations.Count
				},
				MatchStats = new
				{
					TotalMatches = totalMatches,
					UniqueMatchedUsers = matchedUsersIds.Count,
					AveragePerDay = matchesPerDay,
					LatestMatchDate = user.MatchesAsUser1.Count > 0 || user.MatchesAsUser2.Count > 0 
						? user.MatchesAsUser1
							.Union(user.MatchesAsUser2)
							.OrderByDescending(m => m.MatchedAt)
							.FirstOrDefault()?.MatchedAt 
						: null
				},
				BlockedUsers = new
				{
					TotalBlocked = blockedUsers,
					BlockedUsersList = user.BlockedUsers.Select(b => new {
						UserId = b.BlockedUserId,
						Username = b.Blocked.Username,
						FullName = b.Blocked.Profile.Fullname,
						BlockDate = b.CreatedAt
					}).ToList()
				},
				EngagementScore = new
				{
					Overall = Math.Round(engagementScore, 0),
					Category = CategorizeEngagement(engagementScore)
				}
			};
		}

		private double CalculateEngagementScore(Dictionary<string, double> metrics)
		{
			// Simple engagement scoring algorithm
			double score = 0;
			
			// Messages sent (weight: 0.2)
			double messageFactor = Math.Min(metrics["messagesSent"], 100) / 100 * 20;
			
			// Messages received (weight: 0.2)
			double receivedFactor = Math.Min(metrics["messagesReceived"], 100) / 100 * 20;
			
			// Matches (weight: 0.3)
			double matchFactor = Math.Min(metrics["matches"], 50) / 50 * 30;
			
			// Response rate (weight: 0.2)
			double responseFactor = metrics["responseRate"] / 100 * 20;
			
			// Days active (weight: 0.1) - max 365 days
			double activityFactor = Math.Min(metrics["daysActive"], 365) / 365 * 10;
			
			// Negative factor: blocked users
			double blockedPenalty = Math.Min(metrics["blockedUsers"] * 2, 10);
			
			score = messageFactor + receivedFactor + matchFactor + responseFactor + activityFactor - blockedPenalty;
			
			// Ensure the score is within 0-100 range
			return Math.Max(0, Math.Min(100, score));
		}

		private string CategorizeEngagement(double score)
		{
			if (score >= 80) return "Very Active";
			if (score >= 60) return "Active";
			if (score >= 40) return "Moderate";
			if (score >= 20) return "Low";
			return "Inactive";
		}
	}
}
