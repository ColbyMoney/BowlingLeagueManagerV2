using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public class BowlerLeagueComboRepository : IBowlerLeagueComboRepository
    {
        private readonly ApplicationDbContext _context;

        public BowlerLeagueComboRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all bowler league combos
        public async Task<IEnumerable<BowlerLeagueCombo>> GetAllBowlerLeagueCombosAsync()
        {
            return await _context.BowlerLeagueCombos.ToListAsync();
        }

        // Retrieve a specific bowler league combo by ID
        public async Task<BowlerLeagueCombo> GetBowlerLeagueComboByIdAsync(long id)
        {
            return await _context.BowlerLeagueCombos.FindAsync(id);
        }

        // Retrieve a specific bowler league combo by ID
        public async Task<BowlerLeagueCombo> GetBowlerLeagueComboByBowlerAndLeagueIdAsync(long bowlerId, long leagueId)
        {
            return await _context.BowlerLeagueCombos
                .FirstOrDefaultAsync(bowlerLeagueCombo => bowlerLeagueCombo.BowlerId == bowlerId && bowlerLeagueCombo.LeagueId == leagueId);
        }

        // Add a new bowler league combo
        public async Task<BowlerLeagueCombo> CreateBowlerLeagueComboAsync(BowlerLeagueCombo bowlerLeagueCombo)
        {
            _context.BowlerLeagueCombos.Add(bowlerLeagueCombo);
            await _context.SaveChangesAsync();
            return bowlerLeagueCombo;
        }

        // Update an existing bowler league combo
        public async Task<BowlerLeagueCombo> UpdateBowlerLeagueComboAsync(BowlerLeagueCombo bowlerLeagueCombo)
        {
            _context.BowlerLeagueCombos.Update(bowlerLeagueCombo);
            await _context.SaveChangesAsync();
            return bowlerLeagueCombo;
        }

        // Delete a bowler league combo by ID
        public async Task DeleteBowlerLeagueComboAsync(long id)
        {
            var bowlerLeagueCombo = await _context.BowlerLeagueCombos.FindAsync(id);
            if (bowlerLeagueCombo != null)
            {
                _context.BowlerLeagueCombos.Remove(bowlerLeagueCombo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
