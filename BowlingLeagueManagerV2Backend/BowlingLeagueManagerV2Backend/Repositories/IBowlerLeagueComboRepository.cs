using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public interface IBowlerLeagueComboRepository
    {
        Task<IEnumerable<BowlerLeagueCombo>> GetAllBowlerLeagueCombosAsync();
        Task<BowlerLeagueCombo> GetBowlerLeagueComboByIdAsync(long id);
        Task<BowlerLeagueCombo> GetBowlerLeagueComboByBowlerAndLeagueIdAsync(long bowlerId, long leagueId);
        Task<BowlerLeagueCombo> CreateBowlerLeagueComboAsync(BowlerLeagueCombo bowler);
        Task<BowlerLeagueCombo> UpdateBowlerLeagueComboAsync(BowlerLeagueCombo bowler);
        Task DeleteBowlerLeagueComboAsync(long id);
    }
}
