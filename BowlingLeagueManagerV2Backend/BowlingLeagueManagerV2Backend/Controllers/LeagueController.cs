using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Controllers
{
    [ApiController]
    [Route("bowlingleaguemanager/league")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        // Constructor injection for the service
        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllLeagues()
        {
            var leagues = await _leagueService.GetAllLeaguesAsync();
            return Ok(leagues);
        }

        // Endpoint to retrieve a specific league by ID
        [HttpGet("get")]
        public async Task<ActionResult<League>> GetLeagueById([FromQuery] long leagueId)
        {
            var league = await _leagueService.GetLeagueByIdAsync(leagueId);
            if (league != null)
            {
                return Ok(league);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLeague([FromBody] League league)
        {
            var createdLeague = await _leagueService.CreateLeagueAsync(league); // Call service method to create a new league
            return CreatedAtAction(nameof(CreateLeague), new { id = createdLeague.LeagueId }, createdLeague); // Return created league with HTTP status 201 (CREATED)
        }

        // Endpoint to update an existing league
        [HttpPut("update")]
        public async Task<ActionResult<League>> UpdateLeague([FromQuery] long leagueId, [FromBody] League updatedLeague)
        {
            var existingLeague = await _leagueService.GetLeagueByIdAsync(leagueId);
            if (existingLeague != null)
            {
                var updated = await _leagueService.UpdateLeagueAsync(leagueId, updatedLeague);
                return Ok(updated);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to delete a league
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteLeague([FromQuery] long leagueId)
        {
            var league = await _leagueService.GetLeagueByIdAsync(leagueId);
            if (league != null)
            {
                await _leagueService.DeleteLeagueAsync(leagueId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
