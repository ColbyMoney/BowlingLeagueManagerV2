using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Controllers
{
    [Route("bowlingleaguemanager/series")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;
        private readonly IBowlerLeagueComboService _bowlerLeagueComboService;

        public SeriesController(ISeriesService seriesService, IBowlerLeagueComboService bowlerLeagueComboService)
        {
            _seriesService = seriesService;
            _bowlerLeagueComboService = bowlerLeagueComboService;
        }

        // Endpoint to retrieve all series
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Series>>> GetAllSeries()
        {
            var series = await _seriesService.GetAllSeriesAsync();
            return Ok(series);
        }

        // Endpoint to retrieve a specific series by ID
        [HttpGet("get")]
        public async Task<ActionResult<Series>> GetSeriesById([FromQuery] long seriesId)
        {
            var series = await _seriesService.GetSeriesByIdAsync(seriesId);
            if (series != null)
            {
                return Ok(series);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to create a new series
        [HttpPost("create")]
        public async Task<ActionResult<Series>> CreateSeries([FromBody] Series series)
        {
            var createdSeries = await _seriesService.CreateSeriesAsync(series);
            await _bowlerLeagueComboService.UpdateBowlerLeagueComboStatsAsync(series.BowlerId, series.LeagueId);
            return CreatedAtAction(nameof(GetSeriesById), new { seriesId = createdSeries.SeriesId }, createdSeries);
        }

        // Endpoint to update an existing series
        [HttpPut("update")]
        public async Task<ActionResult<Series>> UpdateSeries([FromQuery] long seriesId, [FromBody] Series updatedSeries)
        {
            var existingSeries = await _seriesService.GetSeriesByIdAsync(seriesId);
            if (existingSeries != null)
            {
                var updated = await _seriesService.UpdateSeriesAsync(seriesId, updatedSeries);
                await _bowlerLeagueComboService.UpdateBowlerLeagueComboStatsAsync(updatedSeries.BowlerId, updatedSeries.LeagueId);
                return Ok(updated);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to delete a series
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSeries([FromQuery] long seriesId)
        {
            var series = await _seriesService.GetSeriesByIdAsync(seriesId);
            if (series != null)
            {
                await _seriesService.DeleteSeriesAsync(seriesId);
                await _bowlerLeagueComboService.UpdateBowlerLeagueComboStatsAsync(series.BowlerId, series.LeagueId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
