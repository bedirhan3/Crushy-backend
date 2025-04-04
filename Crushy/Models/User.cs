using Crushy.Abstract;
using System.Text.RegularExpressions;

namespace Crushy.Models
{
	public class User: BaseEntity
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public string? RefreshToken { get; set; } 
		public DateTime? RefreshTokenExpiryTime { get; set; } // Token geçerlilik süresi

		public UserProfile Profile { get; set; }
		public ICollection<BlockedUser> BlockedUsers { get; set; }

		//Mesajlar
		public ICollection<Message> SentMessages { get; set; }
		public ICollection<Message> ReceivedMessages { get; set; }

		// Eşleşmeler
		public ICollection<MatchedUser> MatchesAsUser1 { get; set; }
		public ICollection<MatchedUser> MatchesAsUser2 { get; set; }

		//Abonelikler
		public List<UserSubscription> Subscriptions { get; set; } = new();

	}
}
