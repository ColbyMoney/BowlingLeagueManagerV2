using BowlingLeagueManagerV2Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.DTOs
{
    [ApiController]
    [Route("bowlingLeagueManager/dto")]
    public class DtoController : ControllerBase
    {
        private readonly DtoService _dtoService;

        public DtoController(DtoService dtoService)
        {
            _dtoService = dtoService;
        }

        [HttpGet("leagueDetails")]
        public async Task<IActionResult> GetLeagueDetailsByIdAsync([FromQuery] long leagueId)
        {
            var leagueDetails = await _dtoService.GetLeagueDetailsByIdAsync(leagueId);

            if (leagueDetails == null)
            {
                return NotFound($"League details for league ID {leagueId} not found.");
            }

            return Ok(leagueDetails);
        }
    }
}
