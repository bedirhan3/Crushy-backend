namespace Crushy.Models
{
	public class SubscriptionPlan
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty; // Örn: "Premium", "VIP"
		public decimal Price { get; set; }
		public int DurationInDays { get; set; } // Abonelik süresi (30, 60, 90 gün gibi)
		public string? Features { get; set; }  // JSON olarak özellikler

		// Planı alan kullanıcıların listesi
		public List<UserSubscription> UserSubscriptions { get; set; } = new();
	}
}
