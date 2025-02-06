using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public class BowlerRepository : IBowlerRepository
    {
        private readonly ApplicationDbContext _context;

        public BowlerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all bowlers
        public async Task<IEnumerable<Bowler>> GetAllBowlersAsync()
        {
            return await _context.Bowlers.ToListAsync();
        }

        // Retrieve a specific bowler by ID
        public async Task<Bowler> GetBowlerByIdAsync(long id)
        {
            return await _context.Bowlers.FindAsync(id);
        }

        // Add a new bowler
        public async Task<Bowler> CreateBowlerAsync(Bowler bowler)
        {
            _context.Bowlers.Add(bowler);
            await _context.SaveChangesAsync();
            return bowler;
        }

        // Update an existing bowler
        public async Task<Bowler> UpdateBowlerAsync(Bowler bowler)
        {
            _context.Bowlers.Update(bowler);
            await _context.SaveChangesAsync();
            return bowler;
        }

        // Delete a bowler by ID
        public async Task DeleteBowlerAsync(long id)
        {
            var bowler = await _context.Bowlers.FindAsync(id);
            if (bowler != null)
            {
                _context.Bowlers.Remove(bowler);
                await _context.SaveChangesAsync();
            }
        }
    }
}
