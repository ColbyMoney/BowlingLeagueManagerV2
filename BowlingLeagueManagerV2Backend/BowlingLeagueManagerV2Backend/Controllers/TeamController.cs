using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BowlingLeagueManagerV2Backend.Controllers
{
    [ApiController]
    [Route("bowlingLeagueManager/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        // Constructor injection for the service
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        // Endpoint to retrieve a specific team by ID
        [HttpGet("get")]
        public async Task<ActionResult<Team>> GetTeamById([FromQuery] long teamId)
        {
            var team = await _teamService.GetTeamByIdAsync(teamId);
            if (team != null)
            {
                return Ok(team);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            var createdTeam = await _teamService.CreateTeamAsync(team); // Call service method to create a new team
            return CreatedAtAction(nameof(CreateTeam), new { id = createdTeam.TeamId }, createdTeam); // Return created team with HTTP status 201 (CREATED)
        }

        // Endpoint to update an existing team
        [HttpPut("update")]
        public async Task<ActionResult<Team>> UpdateTeam([FromQuery] long teamId, [FromBody] Team updatedTeam)
        {
            var existingTeam = await _teamService.GetTeamByIdAsync(teamId);
            if (existingTeam != null)
            {
                var updated = await _teamService.UpdateTeamAsync(teamId, updatedTeam);
                return Ok(updated);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to delete a team
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTeam([FromQuery] long teamId)
        {
            var team = await _teamService.GetTeamByIdAsync(teamId);
            if (team != null)
            {
                await _teamService.DeleteTeamAsync(teamId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
