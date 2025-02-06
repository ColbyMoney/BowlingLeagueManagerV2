using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public interface ISeriesService
    {
        Task<IEnumerable<Series>> GetAllSeriesAsync();

        // Retrieve a specific series by ID
        Task<Series> GetSeriesByIdAsync(long id);

        // Create a new series
        Task<Series> CreateSeriesAsync(Series series);

        // Update an existing series
        Task<Series> UpdateSeriesAsync(long id, Series updatedSeries);

        // Delete a series by ID
        Task DeleteSeriesAsync(long id);

        // Get total pins
        Task<int> GetTotalPinsByBowlerIdPerLeagueAsync(long bowlerId, long leagueId);

        // Get number of games bowled
        Task<int> GetTotalGamesBowledByBowlerIdPerLeagueAsync(long bowlerId, long leagueId);

        // Get highest game
        Task<int> GetHighestGameByBowlerIdPerLeagueAsync(long bowlerId, long leagueId);

        // Get highest series
        Task<int> GetHighestSeriesByBowlerIdPerLeagueAsync(long bowlerId, long leagueId);
    }
}