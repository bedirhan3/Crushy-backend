using Crushy.Data;
using Crushy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Crushy.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserProfileService _profileService;
		private readonly UserService _userService;

		public UsersController(UserProfileService profileService, UserService userService)
		{
			_profileService = profileService;
			_userService = userService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> List()
		{
			var profiles = await _profileService.GetAllProfiles();
			return Ok(profiles);
		}

		[Authorize]
		[HttpPost("uploadProfileImage")]
		public async Task<IActionResult> UploadProfileImage([FromForm] IFormFile file)
		{
			try
			{
				//var refreshToken = Request.Cookies["refreshToken"]; 
				// var refreshToken = Request.Headers["refreshToken"].ToString();
				
				var username = User.FindFirst(ClaimTypes.Name)?.Value;

				if (string.IsNullOrEmpty(username))
				{
					return BadRequest("User not found in token.");
				}

				var imageUrl = await _profileService.UploadProfileImage(username, file);
				return Ok(new { ProfileImageUrl = imageUrl });
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while uploading the image.");
			}
		}

		[Authorize]
		[HttpGet("profile")]
		public async Task<IActionResult> GetProfile()
		{
			try
			{
				var username = User.FindFirst(ClaimTypes.Name)?.Value;
				if (string.IsNullOrEmpty(username))
				{
					return BadRequest("User not found in token.");
				}

				var profile = await _profileService.GetProfile(username);
				if (profile == null)
				{
					return NotFound("Profile not found.");
				}

				return Ok(profile);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while retrieving the profile.");
			}
		}

		[Authorize]
		[HttpPut("profile")]
		public async Task<IActionResult> UpdateProfile([FromBody] Models.UserProfile updatedProfile)
		{
			try
			{
				var username = User.FindFirst(ClaimTypes.Name)?.Value;
				if (string.IsNullOrEmpty(username))
				{
					return BadRequest("User not found in token.");
				}

				await _profileService.UpdateProfile(username, updatedProfile);
				return Ok(new { message = "Profile updated successfully." });
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while updating the profile.");
			}
		}

		[Authorize]
		[HttpPost("updateCoin")]
		public async Task<IActionResult> UpdateCoin([FromBody] int amount)
		{
			try
			{
				var username = User.FindFirst(ClaimTypes.Name)?.Value;
				if (string.IsNullOrEmpty(username))
				{
					return BadRequest("User not found in token.");
				}

				await _profileService.UpdateCoin(username, amount);
				return Ok(new { message = "Coin amount updated successfully." });
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while updating the coin amount.");
			}
		}
		
		[Authorize]
		[HttpGet("basicInfo")]
		public async Task<IActionResult> GetBasicInfo([FromQuery] int userId)
		{
			try
			{
				var info = _userService.GetBasicInfoByUserId(userId);
				if (info == null)
					return NotFound("User profile not found.");

				return Ok(info);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while fetching the user info.");
			}
		}
		
		[Authorize]
		[HttpPost("updateFcmToken")]
		public async Task<IActionResult> UpdateFcmToken([FromBody] string fcmToken)
		{
			try
			{
				var username = User.FindFirst(ClaimTypes.Name)?.Value;
				if (string.IsNullOrEmpty(username))
				{
					return BadRequest("User not found in token.");
				}

				var user = await Task.Run(() => _userService.GetUserByUsername(username));
				if (user == null || user.Profile == null)
				{
					return NotFound("User or user profile not found.");
				}

				var success = await _userService.UpdateFcmTokenAsync(user.Id, fcmToken);

				if (!success)
				{
					return StatusCode(500, "Failed to update FCM token.");
				}

				return Ok(new { message = "FCM token updated successfully." });
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while updating the FCM token.");
			}
		}
		
	}
}
