using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public class BowlerLeagueComboService : IBowlerLeagueComboService
    {
        private readonly IBowlerLeagueComboRepository _bowlerLeagueComboRepository;
        private readonly ISeriesRepository _seriesRepository;

        public BowlerLeagueComboService(IBowlerLeagueComboRepository bowlerLeagueComboRepository, ISeriesRepository seriesRepository)
        {
            _bowlerLeagueComboRepository = bowlerLeagueComboRepository;
            _seriesRepository = seriesRepository;
        }

        // Retrieve all bowlers
        public async Task<IEnumerable<BowlerLeagueCombo>> GetAllBowlerLeagueCombosAsync()
        {
            return await _bowlerLeagueComboRepository.GetAllBowlerLeagueCombosAsync();
        }

        // Retrieve a specific bowler by ID
        public async Task<BowlerLeagueCombo> GetBowlerLeagueComboByIdAsync(long id)
        {
            var bowler = await _bowlerLeagueComboRepository.GetBowlerLeagueComboByIdAsync(id);
            if (bowler == null)
            {
                throw new Exception($"Bowler League Combo not found with id: {id}");
            }
            return bowler;
        }

        // Create a new bowler
        public async Task<BowlerLeagueCombo> CreateBowlerLeagueComboAsync(BowlerLeagueCombo bowlerLeagueCombo)
        {
            return await _bowlerLeagueComboRepository.CreateBowlerLeagueComboAsync(bowlerLeagueCombo);
        }

        // Update an existing bowler
        public async Task<BowlerLeagueCombo> UpdateBowlerLeagueComboAsync(long id, BowlerLeagueCombo updatedBowlerLeagueCombo)
        {
            var existingBowlerLeagueCombo = await _bowlerLeagueComboRepository.GetBowlerLeagueComboByIdAsync(id);
            if (existingBowlerLeagueCombo != null)
            {
                existingBowlerLeagueCombo.BowlerId = updatedBowlerLeagueCombo.BowlerId;
                existingBowlerLeagueCombo.LeagueId = updatedBowlerLeagueCombo.LeagueId;
                existingBowlerLeagueCombo.TeamId = updatedBowlerLeagueCombo.TeamId;
                // Save the updated bowler
                return await _bowlerLeagueComboRepository.UpdateBowlerLeagueComboAsync(existingBowlerLeagueCombo);
            }
            else
            {
                throw new Exception($"Bowler not found with id {id}");
            }
        }

        // Delete a bowler by ID
        public async Task DeleteBowlerLeagueComboAsync(long id)
        {
            await _bowlerLeagueComboRepository.DeleteBowlerLeagueComboAsync(id);
        }

        // Update a bowler's highest game and series
        public async Task UpdateBowlerLeagueComboStatsAsync(long bowlerId, long leagueId)
        {
            var totalPins = await _seriesRepository.GetTotalPinsByBowlerIdAsync(bowlerId, leagueId);
            var totalGamesBowled = await _seriesRepository.GetTotalGamesBowledByBowlerIdAsync(bowlerId, leagueId);
            var highestGame = await _seriesRepository.GetHighestGameByBowlerIdAsync(bowlerId, leagueId);
            var highestSeries = await _seriesRepository.GetHighestSeriesByBowlerIdAsync(bowlerId, leagueId);


            //write a method to get the bowlerleaguecomboid from the bowlerid and leagueid
            var bowlerLeagueCombo = await _bowlerLeagueComboRepository.GetBowlerLeagueComboByBowlerAndLeagueIdAsync(bowlerId, leagueId);
            if (bowlerLeagueCombo == null)
            {
                throw new Exception("Bowler league combo not found");
            }

            bowlerLeagueCombo.TotalPins = totalPins;
            bowlerLeagueCombo.TotalGamesBowled = totalGamesBowled;
            bowlerLeagueCombo.Average = totalPins / totalGamesBowled;
            bowlerLeagueCombo.HighestGame = highestGame;
            bowlerLeagueCombo.HighestSeries = highestSeries;

            await _bowlerLeagueComboRepository.UpdateBowlerLeagueComboAsync(bowlerLeagueCombo);
        }
    }
}
