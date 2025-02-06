using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesService(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        // Retrieve all series
        public async Task<IEnumerable<Series>> GetAllSeriesAsync()
        {
            return await _seriesRepository.GetAllSeriesAsync();
        }

        // Retrieve a specific series by ID
        public async Task<Series> GetSeriesByIdAsync(long id)
        {
            var series = await _seriesRepository.GetSeriesByIdAsync(id);
            if (series == null)
            {
                throw new Exception($"Series not found with id: {id}");
            }
            return series;
        }

        // Create a new series
        public async Task<Series> CreateSeriesAsync(Series series)
        {
            return await _seriesRepository.CreateSeriesAsync(series);
        }

        // Update an existing series
        public async Task<Series> UpdateSeriesAsync(long id, Series updatedSeries)
        {
            var existingSeries = await _seriesRepository.GetSeriesByIdAsync(id);

            if (existingSeries != null)
            {
                existingSeries.BowlerId = updatedSeries.BowlerId;
                existingSeries.Game1 = updatedSeries.Game1;
                existingSeries.Game2 = updatedSeries.Game2;
                existingSeries.Game3 = updatedSeries.Game3;
                existingSeries.SeriesTotal = updatedSeries.SeriesTotal;

                return await _seriesRepository.UpdateSeriesAsync(existingSeries);
            }
            else
            {
                throw new Exception($"Series not found with id: {id}");
            }
        }

        // Delete a series by ID
        public async Task DeleteSeriesAsync(long id)
        {
            await _seriesRepository.DeleteSeriesAsync(id);
        }

        // Get total pins by Bowler ID
        public async Task<int> GetTotalPinsByBowlerIdPerLeagueAsync(long bowlerId, long leagueId)
        {
            return await _seriesRepository.GetTotalPinsByBowlerIdAsync(bowlerId, leagueId);
        }

        // Get total games bowled by Bowler ID
        public async Task<int> GetTotalGamesBowledByBowlerIdPerLeagueAsync(long bowlerId, long leagueId)
        {
            return await _seriesRepository.GetTotalGamesBowledByBowlerIdAsync(bowlerId, leagueId);
        }

        // Get highest game by Bowler ID
        public async Task<int> GetHighestGameByBowlerIdPerLeagueAsync(long bowlerId, long leagueId)
        {
            return await _seriesRepository.GetHighestGameByBowlerIdAsync(bowlerId, leagueId);
        }

        // Get highest series by Bowler ID
        public async Task<int> GetHighestSeriesByBowlerIdPerLeagueAsync(long bowlerId, long leagueId)
        {
            return await _seriesRepository.GetHighestSeriesByBowlerIdAsync(bowlerId, leagueId);
        }
    }
}
