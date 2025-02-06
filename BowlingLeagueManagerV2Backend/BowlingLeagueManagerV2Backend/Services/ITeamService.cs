using BowlingLeagueManagerV2Backend.Models;

namespace BowlingLeagueManagerV2Backend.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();

        // Retrieve a specific team by ID
        Task<Team> GetTeamByIdAsync(long id);

        // Create a new team
        Task<Team> CreateTeamAsync(Team team);

        // Update an existing team
        Task<Team> UpdateTeamAsync(long id, Team updatedTeam);

        // Delete a team by ID
        Task DeleteTeamAsync(long id);
    }
}
