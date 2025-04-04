using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crushy.Models;
using Crushy.Services;

namespace Crushy.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class AdminController : ControllerBase
	{
		private readonly AdminService _adminService;

		public AdminController(AdminService adminService)
		{
			_adminService = adminService;
		}

		// Dashboard Endpoints
		[HttpGet("dashboard/stats")]
		public async Task<ActionResult<object>> GetDashboardStats()
		{
			try
			{
				var stats = await _adminService.GetDashboardStatsAsync();
				return Ok(stats);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// User Management Endpoints
		[HttpGet("users")]
		public async Task<ActionResult<List<User>>> GetAllUsers()
		{
			try
			{
				var users = await _adminService.GetAllUsersAsync();
				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("users/{userId}")]
		public async Task<ActionResult<User>> GetUserById(int userId)
		{
			try
			{
				var user = await _adminService.GetUserByIdAsync(userId);
				if (user == null)
					return NotFound();

				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("users/subscribers")]
		public async Task<ActionResult<List<User>>> GetSubscribedUsers()
		{
			try
			{
				var users = await _adminService.GetSubscribedUsersAsync();
				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("users/blocked")]
		public async Task<ActionResult<List<User>>> GetBlockedUsers()
		{
			try
			{
				var users = await _adminService.GetBlockedUsersAsync();
				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("users/{userId}")]
		public async Task<IActionResult> DeleteUser(int userId)
		{
			try
			{
				var result = await _adminService.DeleteUserAsync(userId);
				if (!result)
					return NotFound();

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost("users/{userId}/block")]
		public async Task<IActionResult> BlockUser(int userId, [FromBody] int blockedById)
		{
			try
			{
				var result = await _adminService.ToggleBlockUserAsync(userId, blockedById);
				if (!result)
					return NotFound();

				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// Subscription Management
		[HttpPost("users/{userId}/subscription")]
		public async Task<IActionResult> UpdateUserSubscription(
			int userId, 
			[FromBody] SubscriptionUpdateRequest request)
		{
			try
			{
				var result = await _adminService.UpdateUserSubscriptionAsync(
					userId, 
					request.PlanId, 
					request.DurationInMonths);
				
				if (!result)
					return NotFound();

				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// Match Management
		[HttpGet("matches")]
		public async Task<ActionResult<List<MatchedUser>>> GetAllMatches()
		{
			try
			{
				var matches = await _adminService.GetAllMatchesAsync();
				return Ok(matches);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}

	public class SubscriptionUpdateRequest
	{
		public int PlanId { get; set; }
		public int DurationInMonths { get; set; } = 1;
	}
}
