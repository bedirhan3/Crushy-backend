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
				var refreshToken = Request.Headers["refreshToken"].ToString();

				if (string.IsNullOrEmpty(refreshToken))
				{
					return BadRequest("User not found in token.");
				}

				var imageUrl = await _profileService.UploadProfileImage(refreshToken, file);
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
	}
}
