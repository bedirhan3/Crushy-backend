using Crushy.Data;
using Crushy.Models;

namespace Crushy.UserService
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
			return _context.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
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
			return _context.Users.FirstOrDefault(u => u.Username == username);
		}

		// Kullanıcı ekleme
		public void AddUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}
	}
}
