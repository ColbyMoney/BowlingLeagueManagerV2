using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public interface ILeagueService
    {
        Task<IEnumerable<League>> GetAllLeaguesAsync();

        // Retrieve a specific league by ID
        Task<League> GetLeagueByIdAsync(long id);

        // Create a new league
        Task<League> CreateLeagueAsync(League league);

        // Update an existing league
        Task<League> UpdateLeagueAsync(long id, League updatedLeague);

        // Delete a league by ID
        Task DeleteLeagueAsync(long id);
    }
}
