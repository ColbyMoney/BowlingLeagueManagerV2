using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Repositories;

namespace BowlingLeagueManagerV2Backend.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;

        public LeagueService(ILeagueRepository leagueRepository, ISeriesRepository seriesRepository)
        {
            _leagueRepository = leagueRepository;
        }

        // Retrieve all leagues
        public async Task<IEnumerable<League>> GetAllLeaguesAsync()
        {
            return await _leagueRepository.GetAllLeaguesAsync();
        }

        // Retrieve a specific league by ID
        public async Task<League> GetLeagueByIdAsync(long id)
        {
            var league = await _leagueRepository.GetLeagueByIdAsync(id);
            if (league == null)
            {
                throw new Exception($"League not found with id: {id}");
            }
            return league;
        }

        // Create a new league
        public async Task<League> CreateLeagueAsync(League league)
        {
            return await _leagueRepository.CreateLeagueAsync(league);
        }

        // Update an existing league
        public async Task<League> UpdateLeagueAsync(long id, League updatedLeague)
        {
            var existingLeague = await _leagueRepository.GetLeagueByIdAsync(id);
            if (existingLeague != null)
            {
                existingLeague.LeagueName = updatedLeague.LeagueName;
                existingLeague.LeagueDescription = updatedLeague.LeagueDescription;
                existingLeague.NumberOfWeeks = updatedLeague.NumberOfWeeks;
                existingLeague.HandicapBase = updatedLeague.HandicapBase;
                existingLeague.MaxBowlersPerTeam = updatedLeague.MaxBowlersPerTeam;
                // Save the updated league
                return await _leagueRepository.UpdateLeagueAsync(existingLeague);
            }
            else
            {
                throw new Exception($"League not found with id {id}");
            }
        }

        // Delete a league by ID
        public async Task DeleteLeagueAsync(long id)
        {
            await _leagueRepository.DeleteLeagueAsync(id);
        }
    }
}
