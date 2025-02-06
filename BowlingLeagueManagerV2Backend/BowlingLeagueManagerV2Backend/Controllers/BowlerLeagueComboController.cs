using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Controllers
{
    [ApiController]
    [Route("bowlingLeagueManager/bowlerLeagueCombo")]
    public class BowlerLeagueComboController : ControllerBase
    {
        private readonly IBowlerLeagueComboService _bowlerLeagueComboService;

        public BowlerLeagueComboController(IBowlerLeagueComboService bowlerLeagueComboService)
        {
            _bowlerLeagueComboService = bowlerLeagueComboService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBowlerLeagueCombos()
        {
            var bowlerLeagueCombos = await _bowlerLeagueComboService.GetAllBowlerLeagueCombosAsync();
            return Ok(bowlerLeagueCombos);
        }

        [HttpGet("get")]
        public async Task<ActionResult<Series>> GetBowlerLeagueComboById([FromQuery] long bowlerLeagueComboId)
        {
            var series = await _bowlerLeagueComboService.GetBowlerLeagueComboByIdAsync(bowlerLeagueComboId);
            if (series != null)
            {
                return Ok(series);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<Series>> CreateBowlerLeagueCombo([FromBody] BowlerLeagueCombo bowlerLeagueCombo)
        {
            var createdBowlerLeagueCombo = await _bowlerLeagueComboService.CreateBowlerLeagueComboAsync(bowlerLeagueCombo);
            //await _bowlerLeagueComboService.UpdateBowlerLeagueComboStatsAsync(bowlerLeagueCombo.BowlerId, bowlerLeagueCombo.LeagueId);
            return CreatedAtAction(nameof(GetBowlerLeagueComboById), new { bowlerLeagueComboId = createdBowlerLeagueCombo.BowlerLeagueComboId }, createdBowlerLeagueCombo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<BowlerLeagueCombo>> UpdateBowlerLeagueCombo([FromQuery] long bowlerLeagueComboId, [FromBody] BowlerLeagueCombo updatedBowlerLeagueCombo)
        {
            var existingBowlerLeagueCombo = await _bowlerLeagueComboService.GetBowlerLeagueComboByIdAsync(bowlerLeagueComboId);
            if (existingBowlerLeagueCombo != null)
            {
                var updated = await _bowlerLeagueComboService.UpdateBowlerLeagueComboAsync(bowlerLeagueComboId, updatedBowlerLeagueCombo);
                //await _bowlerLeagueComboService.UpdateBowlerLeagueComboStatsAsync(updatedBowlerLeagueCombo.BowlerId, updatedBowlerLeagueCombo.LeagueId);
                return Ok(updated);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to delete a bowler
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBowlerLeagueCombo([FromQuery] long bowlerLeagueComboId)
        {
            var bowler = await _bowlerLeagueComboService.GetBowlerLeagueComboByIdAsync(bowlerLeagueComboId);
            if (bowler != null)
            {
                await _bowlerLeagueComboService.DeleteBowlerLeagueComboAsync(bowlerLeagueComboId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
