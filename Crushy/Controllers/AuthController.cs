using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using System.Security.Cryptography;
using Crushy.Models;
using Crushy.Services;
using System;
using Crushy.Data;
using Crushy.Request;
using Microsoft.AspNetCore.Authorization;
using Azure.Core;

namespace denemetodo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IConfiguration _configuration;
		private readonly UserService _userService;
		private readonly EmailService _emailService;

		public AuthController(ApplicationDbContext context, IConfiguration configuration, UserService userService, EmailService emailService)
		{
			_context = context;
			_configuration = configuration;
			_userService = userService;
			_emailService = emailService;
		}

		// Login endpoint
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest user)
		{
			var existingUser = _userService.GetUserByUsername(user.Username);
			if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
				return Unauthorized("Invalid username or password");

			// Email doğrulama kontrolü
			if (existingUser.Role == "UnverifiedUser")
				return BadRequest("Please verify your email before logging in.");

			// Access Token oluştur
			var token = GenerateJwtToken(existingUser);

			// Refresh Token oluştur
			var refreshToken = GenerateRefreshToken();
			existingUser.RefreshToken = refreshToken;
			existingUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(7); 
			_userService.UpdateUser(existingUser);

			// Refresh Token'i HttpOnly Cookie'ye set et
			Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
			{
				HttpOnly = true,
				Secure = false, // Yalnızca HTTPS üzerinde çalışır
				SameSite = SameSiteMode.None, // CSRF saldırılarını önler
				Expires = DateTime.Now.AddDays(7) // Cookie'nin süresi
			});

			return Ok(new
			{
				AccessToken = token,
				Role = existingUser.Role
			});
		}

		// Admin Login endpoint
		[HttpPost("admin-login")]
		public IActionResult AdminLogin([FromBody] LoginRequest user)
		{
			var existingUser = _userService.GetUserByUsername(user.Username);
			if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
				return Unauthorized("Invalid username or password");

			// Admin rolü kontrolü	
			if (existingUser.Role != "Admin")
				return Unauthorized("You don't have permission to access admin panel");

			var token = GenerateJwtToken(existingUser, TimeSpan.FromHours(4));

			// Admin için Refresh Token oluştur
			var refreshToken = GenerateRefreshToken();
			existingUser.RefreshToken = refreshToken;
			existingUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(7); 
			_userService.UpdateUser(existingUser);

			// Refresh Token'i HttpOnly Cookie'ye set et
			Response.Cookies.Append("adminRefreshToken", refreshToken, new CookieOptions
			{
				HttpOnly = true,
				Secure = false,
				SameSite = SameSiteMode.None,
				Expires = DateTime.Now.AddDays(1)
			});

			return Ok(new
			{
				AccessToken = token,
				Role = existingUser.Role
			});
		}

/*
		[HttpPost("refresh-token")]
		public IActionResult RefreshToken()
		{
			var refreshToken = Request.Headers["refreshToken"].ToString();
			 refreshToken = Uri.UnescapeDataString(refreshToken);
			//var refreshToken = Request.Cookies["refreshToken"];
			if (string.IsNullOrEmpty(refreshToken))
				return Unauthorized("No refresh token provided");

			var user = _userService.GetUserByRefreshToken(refreshToken);
			if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
				return Unauthorized("Invalid or expired refresh token");

			// Yeni Access Token oluştur
			var newAccessToken = GenerateJwtToken(user);

			// Yeni Refresh Token oluştur ve kaydet
			var newRefreshToken = GenerateRefreshToken();
			user.RefreshToken = newRefreshToken;
			user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
			_userService.UpdateUser(user);

			// Yeni Refresh Token'i HttpOnly Cookie'ye set et
			Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
			{
				HttpOnly = true,
				Secure = false,
				SameSite = SameSiteMode.None,
				Expires = DateTime.Now.AddDays(7)
			});
			Response.Headers.Add("x-accessToken", newAccessToken);
			return Ok(new
			{
				AccessToken = newAccessToken
			});
		}

*/

		[HttpPost("refresh-token")]
		public IActionResult RefreshToken()
		{
			try
			{
				var refreshToken = Request.Headers["refreshToken"].ToString();
				refreshToken = Uri.UnescapeDataString(refreshToken);

				if (string.IsNullOrEmpty(refreshToken))
				{
					return Unauthorized(new
					{
						message = "No refresh token provided"
					});
				}

				var user = _userService.GetUserByRefreshToken(refreshToken);
				if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
				{
					return Unauthorized("Invalid or expired refresh token");

				}

				// Yeni Access Token oluştur
				var newAccessToken = GenerateJwtToken(user);

				// Yeni Refresh Token oluştur ve kaydet
				var newRefreshToken = GenerateRefreshToken();
				user.RefreshToken = newRefreshToken;
				user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
				_userService.UpdateUser(user);

				// Yeni Refresh Token'i HttpOnly Cookie'ye set et
				Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
				{
					HttpOnly = true,
					Secure = true, // ⛔️ production için bunu true yap
					SameSite = SameSiteMode.None,
					Expires = DateTime.Now.AddDays(7)
				});

				Response.Headers.Add("x-accessToken", newAccessToken);

				return Ok(new
				{
					accessToken = newAccessToken
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An unexpected error occurred.",
					detail = ex.Message
				});
			}
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
		public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
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
				Role = "UnverifiedUser", // Email doğrulanana kadar UnverifiedUser rolü
				CreatedAt = DateTime.Now
			};

			var userProfile = new UserProfile
			{
				Fullname = registerRequest.Fullname,
				Email = registerRequest.Email,
				Gender = registerRequest.Gender,
				Coin = 20 // Varsayılan coin değeri
			};

			// Kullanıcı ve profilini kaydet
			_userService.AddUserWithProfile(user, userProfile);

			// Doğrulama token'ı oluştur (24 saat geçerli)
			var verificationToken = GenerateJwtToken(user, TimeSpan.FromHours(24));

			// Doğrulama bağlantısı
			var verificationLink = Url.Action("verify-email", "Auth", 
				new { token = verificationToken }, Request.Scheme);

			if (string.IsNullOrEmpty(verificationLink))
			{
				// Eğer link oluşturulamazsa, tam URL'yi manuel oluştur
				verificationLink = $"{Request.Scheme}://{Request.Host}/api/Auth/verify-email?token={verificationToken}";
			}

			// E-posta gönderimi
			try
			{
                await _emailService.SendVerificationEmail(userProfile.Email, verificationLink);
            }
			catch
			{
				return BadRequest("Mail Gönderilemedi");
			}

			return Ok(new { message = "Registration successful. Please check your email to verify your account." });
		}


		[HttpGet("verify-email")]
		public IActionResult VerifyEmail(string token)
		{
			if (string.IsNullOrEmpty(token))
				return BadRequest("Invalid verification token");

			try
			{
				// Token'ı doğrula ve kullanıcı bilgilerini al
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
				var tokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};

				var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
				var userId = int.Parse(principal.FindFirst("UserId")?.Value ?? "0");

				var user = _userService.GetUserById(userId);
				if (user == null)
					return BadRequest("User not found");

				if (user.Role == "VerifiedUser")
					return BadRequest("Email is already verified");

				user.Role = "VerifiedUser";
				_userService.UpdateUser(user);

				return Ok(new { message = "Email verified successfully!" });
			}
			catch (SecurityTokenExpiredException)
			{
				return BadRequest("Verification token has expired");
			}
			catch
			{
				return BadRequest("Invalid verification token");
			}
		}

		// JWT token oluşturma fonksiyonu (süre parametreli)
		private string GenerateJwtToken(User user, TimeSpan? expiry = null)
		{
			var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.Now.Add(expiry ?? TimeSpan.FromMinutes(1)),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
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

		// Yetkilendirme kontrolü
		[Authorize(Roles = "VerifiedUser,Admin")] 
		[HttpGet("protected")]
		public IActionResult SomeProtectedEndpoint()
		{
			return Ok(new { message = "You have access to this protected endpoint!" });
		}
	}
}
