
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using System.Security.Cryptography;
using Crushy.Models;
using Crushy.UserService;
using System;
using Crushy.Data;
using Crushy.Request;

namespace denemetodo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IConfiguration _configuration;
		private readonly UserService _userService;

		public AuthController(ApplicationDbContext context, IConfiguration configuration, UserService userService)
		{
			_context = context;
			_configuration = configuration;
			_userService = userService;
		}

		// Login endpoint
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest user)
		{
			var existingUser = _userService.GetUserByUsername(user.Username);
			if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
				return Unauthorized("Invalid username or password");

			// Access Token oluştur
			var token = GenerateJwtToken(existingUser);

			// Refresh Token oluştur
			var refreshToken = GenerateRefreshToken();
			existingUser.RefreshToken = refreshToken;
			existingUser.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(30); // Refresh Token geçerlilik süresi
			_userService.UpdateUser(existingUser);

			// Refresh Token'i HttpOnly Cookie'ye set et
			Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
			{
				HttpOnly = true,
				Secure = false, // Yalnızca HTTPS üzerinde çalışır
				SameSite = SameSiteMode.None, // CSRF saldırılarını önler
				Expires = DateTime.UtcNow.AddMinutes(30) // Cookie'nin süresi
			});

			return Ok(new
			{
				AccessToken = token
			});
		}


		[HttpPost("refresh-token")]
		public IActionResult RefreshToken()
		{
			// HttpOnly Cookie'den Refresh Token al
			var refreshToken = Request.Cookies["refreshToken"];
			if (string.IsNullOrEmpty(refreshToken))
				return Unauthorized("No refresh token provided");

			var user = _userService.GetUserByRefreshToken(refreshToken);
			if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
				return Unauthorized("Invalid or expired refresh token");

			// Yeni Access Token oluştur
			var newAccessToken = GenerateJwtToken(user);

			// Yeni Refresh Token oluştur ve kaydet
			var newRefreshToken = GenerateRefreshToken();
			user.RefreshToken = newRefreshToken;
			user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
			_userService.UpdateUser(user);

			// Yeni Refresh Token'i HttpOnly Cookie'ye set et
			Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
			{
				HttpOnly = true,
				Secure = false,
				SameSite = SameSiteMode.None,
				Expires = DateTime.UtcNow.AddDays(7)
			});

			return Ok(new
			{
				AccessToken = newAccessToken
			});
		}


		[HttpPost("logout")]
		public IActionResult Logout()
		{
			// HttpOnly Cookie'yi temizle
			Response.Cookies.Delete("refreshToken");

			return Ok(new { message = "Logged out successfully" });
		}


		// Register endpoint
		[HttpPost("register")]
		public IActionResult Register([FromBody] RegisterRequest registerRequest)
		{
			// Kullanıcı zaten var mı kontrol et
			var existingUser = _userService.GetUserByUsername(registerRequest.Username);
			if (existingUser != null)
				return BadRequest("User already exists.");

			// Yeni kullanıcı oluştur ve şifreyi hash'le
			var user = new User
			{
				Username = registerRequest.Username,
				Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password),
				Role = "User"
			};

			// Veritabanına kaydet
			_userService.AddUser(user);

			// JWT token oluştur
			var token = GenerateJwtToken(user);

			return Ok(new { Token = token });
		}


		// Refresh token oluşturma fonksiyonu

		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		// JWT token oluşturma fonksiyonu
		private string GenerateJwtToken(User user)
		{
			var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim("UserId", user.Id.ToString()),
					new Claim("Username", user.Username),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}


	}
}
