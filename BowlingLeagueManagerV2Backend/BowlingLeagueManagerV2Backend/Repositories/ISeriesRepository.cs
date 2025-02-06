using BowlingLeagueManagerV2Backend.Models;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public interface ISeriesRepository
    {
        // Get all series
        Task<IEnumerable<Series>> GetAllSeriesAsync();

        // Get series by SeriesId
        Task<Series> GetSeriesByIdAsync(long seriesId);
    
        // Get total pins by BowlerId
        Task<int> GetTotalPinsByBowlerIdAsync(long bowlerId, long leagueId);

        // Get total games bowled by BowlerId
        Task<int> GetTotalGamesBowledByBowlerIdAsync(long bowlerId, long leagueId);

        // Get highest game by BowlerId
        Task<int> GetHighestGameByBowlerIdAsync(long bowlerId, long leagueId);

        // Get highest series by BowlerId
        Task<int> GetHighestSeriesByBowlerIdAsync(long bowlerId, long leagueId);

        // Add a new series
        Task<Series> CreateSeriesAsync(Series series);

        // Update an existing series
        Task<Series> UpdateSeriesAsync(Series series);

        // Delete a series by SeriesId
        Task DeleteSeriesAsync(long seriesId);
    }
}
