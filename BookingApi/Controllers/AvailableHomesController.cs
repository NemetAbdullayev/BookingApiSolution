using BookingApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [ApiController]
    [Route("api/available-homes")]
    public class AvailableHomesController : ControllerBase
    {
        private readonly IHomeAvailabilityService _availabilityService;

        public AvailableHomesController(IHomeAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        /// <summary>
        /// Get available homes for a given date range.
        /// </summary>
        /// <param name="startDate">Example: 2025-07-16</param>
        /// <param name="endDate">Example: 2025-07-17</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAvailableHomes(
            [FromQuery] DateOnly startDate,
            [FromQuery] DateOnly endDate)
        {
            if (startDate > endDate)
                return BadRequest("Start date must be earlier than or equal to end date.");

            var homes = await _availabilityService.GetAvailableHomesAsync(startDate, endDate);

            return Ok(new
            {
                status = "OK",
                homes = homes.Select(h => new
                {
                    h.HomeId,
                    h.HomeName,
                    availableSlots = h.AvailableSlots.Select(d => d.ToString("yyyy-MM-dd"))
                })
            });
        }
    }
}