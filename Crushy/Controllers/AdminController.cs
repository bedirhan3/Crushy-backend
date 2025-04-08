using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crushy.Models;
using Crushy.Services;
using Newtonsoft.Json.Linq;
using System.Net.Http;

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

		// Location Resolver Endpoint
		[HttpGet("resolve-location")]
		public async Task<ActionResult<object>> ResolveLocation([FromQuery] string coordinates)
		{
			try
			{
				if (string.IsNullOrEmpty(coordinates) || !coordinates.Contains(","))
				{
					return BadRequest("Coordinates should be in format 'latitude,longitude'");
				}

				var parts = coordinates.Split(',');
				if (parts.Length != 2 || !double.TryParse(parts[0], out double latitude) || !double.TryParse(parts[1], out double longitude))
				{
					return BadRequest("Invalid coordinates format");
				}

				// Try using Nominatim API first
				try
				{
					string url = $"https://nominatim.openstreetmap.org/reverse?lat={latitude}&lon={longitude}&format=json&zoom=10&addressdetails=1";

					using HttpClient client = new HttpClient();
					client.DefaultRequestHeaders.Add("User-Agent", "CrushyApp/1.0"); // More detailed user agent
					client.Timeout = TimeSpan.FromSeconds(10); // Set timeout

					var response = await client.GetStringAsync(url);
					JObject json = JObject.Parse(response);

					// Check if there's an error in the response
					if (json["error"] != null)
					{
						// Log the error
						Console.WriteLine($"Nominatim API error: {json["error"]}");
						throw new Exception(json["error"].ToString());
					}

					var city = json["address"]?["city"] ?? json["address"]?["town"] ?? json["address"]?["village"] ?? json["address"]?["hamlet"] ?? "Unknown";
					var country = json["address"]?["country"] ?? "Unknown";
					var state = json["address"]?["state"] ?? json["address"]?["county"] ?? "Unknown";

					return Ok(new 
					{
						City = city.ToString(),
						State = state.ToString(),
						Country = country.ToString(),
						FullAddress = json["display_name"]?.ToString(),
						Coordinates = new { Latitude = latitude, Longitude = longitude },
						Source = "Nominatim"
					});
				}
				catch (Exception ex)
				{
					// Log the failure with Nominatim
					Console.WriteLine($"Nominatim API failed: {ex.Message}");
					
					// Fallback to BigDataCloud API or any other geocoding API
					try
					{
						string fallbackUrl = $"https://api.bigdatacloud.net/data/reverse-geocode-client?latitude={latitude}&longitude={longitude}&localityLanguage=en";
						
						using HttpClient fallbackClient = new HttpClient();
						fallbackClient.Timeout = TimeSpan.FromSeconds(10);
						
						var fallbackResponse = await fallbackClient.GetStringAsync(fallbackUrl);
						JObject fallbackJson = JObject.Parse(fallbackResponse);
						
						return Ok(new
						{
							City = fallbackJson["city"]?.ToString() ?? "Unknown",
							State = fallbackJson["principalSubdivision"]?.ToString() ?? "Unknown",
							Country = fallbackJson["countryName"]?.ToString() ?? "Unknown",
							FullAddress = $"{fallbackJson["locality"]}, {fallbackJson["city"]}, {fallbackJson["countryName"]}",
							Coordinates = new { Latitude = latitude, Longitude = longitude },
							Source = "BigDataCloud"
						});
					}
					catch (Exception fallbackEx)
					{
						// If both APIs fail, return manual approximate location based on coordinates
						return Ok(new
						{
							City = "Unknown",
							State = "Unknown",
							Country = GetApproximateCountry(latitude, longitude),
							FullAddress = "Could not resolve exact address",
							Coordinates = new { Latitude = latitude, Longitude = longitude },
							Source = "Approximate",
							Error = ex.Message,
							FallbackError = fallbackEx.Message
						});
					}
				}
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// Batch Location Resolver Endpoint
		[HttpGet("resolve-all-locations")]
		public async Task<ActionResult<object>> ResolveAllUserLocations()
		{
			try
			{
				var users = await _adminService.GetAllUsersAsync();
				var results = new List<object>();

				using HttpClient client = new HttpClient();
				client.DefaultRequestHeaders.Add("User-Agent", "CrushyApp/1.0");
				client.Timeout = TimeSpan.FromSeconds(10);

				foreach (var user in users)
				{
					if (string.IsNullOrEmpty(user.Profile?.Map) || !user.Profile.Map.Contains(","))
					{
						results.Add(new
						{
							UserId = user.Id,
							Username = user.Username,
							Location = "Unknown"
						});
						continue;
					}

					var parts = user.Profile.Map.Split(',');
					if (parts.Length != 2 || !double.TryParse(parts[0], out double latitude) || !double.TryParse(parts[1], out double longitude))
					{
						results.Add(new
						{
							UserId = user.Id,
							Username = user.Username,
							Location = "Invalid coordinates"
						});
						continue;
					}

					// Add a delay to avoid rate limiting
					await Task.Delay(1000);

					try
					{
						// Try Nominatim API
						string url = $"https://nominatim.openstreetmap.org/reverse?lat={latitude}&lon={longitude}&format=json&zoom=10&addressdetails=1";
						var response = await client.GetStringAsync(url);
						JObject json = JObject.Parse(response);

						if (json["error"] != null)
						{
							throw new Exception(json["error"].ToString());
						}

						var city = json["address"]?["city"] ?? json["address"]?["town"] ?? json["address"]?["village"] ?? json["address"]?["hamlet"] ?? "Unknown";
						var country = json["address"]?["country"] ?? "Unknown";

						results.Add(new
						{
							UserId = user.Id,
							Username = user.Username,
							Fullname = user.Profile.Fullname,
							City = city.ToString(),
							Country = country.ToString(),
							Coordinates = new { Latitude = latitude, Longitude = longitude },
							Source = "Nominatim"
						});
					}
					catch
					{
						try
						{
							// Fallback to BigDataCloud
							string fallbackUrl = $"https://api.bigdatacloud.net/data/reverse-geocode-client?latitude={latitude}&longitude={longitude}&localityLanguage=en";
							
							using HttpClient fallbackClient = new HttpClient();
							var fallbackResponse = await fallbackClient.GetStringAsync(fallbackUrl);
							JObject fallbackJson = JObject.Parse(fallbackResponse);
							
							results.Add(new
							{
								UserId = user.Id,
								Username = user.Username,
								Fullname = user.Profile.Fullname,
								City = fallbackJson["city"]?.ToString() ?? "Unknown",
								Country = fallbackJson["countryName"]?.ToString() ?? "Unknown",
								Coordinates = new { Latitude = latitude, Longitude = longitude },
								Source = "BigDataCloud"
							});
						}
						catch
						{
							// Use approximate location as last resort
							results.Add(new
							{
								UserId = user.Id,
								Username = user.Username,
								Fullname = user.Profile.Fullname,
								City = "Unknown",
								Country = GetApproximateCountry(latitude, longitude),
								Coordinates = new { Latitude = latitude, Longitude = longitude },
								Source = "Approximate"
							});
						}
					}
				}

				return Ok(results);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// Helper method for approximate country determination
		private string GetApproximateCountry(double latitude, double longitude)
		{
			// Very simple approximation
			if (latitude > 33 && latitude < 49 && longitude > -10 && longitude < 40)
				return "Europe";
			else if (latitude > 24 && latitude < 50 && longitude > 67 && longitude < 140)
				return "Asia";
			else if (latitude > 25 && latitude < 50 && longitude > -130 && longitude < -65)
				return "North America";
			else if (latitude > -35 && latitude < 15 && longitude > -80 && longitude < -35)
				return "South America";
			else if (latitude > -40 && latitude < 35 && longitude > -20 && longitude < 55)
				return "Africa";
			else if (latitude > -50 && latitude < -10 && longitude > 110 && longitude < 180)
				return "Oceania";
			else
				return "Unknown Region";
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

		[HttpGet("users/{userId}/detailed-report")]
		public async Task<ActionResult<object>> GetUserDetailedReport(int userId)
		{
			try
			{
				var report = await _adminService.GetUserDetailedReportAsync(userId);
				if (report == null)
					return NotFound();

				return Ok(report);
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
