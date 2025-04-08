using Crushy.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Crushy.Data
{

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<BlockedUser> BlockedUsers { get; set; }
		public DbSet<MatchedUser> MatchedUsers { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
		public DbSet<UserSubscription> UserSubscriptions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Subscription Plans
			modelBuilder.Entity<SubscriptionPlan>().HasData(
				new SubscriptionPlan { Id = 1, Name = "Premium", Price = 29.99m, Features = "Premium üyelik paketi" },
				new SubscriptionPlan { Id = 2, Name = "EVO", Price = 49.99m, Features = "EVO üyelik paketi" },
				new SubscriptionPlan { Id = 3, Name = "Basic", Price = 9.99m, Features = "Temel üyelik paketi" }
			);

			// Users and Profiles
			modelBuilder.Entity<User>().HasData(
				new User { 
					Id = 1, 
					Username = "admin", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "Admin",
					CreatedAt = new DateTime(2024, 1, 1),
					IsDeleted = false
				},
				new User { 
					Id = 2, 
					Username = "emma.wilson", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 1, 15),
					IsDeleted = false
				},
				new User { 
					Id = 3, 
					Username = "james.smith", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 1, 20),
					IsDeleted = false
				},
				new User { 
					Id = 4, 
					Username = "sophia.brown", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 1),
					IsDeleted = false
				},
				new User { 
					Id = 5, 
					Username = "oliver.taylor", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 5),
					IsDeleted = false
				},
				new User { 
					Id = 6, 
					Username = "ava.johnson", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 10),
					IsDeleted = false
				},
				new User { 
					Id = 7, 
					Username = "noah.williams", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 15),
					IsDeleted = false
				},
				new User { 
					Id = 8, 
					Username = "mia.davis", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 20),
					IsDeleted = false
				},
				new User { 
					Id = 9, 
					Username = "liam.garcia", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 25),
					IsDeleted = false
				},
				new User { 
					Id = 10, 
					Username = "emily.miller", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 3, 1),
					IsDeleted = false
				},
				new User { 
					Id = 11, 
					Username = "ethan.anderson", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "User",
					CreatedAt = new DateTime(2024, 3, 5),
					IsDeleted = false
				},
				new User { 
					Id = 12, 
					Username = "amelia.thomas", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "User",
					CreatedAt = new DateTime(2024, 3, 10),
					IsDeleted = false
				},
				new User { 
					Id = 13, 
					Username = "ahmet.yilmaz", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 5),
					IsDeleted = false
				},
				new User { 
					Id = 14, 
					Username = "ayse.demir", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 8),
					IsDeleted = false
				},
				new User { 
					Id = 15, 
					Username = "mehmet.kaya", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 12),
					IsDeleted = false
				},
				new User { 
					Id = 16, 
					Username = "zeynep.celik", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 18),
					IsDeleted = false
				},
				new User { 
					Id = 17, 
					Username = "mustafa.sahin", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 22),
					IsDeleted = false
				},
				new User { 
					Id = 18, 
					Username = "elif.yildiz", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 2, 25),
					IsDeleted = false
				},
				new User { 
					Id = 19, 
					Username = "emre.ozturk", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 3, 1),
					IsDeleted = false
				},
				new User { 
					Id = 20, 
					Username = "selin.aksoy", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 3, 5),
					IsDeleted = false
				},
				new User { 
					Id = 21, 
					Username = "burak.korkmaz", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 3, 9),
					IsDeleted = false
				},
				new User { 
					Id = 22, 
					Username = "ece.aydin", 
					Password = BCrypt.Net.BCrypt.HashPassword("string"), 
					Role = "VerifiedUser",
					CreatedAt = new DateTime(2024, 3, 12),
					IsDeleted = false
				}
			);

			modelBuilder.Entity<UserProfile>().HasData(
				new UserProfile { 
					UserId = 1, 
					Fullname = "Admin User",
					Email = "admin@crushy.com",
					Gender = true,
					Age = 35,
					Coin = 1000,
					ImageUrl = "https://randomuser.me/api/portraits/men/1.jpg",
					Map = "40.7128,-74.0060"
				},
				new UserProfile { 
					UserId = 2, 
					Fullname = "Emma Wilson",
					Email = "emma@example.com",
					Gender = false,
					Age = 28,
					Coin = 50,
					ImageUrl = "https://randomuser.me/api/portraits/women/2.jpg",
					Map = "51.5074,-0.1278"
				},
				new UserProfile { 
					UserId = 3, 
					Fullname = "James Smith",
					Email = "james@example.com",
					Gender = true,
					Age = 32,
					Coin = 75,
					ImageUrl = "https://randomuser.me/api/portraits/men/3.jpg",
					Map = "48.8566,2.3522"
				},
				new UserProfile { 
					UserId = 4, 
					Fullname = "Sophia Brown",
					Email = "sophia@example.com",
					Gender = false,
					Age = 25,
					Coin = 30,
					ImageUrl = "https://randomuser.me/api/portraits/women/4.jpg",
					Map = "52.5200,13.4050"
				},
				new UserProfile { 
					UserId = 5, 
					Fullname = "Oliver Taylor",
					Email = "oliver@example.com",
					Gender = true,
					Age = 30,
					Coin = 45,
					ImageUrl = "https://randomuser.me/api/portraits/men/5.jpg",
					Map = "41.9028,12.4964"
				},
				new UserProfile { 
					UserId = 6, 
					Fullname = "Ava Johnson",
					Email = "ava@example.com",
					Gender = false,
					Age = 24,
					Coin = 60,
					ImageUrl = "https://randomuser.me/api/portraits/women/6.jpg",
					Map = "34.0522,-118.2437"
				},
				new UserProfile { 
					UserId = 7, 
					Fullname = "Noah Williams",
					Email = "noah@example.com",
					Gender = true,
					Age = 29,
					Coin = 55,
					ImageUrl = "https://randomuser.me/api/portraits/men/7.jpg",
					Map = "35.6762,139.6503"
				},
				new UserProfile { 
					UserId = 8, 
					Fullname = "Mia Davis",
					Email = "mia@example.com",
					Gender = false,
					Age = 27,
					Coin = 40,
					ImageUrl = "https://randomuser.me/api/portraits/women/8.jpg",
					Map = "19.4326,-99.1332"
				},
				new UserProfile { 
					UserId = 9, 
					Fullname = "Liam Garcia",
					Email = "liam@example.com",
					Gender = true,
					Age = 31,
					Coin = 65,
					ImageUrl = "https://randomuser.me/api/portraits/men/9.jpg",
					Map = "-33.8688,151.2093"
				},
				new UserProfile { 
					UserId = 10, 
					Fullname = "Emily Miller",
					Email = "emily@example.com",
					Gender = false,
					Age = 23,
					Coin = 35,
					ImageUrl = "https://randomuser.me/api/portraits/women/10.jpg",
					Map = "55.7558,37.6173"
				},
				new UserProfile { 
					UserId = 11, 
					Fullname = "Ethan Anderson",
					Email = "ethan@example.com",
					Gender = true,
					Age = 34,
					Coin = 25,
					ImageUrl = "https://randomuser.me/api/portraits/men/11.jpg",
					Map = "37.7749,-122.4194"
				},
				new UserProfile { 
					UserId = 12, 
					Fullname = "Amelia Thomas",
					Email = "amelia@example.com",
					Gender = false,
					Age = 26,
					Coin = 20,
					ImageUrl = "https://randomuser.me/api/portraits/women/12.jpg",
					Map = "43.6532,-79.3832"
				},
				new UserProfile { 
					UserId = 13, 
					Fullname = "Ahmet Yılmaz",
					Email = "ahmet@example.com",
					Gender = true,
					Age = 29,
					Coin = 55,
					ImageUrl = "https://randomuser.me/api/portraits/men/22.jpg",
					Map = "41.0082,28.9784" 
				},
				new UserProfile { 
					UserId = 14, 
					Fullname = "Ayşe Demir",
					Email = "ayse@example.com",
					Gender = false,
					Age = 25,
					Coin = 45,
					ImageUrl = "https://randomuser.me/api/portraits/women/23.jpg",
					Map = "41.0082,28.9784" 
				},
				new UserProfile { 
					UserId = 15, 
					Fullname = "Mehmet Kaya",
					Email = "mehmet@example.com",
					Gender = true,
					Age = 33,
					Coin = 60,
					ImageUrl = "https://randomuser.me/api/portraits/men/24.jpg",
					Map = "39.9208,32.8541"
				},
				new UserProfile { 
					UserId = 16, 
					Fullname = "Zeynep Çelik",
					Email = "zeynep@example.com",
					Gender = false,
					Age = 27,
					Coin = 50,
					ImageUrl = "https://randomuser.me/api/portraits/women/25.jpg",
					Map = "39.9208,32.8541" 
				},
				new UserProfile { 
					UserId = 17, 
					Fullname = "Mustafa Şahin",
					Email = "mustafa@example.com",
					Gender = true,
					Age = 31,
					Coin = 70,
					ImageUrl = "https://randomuser.me/api/portraits/men/26.jpg",
					Map = "38.4237,27.1428" 
				},
				new UserProfile { 
					UserId = 18, 
					Fullname = "Elif Yıldız",
					Email = "elif@example.com",
					Gender = false,
					Age = 24,
					Coin = 40,
					ImageUrl = "https://randomuser.me/api/portraits/women/27.jpg",
					Map = "38.4237,27.1428" 
				},
				new UserProfile { 
					UserId = 19, 
					Fullname = "Emre Öztürk",
					Email = "emre@example.com",
					Gender = true,
					Age = 28,
					Coin = 65,
					ImageUrl = "https://randomuser.me/api/portraits/men/28.jpg",
					Map = "37.0000,35.3213" 
				},
				new UserProfile { 
					UserId = 20, 
					Fullname = "Selin Aksoy",
					Email = "selin@example.com",
					Gender = false,
					Age = 26,
					Coin = 55,
					ImageUrl = "https://randomuser.me/api/portraits/women/29.jpg",
					Map = "36.8841,30.7056" 
				},
				new UserProfile { 
					UserId = 21, 
					Fullname = "Burak Korkmaz",
					Email = "burak@example.com",
					Gender = true,
					Age = 32,
					Coin = 75,
					ImageUrl = "https://randomuser.me/api/portraits/men/30.jpg",
					Map = "40.1885,29.0610" 
				},
				new UserProfile { 
					UserId = 22, 
					Fullname = "Ece Aydın",
					Email = "ece@example.com",
					Gender = false,
					Age = 23,
					Coin = 35,
					ImageUrl = "https://randomuser.me/api/portraits/women/31.jpg",
					Map = "41.2867,36.3300" 
				}
			);

			// User Subscriptions
			modelBuilder.Entity<UserSubscription>().HasData(
				new UserSubscription {
					Id = 1,
					UserId = 2,
					PlanId = 1,
					StartDate = DateTime.UtcNow.AddDays(-30),
					EndDate = DateTime.UtcNow.AddDays(60),
					Status = "active"
				},
				new UserSubscription {
					Id = 2,
					UserId = 3,
					PlanId = 2,
					StartDate = DateTime.UtcNow.AddDays(-15),
					EndDate = DateTime.UtcNow.AddDays(75),
					Status = "active"
				},
				new UserSubscription {
					Id = 3,
					UserId = 6,
					PlanId = 1,
					StartDate = DateTime.UtcNow.AddDays(-45),
					EndDate = DateTime.UtcNow.AddDays(45),
					Status = "active"
				},
				new UserSubscription {
					Id = 4,
					UserId = 7,
					PlanId = 2,
					StartDate = DateTime.UtcNow.AddDays(-60),
					EndDate = DateTime.UtcNow.AddDays(30),
					Status = "active"
				},
				new UserSubscription {
					Id = 5,
					UserId = 9,
					PlanId = 1,
					StartDate = DateTime.UtcNow.AddDays(-90),
					EndDate = DateTime.UtcNow.AddDays(-30),
					Status = "expired"
				},
				new UserSubscription {
					Id = 6,
					UserId = 10,
					PlanId = 3,
					StartDate = DateTime.UtcNow.AddDays(-10),
					EndDate = DateTime.UtcNow.AddDays(20),
					Status = "active"
				},
				new UserSubscription {
					Id = 7,
					UserId = 13,
					PlanId = 1,
					StartDate = DateTime.UtcNow.AddDays(-20),
					EndDate = DateTime.UtcNow.AddDays(40),
					Status = "active"
				},
				new UserSubscription {
					Id = 8,
					UserId = 15,
					PlanId = 2,
					StartDate = DateTime.UtcNow.AddDays(-30),
					EndDate = DateTime.UtcNow.AddDays(60),
					Status = "active"
				},
				new UserSubscription {
					Id = 9,
					UserId = 17,
					PlanId = 1,
					StartDate = DateTime.UtcNow.AddDays(-15),
					EndDate = DateTime.UtcNow.AddDays(45),
					Status = "active"
				},
				new UserSubscription {
					Id = 10,
					UserId = 19,
					PlanId = 3,
					StartDate = DateTime.UtcNow.AddDays(-5),
					EndDate = DateTime.UtcNow.AddDays(25),
					Status = "active"
				},
				new UserSubscription {
					Id = 11,
					UserId = 21,
					PlanId = 2,
					StartDate = DateTime.UtcNow.AddDays(-25),
					EndDate = DateTime.UtcNow.AddDays(35),
					Status = "active"
				}
			);

			// Matches
			modelBuilder.Entity<MatchedUser>().HasData(
				new MatchedUser {
					Id = 1,
					User1Id = 2,
					User2Id = 3,
					MatchedAt = DateTime.UtcNow.AddDays(-10)
				},
				new MatchedUser {
					Id = 2,
					User1Id = 4,
					User2Id = 5,
					MatchedAt = DateTime.UtcNow.AddDays(-5)
				},
				new MatchedUser {
					Id = 3,
					User1Id = 6,
					User2Id = 7,
					MatchedAt = DateTime.UtcNow.AddDays(-15)
				},
				new MatchedUser {
					Id = 4,
					User1Id = 8,
					User2Id = 9,
					MatchedAt = DateTime.UtcNow.AddDays(-8)
				},
				new MatchedUser {
					Id = 5,
					User1Id = 10,
					User2Id = 11,
					MatchedAt = DateTime.UtcNow.AddDays(-3)
				},
				new MatchedUser {
					Id = 6,
					User1Id = 2,
					User2Id = 7,
					MatchedAt = DateTime.UtcNow.AddDays(-12)
				},
				new MatchedUser {
					Id = 7,
					User1Id = 3,
					User2Id = 8,
					MatchedAt = DateTime.UtcNow.AddDays(-7)
				},
				new MatchedUser {
					Id = 8,
					User1Id = 13,
					User2Id = 14,
					MatchedAt = DateTime.UtcNow.AddDays(-18)
				},
				new MatchedUser {
					Id = 9,
					User1Id = 15,
					User2Id = 16,
					MatchedAt = DateTime.UtcNow.AddDays(-16)
				},
				new MatchedUser {
					Id = 10,
					User1Id = 17,
					User2Id = 18,
					MatchedAt = DateTime.UtcNow.AddDays(-14)
				},
				new MatchedUser {
					Id = 11,
					User1Id = 19,
					User2Id = 20,
					MatchedAt = DateTime.UtcNow.AddDays(-12)
				},
				new MatchedUser {
					Id = 12,
					User1Id = 21,
					User2Id = 22,
					MatchedAt = DateTime.UtcNow.AddDays(-10)
				},
				new MatchedUser {
					Id = 13,
					User1Id = 13,
					User2Id = 16,
					MatchedAt = DateTime.UtcNow.AddDays(-9)
				},
				new MatchedUser {
					Id = 14,
					User1Id = 15,
					User2Id = 18,
					MatchedAt = DateTime.UtcNow.AddDays(-8)
				},
				new MatchedUser {
					Id = 15,
					User1Id = 17,
					User2Id = 20,
					MatchedAt = DateTime.UtcNow.AddDays(-7)
				},
				new MatchedUser {
					Id = 16,
					User1Id = 19,
					User2Id = 22,
					MatchedAt = DateTime.UtcNow.AddDays(-6)
				},
				new MatchedUser {
					Id = 17,
					User1Id = 14,
					User2Id = 21,
					MatchedAt = DateTime.UtcNow.AddDays(-5)
				},
				new MatchedUser {
					Id = 18,
					User1Id = 13,
					User2Id = 2,
					MatchedAt = DateTime.UtcNow.AddDays(-17)
				},
				new MatchedUser {
					Id = 19,
					User1Id = 14,
					User2Id = 3,
					MatchedAt = DateTime.UtcNow.AddDays(-15)
				},
				new MatchedUser {
					Id = 20,
					User1Id = 15,
					User2Id = 4,
					MatchedAt = DateTime.UtcNow.AddDays(-13)
				},
				new MatchedUser {
					Id = 21,
					User1Id = 16,
					User2Id = 5,
					MatchedAt = DateTime.UtcNow.AddDays(-11)
				},
				new MatchedUser {
					Id = 22,
					User1Id = 17,
					User2Id = 6,
					MatchedAt = DateTime.UtcNow.AddDays(-9)
				},
				new MatchedUser {
					Id = 23,
					User1Id = 18,
					User2Id = 7,
					MatchedAt = DateTime.UtcNow.AddDays(-7)
				},
				new MatchedUser {
					Id = 24,
					User1Id = 19,
					User2Id = 8,
					MatchedAt = DateTime.UtcNow.AddDays(-5)
				},
				new MatchedUser {
					Id = 25,
					User1Id = 20,
					User2Id = 9,
					MatchedAt = DateTime.UtcNow.AddDays(-3)
				},
				new MatchedUser {
					Id = 26,
					User1Id = 21,
					User2Id = 10,
					MatchedAt = DateTime.UtcNow.AddDays(-2)
				},
				new MatchedUser {
					Id = 27,
					User1Id = 22,
					User2Id = 11,
					MatchedAt = DateTime.UtcNow.AddDays(-1)
				}
			);

			// Messages
			modelBuilder.Entity<Message>().HasData(
				new Message {
					Id = 1,
					SenderId = 2,
					ReceiverId = 3,
					Content = "Merhaba, nasılsın?",
					CreatedAt = DateTime.UtcNow.AddDays(-9),
					IsDeleted = false
				},
				new Message {
					Id = 2,
					SenderId = 3,
					ReceiverId = 2,
					Content = "İyiyim, teşekkürler! Sen nasılsın?",
					CreatedAt = DateTime.UtcNow.AddDays(-9).AddMinutes(5),
					IsDeleted = false
				},
				new Message {
					Id = 3,
					SenderId = 4,
					ReceiverId = 5,
					Content = "Selam! Profilini çok beğendim.",
					CreatedAt = DateTime.UtcNow.AddDays(-4),
					IsDeleted = false
				},
				new Message {
					Id = 4,
					SenderId = 5,
					ReceiverId = 4,
					Content = "Teşekkür ederim, seninkini de beğendim!",
					CreatedAt = DateTime.UtcNow.AddDays(-4).AddMinutes(10),
					IsDeleted = false
				},
				new Message {
					Id = 5,
					SenderId = 6,
					ReceiverId = 7,
					Content = "Merhaba, burada yeni misin?",
					CreatedAt = DateTime.UtcNow.AddDays(-14),
					IsDeleted = false
				},
				new Message {
					Id = 6,
					SenderId = 7,
					ReceiverId = 6,
					Content = "Evet, yeni kayıt oldum. Seni tanımaktan memnun oldum!",
					CreatedAt = DateTime.UtcNow.AddDays(-14).AddMinutes(15),
					IsDeleted = false
				},
				new Message {
					Id = 7,
					SenderId = 8,
					ReceiverId = 9,
					Content = "Selam! Hangi şehirde yaşıyorsun?",
					CreatedAt = DateTime.UtcNow.AddDays(-7),
					IsDeleted = false
				},
				new Message {
					Id = 8,
					SenderId = 9,
					ReceiverId = 8,
					Content = "İstanbul'da yaşıyorum. Sen nerelisin?",
					CreatedAt = DateTime.UtcNow.AddDays(-7).AddMinutes(8),
					IsDeleted = false
				},
				new Message {
					Id = 9,
					SenderId = 10,
					ReceiverId = 11,
					Content = "Merhaba, hobilerin neler?",
					CreatedAt = DateTime.UtcNow.AddDays(-2),
					IsDeleted = false
				},
				new Message {
					Id = 10,
					SenderId = 11,
					ReceiverId = 10,
					Content = "Merhaba! Yüzmeyi, kitap okumayı ve film izlemeyi seviyorum. Sen nelerden hoşlanırsın?",
					CreatedAt = DateTime.UtcNow.AddDays(-2).AddMinutes(20),
					IsDeleted = false
				},
				new Message {
					Id = 11,
					SenderId = 2,
					ReceiverId = 7,
					Content = "Merhaba, seni tanımaktan memnun oldum!",
					CreatedAt = DateTime.UtcNow.AddDays(-11),
					IsDeleted = false
				},
				new Message {
					Id = 12,
					SenderId = 7,
					ReceiverId = 2,
					Content = "Ben de memnun oldum! Nasıl gidiyor?",
					CreatedAt = DateTime.UtcNow.AddDays(-11).AddMinutes(30),
					IsDeleted = false
				},
				new Message {
					Id = 13,
					SenderId = 3,
					ReceiverId = 8,
					Content = "Profilin çok ilgi çekici görünüyor. Nelerden hoşlanırsın?",
					CreatedAt = DateTime.UtcNow.AddDays(-6),
					IsDeleted = false
				},
				new Message {
					Id = 14,
					SenderId = 8,
					ReceiverId = 3,
					Content = "Teşekkürler! Müzik dinlemeyi, yemek yapmayı ve doğada vakit geçirmeyi seviyorum.",
					CreatedAt = DateTime.UtcNow.AddDays(-6).AddMinutes(15),
					IsDeleted = false
				},
				new Message {
					Id = 15,
					SenderId = 4,
					ReceiverId = 5,
					Content = "Bu hafta sonu bir şeyler yapmak ister misin?",
					CreatedAt = DateTime.UtcNow.AddDays(-2),
					IsDeleted = false
				},
				new Message {
					Id = 16,
					SenderId = 13, // Ahmet
					ReceiverId = 14, // Ayşe
					Content = "Merhaba Ayşe, profilini inceledim ve ortak ilgi alanlarımız olduğunu fark ettim.",
					CreatedAt = DateTime.UtcNow.AddDays(-18),
					IsDeleted = false
				},
				new Message {
					Id = 17,
					SenderId = 14, // Ayşe
					ReceiverId = 13, // Ahmet
					Content = "Merhaba Ahmet, teşekkürler. Ben de senin profilini beğendim. Hangi ilgi alanlarından bahsediyorsun?",
					CreatedAt = DateTime.UtcNow.AddDays(-18).AddMinutes(20),
					IsDeleted = false
				},
				new Message {
					Id = 18,
					SenderId = 13, // Ahmet
					ReceiverId = 14, // Ayşe
					Content = "Özellikle sinema ve müzik konusundaki zevklerimiz benziyor gibi. En sevdiğin film nedir?",
					CreatedAt = DateTime.UtcNow.AddDays(-18).AddMinutes(35),
					IsDeleted = false
				},
				new Message {
					Id = 19,
					SenderId = 15, // Mehmet
					ReceiverId = 16, // Zeynep
					Content = "Merhaba Zeynep, Ankara'da yaşadığını gördüm. Hangi semtte oturuyorsun?",
					CreatedAt = DateTime.UtcNow.AddDays(-16),
					IsDeleted = false
				},
				new Message {
					Id = 20,
					SenderId = 16, // Zeynep
					ReceiverId = 15, // Mehmet
					Content = "Merhaba Mehmet, Çankaya'da yaşıyorum. Sen?",
					CreatedAt = DateTime.UtcNow.AddDays(-16).AddHours(1),
					IsDeleted = false
				},
				new Message {
					Id = 21,
					SenderId = 15, // Mehmet
					ReceiverId = 16, // Zeynep
					Content = "Ben de Çankaya'dayım. Bu hafta sonu bir kahve içmek ister misin?",
					CreatedAt = DateTime.UtcNow.AddDays(-15),
					IsDeleted = false
				},
				new Message {
					Id = 22,
					SenderId = 17, // Mustafa
					ReceiverId = 18, // Elif
					Content = "Merhaba Elif, İzmir'de yeni mi yaşıyorsun?",
					CreatedAt = DateTime.UtcNow.AddDays(-14),
					IsDeleted = false
				},
				new Message {
					Id = 23,
					SenderId = 18, // Elif
					ReceiverId = 17, // Mustafa
					Content = "Merhaba Mustafa, hayır yaklaşık 3 yıldır buradayım. Sen?",
					CreatedAt = DateTime.UtcNow.AddDays(-14).AddMinutes(45),
					IsDeleted = false
				},
				new Message {
					Id = 24,
					SenderId = 17, // Mustafa
					ReceiverId = 18, // Elif
					Content = "Ben 5 yıldır İzmir'deyim. En sevdiğin yer neresi şehirde?",
					CreatedAt = DateTime.UtcNow.AddDays(-13),
					IsDeleted = false
				},
				new Message {
					Id = 25,
					SenderId = 19, // Emre
					ReceiverId = 20, // Selin
					Content = "Merhaba Selin, fotoğrafın çok güzel. Nerede çekildi?",
					CreatedAt = DateTime.UtcNow.AddDays(-11),
					IsDeleted = false
				},
				new Message {
					Id = 26,
					SenderId = 20, // Selin
					ReceiverId = 19, // Emre
					Content = "Teşekkürler Emre, fotoğraf Antalya Kaleiçi'nde çekildi. Sen hiç gittin mi?",
					CreatedAt = DateTime.UtcNow.AddDays(-11).AddHours(2),
					IsDeleted = false
				},
				new Message {
					Id = 27,
					SenderId = 21, // Burak
					ReceiverId = 22, // Ece
					Content = "Merhaba Ece, profilinde gördüğüm kadarıyla müzikle ilgileniyorsun. Hangi tür müzikleri seviyorsun?",
					CreatedAt = DateTime.UtcNow.AddDays(-9),
					IsDeleted = false
				},
				new Message {
					Id = 28,
					SenderId = 22, // Ece
					ReceiverId = 21, // Burak
					Content = "Merhaba Burak, evet müzik benim tutkum. Özellikle rock ve alternatif müzik dinlemeyi seviyorum. Sen?",
					CreatedAt = DateTime.UtcNow.AddDays(-9).AddMinutes(40),
					IsDeleted = false
				},
				new Message {
					Id = 29,
					SenderId = 13, // Ahmet
					ReceiverId = 2, // Emma
					Content = "Hello Emma, I'm from Turkey. Would you like to practice Turkish with me?",
					CreatedAt = DateTime.UtcNow.AddDays(-17),
					IsDeleted = false
				},
				new Message {
					Id = 30,
					SenderId = 2, // Emma
					ReceiverId = 13, // Ahmet
					Content = "Hi Ahmet, sure I'd love to learn some Turkish! Can you teach me basic phrases?",
					CreatedAt = DateTime.UtcNow.AddDays(-17).AddHours(1),
					IsDeleted = false
				},
				new Message {
					Id = 31,
					SenderId = 14, // Ayşe
					ReceiverId = 3, // James
					Content = "Hello James, I saw your profile. What brings you to this app?",
					CreatedAt = DateTime.UtcNow.AddDays(-15),
					IsDeleted = false
				},
				new Message {
					Id = 32,
					SenderId = 3, // James
					ReceiverId = 14, // Ayşe
					Content = "Hi Ayşe, I'm looking to meet new people from different cultures. How about you?",
					CreatedAt = DateTime.UtcNow.AddDays(-15).AddHours(3),
					IsDeleted = false
				},
				new Message {
					Id = 33,
					SenderId = 16, // Zeynep
					ReceiverId = 5, // Oliver
					Content = "Hello Oliver, your travel photos look amazing. Where was your favorite place?",
					CreatedAt = DateTime.UtcNow.AddDays(-11),
					IsDeleted = false
				},
				new Message {
					Id = 34,
					SenderId = 5, // Oliver
					ReceiverId = 16, // Zeynep
					Content = "Hi Zeynep, thanks! I think my favorite was Turkey actually. I loved Istanbul!",
					CreatedAt = DateTime.UtcNow.AddDays(-11).AddHours(2),
					IsDeleted = false
				},
				new Message {
					Id = 35,
					SenderId = 19, // Emre
					ReceiverId = 8, // Mia
					Content = "Hello Mia, I'd like to practice my English. Would you mind chatting?",
					CreatedAt = DateTime.UtcNow.AddDays(-5),
					IsDeleted = false
				},
				new Message {
					Id = 36,
					SenderId = 8, // Mia
					ReceiverId = 19, // Emre
					Content = "Hi Emre, I don't mind at all! Your English seems good already!",
					CreatedAt = DateTime.UtcNow.AddDays(-5).AddMinutes(30),
					IsDeleted = false
				},
				new Message {
					Id = 37,
					SenderId = 20, // Selin
					ReceiverId = 9, // Liam
					Content = "Hello Liam, I see you're interested in photography. What kind of photos do you take?",
					CreatedAt = DateTime.UtcNow.AddDays(-3),
					IsDeleted = false
				},
				new Message {
					Id = 38,
					SenderId = 9, // Liam
					ReceiverId = 20, // Selin
					Content = "Hi Selin, I mostly do landscape and street photography. I'd love to visit Turkey someday for photos!",
					CreatedAt = DateTime.UtcNow.AddDays(-3).AddHours(1),
					IsDeleted = false
				},
				new Message {
					Id = 39,
					SenderId = 21, // Burak
					ReceiverId = 10, // Emily
					Content = "Hello Emily, I noticed we matched recently. What are your hobbies?",
					CreatedAt = DateTime.UtcNow.AddDays(-2),
					IsDeleted = false
				},
				new Message {
					Id = 40,
					SenderId = 10, // Emily
					ReceiverId = 21, // Burak
					Content = "Hi Burak, I enjoy reading, hiking and trying new foods. How about you?",
					CreatedAt = DateTime.UtcNow.AddDays(-2).AddHours(4),
					IsDeleted = false
				},
				new Message {
					Id = 41,
					SenderId = 22, // Ece
					ReceiverId = 11, // Ethan
					Content = "Hello Ethan, are you planning to visit Turkey anytime soon?",
					CreatedAt = DateTime.UtcNow.AddDays(-1),
					IsDeleted = false
				},
				new Message {
					Id = 42,
					SenderId = 11, // Ethan
					ReceiverId = 22, // Ece
					Content = "Hi Ece, actually I've been considering it. Any recommendations on places to visit?",
					CreatedAt = DateTime.UtcNow.AddDays(-1).AddHours(2),
					IsDeleted = false
				},
				new Message {
					Id = 43,
					SenderId = 22, // Ece
					ReceiverId = 11, // Ethan
					Content = "Definitely visit Istanbul, Cappadocia and the Turkish coast. When are you thinking of coming?",
					CreatedAt = DateTime.UtcNow.AddDays(-1).AddHours(3),
					IsDeleted = false
				},
				new Message {
					Id = 44,
					SenderId = 11, // Ethan
					ReceiverId = 22, // Ece
					Content = "I'm looking at dates in summer. Maybe we could meet up if I visit?",
					CreatedAt = DateTime.UtcNow.AddDays(-1).AddHours(4),
					IsDeleted = false
				},
				new Message {
					Id = 45,
					SenderId = 22, // Ece
					ReceiverId = 11, // Ethan
					Content = "That would be nice! Let me know your travel dates when you book.",
					CreatedAt = DateTime.UtcNow.AddDays(-1).AddHours(5),
					IsDeleted = false
				}
			);

			// Blocked Users
			modelBuilder.Entity<BlockedUser>().HasData(
				new BlockedUser {
					Id = 1,
					UserId = 2,
					BlockedUserId = 5,
					CreatedAt = DateTime.UtcNow.AddDays(-2),
					IsDeleted = false
				},
				new BlockedUser {
					Id = 2,
					UserId = 6,
					BlockedUserId = 11,
					CreatedAt = DateTime.UtcNow.AddDays(-5),
					IsDeleted = false
				},
				new BlockedUser {
					Id = 3,
					UserId = 8,
					BlockedUserId = 12,
					CreatedAt = DateTime.UtcNow.AddDays(-3),
					IsDeleted = false
				},
				new BlockedUser {
					Id = 4,
					UserId = 10,
					BlockedUserId = 4,
					CreatedAt = DateTime.UtcNow.AddDays(-7),
					IsDeleted = false
				}
			);

			// Entity Configurations
			modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
			modelBuilder.Entity<BlockedUser>().HasQueryFilter(b => !b.IsDeleted);
			modelBuilder.Entity<Message>().HasQueryFilter(m => !m.IsDeleted);

			modelBuilder.Entity<User>()
				.HasOne(u => u.Profile)
				.WithOne(p => p.User)
				.HasForeignKey<UserProfile>(p => p.UserId);

			modelBuilder.Entity<BlockedUser>()
				.HasOne(b => b.User)
				.WithMany(u => u.BlockedUsers)
				.HasForeignKey(b => b.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<BlockedUser>()
				.HasOne(b => b.Blocked)
				.WithMany()
				.HasForeignKey(b => b.BlockedUserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Message>()
				.HasOne(m => m.Sender)
				.WithMany(u => u.SentMessages)
				.HasForeignKey(m => m.SenderId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Message>()
				.HasOne(m => m.Receiver)
				.WithMany(u => u.ReceivedMessages)
				.HasForeignKey(m => m.ReceiverId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<MatchedUser>()
				.HasOne(m => m.User1)
				.WithMany(u => u.MatchesAsUser1)
				.HasForeignKey(m => m.User1Id)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<MatchedUser>()
				.HasOne(m => m.User2)
				.WithMany(u => u.MatchesAsUser2)
				.HasForeignKey(m => m.User2Id)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<UserSubscription>()
				.HasOne(us => us.User)
				.WithMany(u => u.Subscriptions)
				.HasForeignKey(us => us.UserId);

			modelBuilder.Entity<UserSubscription>()
				.HasOne(us => us.Plan)
				.WithMany(p => p.UserSubscriptions)
				.HasForeignKey(us => us.PlanId);
		}

	}
}
