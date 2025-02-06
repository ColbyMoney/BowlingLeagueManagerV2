namespace BowlingLeagueManagerV2Backend.Models
{
    //this model stores stats for each bowler per each league separately
    public class BowlerLeagueCombo
    {
        public long BowlerLeagueComboId { get; set; }
        public long BowlerId { get; set; }
        public long LeagueId { get; set; }
        public long TeamId { get; set; }
        public int TotalPins { get; set; } = 0;
        public int TotalGamesBowled { get; set; } = 0;
        public int Average { get; set; } = 0;
        public int HighestGame { get; set; } = 0;
        public int HighestSeries { get; set; } = 0;

        public BowlerLeagueCombo() { }

        public BowlerLeagueCombo(long bowlerId, long leagueId, long teamId)
        {
            BowlerId = bowlerId;
            LeagueId = leagueId;
            TeamId = teamId;
            TotalPins = 0;
            TotalGamesBowled = 0;
            Average = 0;
            HighestGame = 0;
            HighestSeries = 0;
        }
    }
}
