using System.ComponentModel.DataAnnotations.Schema;

namespace Crushy.Models
{
	public class MatchedUser
	{
		public int Id { get; set; }

		public int User1Id { get; set; }
		public User User1 { get; set; } // Kullanıcı 1

		public int User2Id { get; set; }
		public User User2 { get; set; } // Kullanıcı 2

		public DateTime MatchedAt { get; set; } = DateTime.Now; // Eşleşme tarihi

	}
}
