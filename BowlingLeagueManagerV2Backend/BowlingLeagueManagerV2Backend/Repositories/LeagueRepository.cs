using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly ApplicationDbContext _context;

        public LeagueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all leagues
        public async Task<IEnumerable<League>> GetAllLeaguesAsync()
        {
            return await _context.Leagues.ToListAsync();
        }

        // Retrieve a specific league by ID
        public async Task<League> GetLeagueByIdAsync(long id)
        {
            return await _context.Leagues.FindAsync(id);
        }

        // Add a new league
        public async Task<League> CreateLeagueAsync(League league)
        {
            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();
            return league;
        }

        // Update an existing league
        public async Task<League> UpdateLeagueAsync(League league)
        {
            _context.Leagues.Update(league);
            await _context.SaveChangesAsync();
            return league;
        }

        // Delete a league by ID
        public async Task DeleteLeagueAsync(long id)
        {
            var league = await _context.Leagues.FindAsync(id);
            if (league != null)
            {
                _context.Leagues.Remove(league);
                await _context.SaveChangesAsync();
            }
        }
    }
}
