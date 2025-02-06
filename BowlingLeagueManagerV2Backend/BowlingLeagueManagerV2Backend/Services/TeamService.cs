using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Repositories;

namespace BowlingLeagueManagerV2Backend.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // Retrieve all teams
        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _teamRepository.GetAllTeamsAsync();
        }

        // Retrieve a specific team by ID
        public async Task<Team> GetTeamByIdAsync(long id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);
            if (team == null)
            {
                throw new Exception($"Team not found with id: {id}");
            }
            return team;
        }

        // Create a new team
        public async Task<Team> CreateTeamAsync(Team team)
        {
            return await _teamRepository.CreateTeamAsync(team);
        }

        // Update an existing team
        public async Task<Team> UpdateTeamAsync(long id, Team updatedTeam)
        {
            var existingTeam = await _teamRepository.GetTeamByIdAsync(id);
            if (existingTeam != null)
            {
                existingTeam.TeamName = updatedTeam.TeamName;
                existingTeam.LeagueId = updatedTeam.LeagueId;
                // Save the updated team
                return await _teamRepository.UpdateTeamAsync(existingTeam);
            }
            else
            {
                throw new Exception($"Team not found with id {id}");
            }
        }

        // Delete a team by ID
        public async Task DeleteTeamAsync(long id)
        {
            await _teamRepository.DeleteTeamAsync(id);
        }
    }
}
