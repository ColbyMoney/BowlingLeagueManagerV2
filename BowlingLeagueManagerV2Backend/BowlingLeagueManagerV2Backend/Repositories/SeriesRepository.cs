using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly ApplicationDbContext _context;

        public SeriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all series
        public async Task<IEnumerable<Series>> GetAllSeriesAsync()
        {
            return await _context.Series.ToListAsync();
        }

        // Get series by SeriesId
        public async Task<Series> GetSeriesByIdAsync(long seriesId)
        {
            return await _context.Series.FindAsync(seriesId);
        }

        // Get total pins by BowlerId
        public async Task<int> GetTotalPinsByBowlerIdAsync(long bowlerId, long leagueId)
        {
            return await _context.Series
                .Where(s => s.BowlerId == bowlerId && s.LeagueId == leagueId)
                .SumAsync(s => s.SeriesTotal);
        }

        // Get total games bowled by BowlerId
        public async Task<int> GetTotalGamesBowledByBowlerIdAsync(long bowlerId, long leagueId)
        {
            return await _context.Series
                .Where(s => s.BowlerId == bowlerId && s.LeagueId == leagueId)
                .SumAsync(s => (s.Game1 != 0 ? 1 : 0) + (s.Game2 != 0 ? 1 : 0) + (s.Game3 != 0 ? 1 : 0));
        }

        // Get highest game by BowlerId
        public async Task<int> GetHighestGameByBowlerIdAsync(long bowlerId, long leagueId)
        {
            // Step 1: Get all maximum values of Game1, Game2, Game3 for each series of the bowler
            var maxGamesPerSeries = await _context.Series
                .Where(s => s.BowlerId == bowlerId && s.LeagueId == leagueId)
                .Select(s => new[] { s.Game1, s.Game2, s.Game3 }.Max())
                .ToListAsync();

            // Step 2: Get the overall highest score
            return maxGamesPerSeries.Any() ? maxGamesPerSeries.Max() : 0;
        }

        // Get highest series by BowlerId
        public async Task<int> GetHighestSeriesByBowlerIdAsync(long bowlerId, long leagueId)
        {
            return await _context.Series
                .Where(s => s.BowlerId == bowlerId && s.LeagueId == leagueId)
                .MaxAsync(s => s.SeriesTotal);
        }

        // Add a new series
        public async Task<Series> CreateSeriesAsync(Series series)
        {
            _context.Series.Add(series);
            await _context.SaveChangesAsync();
            return series;
        }

        // Update an existing series
        public async Task<Series> UpdateSeriesAsync(Series series)
        {
            _context.Series.Update(series);
            await _context.SaveChangesAsync();
            return series;
        }

        // Delete a series by SeriesId
        public async Task DeleteSeriesAsync(long seriesId)
        {
            var series = await _context.Series.FindAsync(seriesId);
            if (series != null)
            {
                _context.Series.Remove(series);
                await _context.SaveChangesAsync();
            }
        }
    }
}
