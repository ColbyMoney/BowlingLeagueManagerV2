using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public interface IBowlerService
    {
        Task<IEnumerable<Bowler>> GetAllBowlersAsync();

        // Retrieve a specific bowler by ID
        Task<Bowler> GetBowlerByIdAsync(long id);

        // Create a new bowler
        Task<Bowler> CreateBowlerAsync(Bowler bowler);

        // Update an existing bowler
        Task<Bowler> UpdateBowlerAsync(long id, Bowler updatedBowler);

        // Delete a bowler by ID
        Task DeleteBowlerAsync(long id);
    }
}