namespace Crushy.Models
{
	public class UserSubscription
	{
		public int Id { get; set; }
		public int UserId { get; set; } // Hangi kullanıcı?
		public int PlanId { get; set; } // Hangi plan?

		public DateTime StartDate { get; set; } = DateTime.Now; // Başlangıç tarihi
		public DateTime EndDate { get; set; } // Bitiş tarihi
		public string Status { get; set; } = "active"; // "active", "expired", "canceled"

		// Navigation Properties
		public User User { get; set; } = null!;
		public SubscriptionPlan Plan { get; set; } = null!;
	}
}
