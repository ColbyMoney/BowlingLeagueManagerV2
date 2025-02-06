using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all teams
        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        // Retrieve a specific team by ID
        public async Task<Team> GetTeamByIdAsync(long id)
        {
            return await _context.Teams.FindAsync(id);
        }

        // Add a new team
        public async Task<Team> CreateTeamAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        // Update an existing team
        public async Task<Team> UpdateTeamAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }

        // Delete a team by ID
        public async Task DeleteTeamAsync(long id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }
    }
}
