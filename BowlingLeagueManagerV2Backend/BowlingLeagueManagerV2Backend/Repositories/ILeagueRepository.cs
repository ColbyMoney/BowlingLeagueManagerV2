using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public interface ILeagueRepository
    {
        Task<IEnumerable<League>> GetAllLeaguesAsync();
        Task<League> GetLeagueByIdAsync(long id);
        Task<League> CreateLeagueAsync(League league);
        Task<League> UpdateLeagueAsync(League league);
        Task DeleteLeagueAsync(long id);
    }
}
