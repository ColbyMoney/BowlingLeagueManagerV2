namespace BowlingLeagueManagerV2Backend.Models
{
    public class Team
    {
        public long TeamId { get; set; }
        public long LeagueId { get; set; }
        public string TeamName { get; set; }
        public int PointsWon { get; set; }
        public int PointsLost { get; set; }
        public int TeamAverage {  get; set; }
        public int TeamHandicap { get; set; }

        public Team() { }

        public Team(long leagueId, string teamName)
        {
            LeagueId = leagueId;
            TeamName = teamName;
            PointsWon = 0;
            PointsLost = 0;
            TeamAverage = 0;
            TeamHandicap = 0;
        }
    }
}
