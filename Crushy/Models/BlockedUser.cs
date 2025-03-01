using Crushy.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crushy.Models
{
	public class BlockedUser : BaseEntity
	{
		public int Id { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; } // Engelleyen kişi

		[ForeignKey("Blocked")]
		public int BlockedUserId { get; set; } // Engellenen kişi

		public DateTime BlockedAt { get; set; } // Engelleme tarihi

		public User User { get; set; } // Engelleyen
		public User Blocked { get; set; } // Engellenen
	}
}
