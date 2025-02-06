using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public class BowlerService : IBowlerService
    {
        private readonly IBowlerRepository _bowlerRepository;

        public BowlerService(IBowlerRepository bowlerRepository)
        {
            _bowlerRepository = bowlerRepository;
        }

        // Retrieve all bowlers
        public async Task<IEnumerable<Bowler>> GetAllBowlersAsync()
        {
            return await _bowlerRepository.GetAllBowlersAsync();
        }

        // Retrieve a specific bowler by ID
        public async Task<Bowler> GetBowlerByIdAsync(long id)
        {
            var bowler = await _bowlerRepository.GetBowlerByIdAsync(id);
            if (bowler == null)
            {
                throw new Exception($"Bowler not found with id: {id}");
            }
            return bowler;
        }

        // Create a new bowler
        public async Task<Bowler> CreateBowlerAsync(Bowler bowler)
        {
            return await _bowlerRepository.CreateBowlerAsync(bowler);
        }

        // Update an existing bowler
        public async Task<Bowler> UpdateBowlerAsync(long id, Bowler updatedBowler)
        {
            var existingBowler = await _bowlerRepository.GetBowlerByIdAsync(id);
            if (existingBowler != null)
            {
                existingBowler.FirstName = updatedBowler.FirstName;
                existingBowler.LastName = updatedBowler.LastName;
                existingBowler.BowlerImage = updatedBowler.BowlerImage;
                existingBowler.BowlerImageAltText = updatedBowler.BowlerImageAltText;
                // Save the updated bowler
                return await _bowlerRepository.UpdateBowlerAsync(existingBowler);
            }
            else
            {
                throw new Exception($"Bowler not found with id {id}");
            }
        }

        // Delete a bowler by ID
        public async Task DeleteBowlerAsync(long id)
        {
            await _bowlerRepository.DeleteBowlerAsync(id);
        }
    }
}