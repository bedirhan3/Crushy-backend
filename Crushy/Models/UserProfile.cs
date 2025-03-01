using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crushy.Models
{
	public class UserProfile
	{
		[Key, ForeignKey("User")]
		public int UserId { get; set; } // Primary Key ve Foreign Key

		public string Fullname { get; set; }
		public bool? Gender { get; set; }
		public string? Map { get; set; }
		public string? ImageUrl { get; set; }
		public int Coin { get; set; }

		// Navigation Property
		public User User { get; set; }



	}
}
