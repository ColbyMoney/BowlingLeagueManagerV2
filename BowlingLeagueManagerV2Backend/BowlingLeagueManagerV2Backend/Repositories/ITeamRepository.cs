using BowlingLeagueManagerV2Backend.Models;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByIdAsync(long id);
        Task<Team> CreateTeamAsync(Team league);
        Task<Team> UpdateTeamAsync(Team league);
        Task DeleteTeamAsync(long id);
    }
}
