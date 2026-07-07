using HotelManagementSystem.Interfaces.DinningInterface;
using HotelManagementSystem.Models.Dinning;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.DinningController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinningController : ControllerBase // Fixed 'Dinnning' spelling typo
    {
        private readonly IDinningService _dinningService;

        public DinningController(IDinningService dinningService)
        {
            _dinningService = dinningService;
        }

        [HttpPost("Create-Session")]
        public async Task<IActionResult> CreateDinningSession([FromBody] DinningDTO dto)
        {
            if (dto == null || dto.TableId <= 0)
            {
                return BadRequest(new { message = "Invalid data payload. A valid Table ID is required." });
            }

            try
            {
                var sessionId = await _dinningService.CreateDinningAsync(dto.TableId);
                return Ok(new { sessionId = sessionId, message = "Dining session initiated successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal server error occurred.", details = ex.Message });
            }
        }

        [HttpPost("End-Session/{sessionId}")]
        public async Task<IActionResult> EndDinningSession(int sessionId)
        {
            if (sessionId <= 0)
            {
                return BadRequest(new { message = "A valid Session ID must be provided." });
            }

            try
            {
                var rowsAffected = await _dinningService.EndDinningSessionAsync(sessionId);

                if (rowsAffected <= 0)
                {
                    return BadRequest(new { message = "Failed to close the session. It may already be closed or does not exist." });
                }

                return Ok(new { message = "Dining session closed successfully. Table has transitioned to cleaning status." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal server error occurred.", details = ex.Message });
            }
        }
    }
}