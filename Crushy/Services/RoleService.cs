using Crushy.Data;
using Crushy.Models;

namespace Crushy.Services
{
	public class RoleService
	{
		private readonly ApplicationDbContext _context;

		public RoleService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<User> GetRoleByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}
		
		
		

		
	}
}
