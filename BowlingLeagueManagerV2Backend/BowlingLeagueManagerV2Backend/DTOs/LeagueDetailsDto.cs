using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeagueManagerV2Backend.DTOs
{
    public class LeagueDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BowlerImage { get; set; }
        public string BowlerImageAltText { get; set; }
        public long BowlerId { get; set; }
        public long LeagueId { get; set; }
        public long TeamId { get; set; }
        public int TotalPins { get; set; }
        public int TotalGamesBowled { get; set; }
        public int Average { get; set; }
        public int HighestGame { get; set; }
        public int HighestSeries { get; set; }
        public string TeamName { get; set; }
        public string LeagueName { get; set; }
        public string LeagueDescription { get; set; }
    }
}
