using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public interface IBowlerLeagueComboService
    {
        Task<IEnumerable<BowlerLeagueCombo>> GetAllBowlerLeagueCombosAsync();

        // Retrieve a specific bowler by ID
        Task<BowlerLeagueCombo> GetBowlerLeagueComboByIdAsync(long id);

        // Create a new bowler
        Task<BowlerLeagueCombo> CreateBowlerLeagueComboAsync(BowlerLeagueCombo bowlerLeagueCombo);

        // Update an existing bowler
        Task<BowlerLeagueCombo> UpdateBowlerLeagueComboAsync(long id, BowlerLeagueCombo updatedBowlerLeagueCombo);

        // Delete a bowler by ID
        Task DeleteBowlerLeagueComboAsync(long id);

        // Update a bowler's high game and series
        Task UpdateBowlerLeagueComboStatsAsync(long bowlerId, long leagueId);
    }
}
