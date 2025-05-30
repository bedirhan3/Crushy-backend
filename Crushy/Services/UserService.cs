using Crushy.Data;
using Crushy.Models;
using Microsoft.EntityFrameworkCore;

namespace Crushy.Services
{
	public class UserService
	{
		private readonly ApplicationDbContext _context;
		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		// Kullanıcıyı Refresh Token ile bulma
		public User GetUserByRefreshToken(string refreshToken)
		{
			return _context.Users
				.Include(u => u.Profile)
				.FirstOrDefault(u => u.RefreshToken == refreshToken);
		}

		// Kullanıcı güncelleme
		public void UpdateUser(User user)
		{
			_context.Users.Update(user);
			_context.SaveChanges();
		}

		// Kullanıcıyı kullanıcı adına göre bulma
		public User GetUserByUsername(string username)
		{
			return _context.Users
				.Include(u => u.Profile)
				.FirstOrDefault(u => u.Username == username);
		}

		// Kullanıcı ve profil ekleme
		public void AddUserWithProfile(User user, UserProfile profile)
		{
			using var transaction = _context.Database.BeginTransaction();
			try
			{
				_context.Users.Add(user);
				_context.SaveChanges(); // Önce User'ı kaydet

				profile.UserId = user.Id; // User ID'yi profile'a ata
				_context.UserProfiles.Add(profile);
				_context.SaveChanges(); // Sonra Profile'ı kaydet

				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		// Kullanıcı profili güncelleme
		public void UpdateUserProfile(UserProfile profile)
		{
			_context.UserProfiles.Update(profile);
			_context.SaveChanges();
		}

		// ID'ye göre kullanıcı profili getirme
		public UserProfile GetUserProfileById(int userId)
		{
			return _context.UserProfiles.FirstOrDefault(p => p.UserId == userId);
		}

		// ID'ye göre kullanıcı getirme
		public User GetUserById(int userId)
		{
			return _context.Users
				.Include(u => u.Profile)
				.FirstOrDefault(u => u.Id == userId);
		}

		// Tüm kullanıcıları listeleme
		public List<User> GetAllUsersWithProfiles()
		{
			return _context.Users
				.Include(u => u.Profile)
				.ToList();
		}
		
		public object? GetBasicInfoByUserId(int userId)
		{
			var profile = _context.UserProfiles.FirstOrDefault(p => p.UserId == userId);
			if (profile == null) return null;

			return new
			{
				FullName = profile.Fullname,
				Age = profile.Age,
				ProfileImageUrl = profile.ImageUrl
			};
		}


	}
}
