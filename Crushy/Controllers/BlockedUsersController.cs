using Crushy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Crushy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlockedUsersController : ControllerBase
    {
        private readonly BlockedUserService _blockedUserService;

        public BlockedUsersController(BlockedUserService blockedUserService)
        {
            _blockedUserService = blockedUserService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetBlockedUsers()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var blockedUsers = await _blockedUserService.GetBlockedUsersAsync(userId);
            return Ok(blockedUsers);
        }

        [HttpPost("block")]
        public async Task<IActionResult> BlockUser([FromQuery] int blockedUserId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            if (userId == blockedUserId)
            {
                return BadRequest("Kendinizi engelleyemezsiniz.");
            }

            try
            {
                var blockedUser = await _blockedUserService.BlockUserAsync(userId, blockedUserId);
                return Ok(blockedUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("unblock")]
        public async Task<IActionResult> UnblockUser([FromQuery] int blockedUserId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            try
            {
                await _blockedUserService.UnblockUserAsync(userId, blockedUserId);
                return Ok(new { message = "Engel başarıyla kaldırıldı." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("check")]
        public async Task<IActionResult> CheckIfBlocked([FromQuery] int blockedUserId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var isBlocked = await _blockedUserService.IsUserBlockedAsync(userId, blockedUserId);
            return Ok(new { isBlocked });
        }
        
        [HttpGet("blocked-by")]
        public async Task<IActionResult> IsBlockedByUser([FromQuery] int otherUserId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var isBlocked = await _blockedUserService.IsBlockedByUserAsync(userId, otherUserId);
            return Ok(new { isBlocked });
        }
    }
}