using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public interface IBowlerRepository
    {
        Task<IEnumerable<Bowler>> GetAllBowlersAsync();
        Task<Bowler> GetBowlerByIdAsync(long id);
        Task<Bowler> CreateBowlerAsync(Bowler bowler);
        Task<Bowler> UpdateBowlerAsync(Bowler bowler);
        Task DeleteBowlerAsync(long id);
    }
}