using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Controllers
{
    [ApiController]
    [Route("bowlingLeagueManager/bowler")]
    public class BowlerController : ControllerBase
    {
        private readonly IBowlerService _bowlerService;

        // Constructor injection for the service
        public BowlerController(IBowlerService bowlerService)
        {
            _bowlerService = bowlerService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBowlers()
        {
            var bowlers = await _bowlerService.GetAllBowlersAsync();
            return Ok(bowlers);
        }

        // Endpoint to retrieve a specific bowler by ID
        [HttpGet("get")]
        public async Task<ActionResult<Bowler>> GetBowlerById([FromQuery] long bowlerId)
        {
            var bowler = await _bowlerService.GetBowlerByIdAsync(bowlerId);
            if (bowler != null)
            {
                return Ok(bowler);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBowler([FromBody] Bowler bowler)
        {
            var createdBowler = await _bowlerService.CreateBowlerAsync(bowler); // Call service method to create a new bowler
            return CreatedAtAction(nameof(CreateBowler), new { id = createdBowler.BowlerId }, createdBowler); // Return created bowler with HTTP status 201 (CREATED)
        }

        // Endpoint to update an existing bowler
        [HttpPut("update")]
        public async Task<ActionResult<Bowler>> UpdateBowler([FromQuery] long bowlerId, [FromBody] Bowler updatedBowler)
        {
            var existingBowler = await _bowlerService.GetBowlerByIdAsync(bowlerId);
            if (existingBowler != null)
            {
                var updated = await _bowlerService.UpdateBowlerAsync(bowlerId, updatedBowler);
                return Ok(updated);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to delete a bowler
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBowler([FromQuery] long bowlerId)
        {
            var bowler = await _bowlerService.GetBowlerByIdAsync(bowlerId);
            if (bowler != null)
            {
                await _bowlerService.DeleteBowlerAsync(bowlerId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
