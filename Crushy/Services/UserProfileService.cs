using Crushy.Data;
using Crushy.Models;
using Microsoft.EntityFrameworkCore;

namespace Crushy.Services
{
	public class UserProfileService
	{
		private readonly ApplicationDbContext _context;
		private readonly string _imageFolderPath;

		public UserProfileService(ApplicationDbContext context)
		{
			_context = context;
			_imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProfileImages");
			
			// Klasör yoksa oluştur
			if (!Directory.Exists(_imageFolderPath))
			{
				Directory.CreateDirectory(_imageFolderPath);
			}
		}

		// Profil resmi yükleme
		public async Task<string> UploadProfileImage(string refreshToken, IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				throw new ArgumentException("No file uploaded.");
			}

			var user = await _context.Users
				.Include(u => u.Profile)
				.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

			if (user == null)
			{
				throw new ArgumentException("User not found.");
			}

			// Eski resmi sil (varsa)
			if (!string.IsNullOrEmpty(user.Profile.ImageUrl))
			{
				var oldImagePath = Path.Combine(_imageFolderPath, Path.GetFileName(user.Profile.ImageUrl));
				if (File.Exists(oldImagePath))
				{
					File.Delete(oldImagePath);
				}
			}

			// Yeni resmi kaydet
			var fileName = $"{Guid.NewGuid()}_{file.FileName.Replace(" ","_")}";
			var filePath = Path.Combine(_imageFolderPath, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			// Kayıt için sadece dosya adını sakla
			user.Profile.ImageUrl = fileName;
			await _context.SaveChangesAsync();

			return fileName;
		}

		// Profil bilgilerini güncelleme
		public async Task UpdateProfile(string username, UserProfile updatedProfile)
		{
			var user = await _context.Users
				.Include(u => u.Profile)
				.FirstOrDefaultAsync(u => u.Username == username);

			if (user == null)
			{
				throw new ArgumentException("User not found.");
			}

			user.Profile.Fullname = updatedProfile.Fullname;
			user.Profile.Gender = updatedProfile.Gender;
			user.Profile.Map = updatedProfile.Map;

			await _context.SaveChangesAsync();
		}

		// Profil bilgilerini getirme
		public async Task<UserProfile> GetProfile(string username)
		{
			var user = await _context.Users
				.Include(u => u.Profile)
				.FirstOrDefaultAsync(u => u.Username == username);

			return user?.Profile;
		}

		// Tüm profilleri listeleme
		public async Task<List<UserProfile>> GetAllProfiles()
		{
			return await _context.UserProfiles
				.Include(p => p.User)
				.ToListAsync();
		}

		// Coin miktarını güncelleme
		public async Task UpdateCoin(string username, int amount)
		{
			var user = await _context.Users
				.Include(u => u.Profile)
				.FirstOrDefaultAsync(u => u.Username == username);

			if (user == null)
			{
				throw new ArgumentException("User not found.");
			}

			user.Profile.Coin += amount;
			await _context.SaveChangesAsync();
		}
	}
}
