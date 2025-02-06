using BowlingLeagueManagerV2Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeagueManagerV2Backend.DTOs
{
    public class DtoRepository
    {
        private readonly ApplicationDbContext _context;

        public DtoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeagueDetailsDto>> GetLeagueDetailsByIdAsync(long leagueId)
        {
            var leagueDetails = await _context.Set<LeagueDetailsDto>()
                .FromSqlRaw("EXEC [dbo].[GetLeagueDetailsById] @LeagueId = {0}", leagueId)
                .ToListAsync();

            return leagueDetails;
        }
    }
}
