namespace BowlingLeagueManagerV2Backend.Models
{
    public class League
    {
        public long LeagueId { get; set; }
        public string LeagueName { get; set; }
        public string LeagueDescription { get; set; }
        public int NumberOfWeeks { get; set; }
        public int HandicapBase { get; set; }
        public int MaxBowlersPerTeam { get; set; }

        public League() { }

        public League(string leagueName, string leagueDescription, int numberOfWeeks, int handicapBase, int maxTeamSize)
        {
            LeagueName = leagueName;
            LeagueDescription = leagueDescription;
            NumberOfWeeks = numberOfWeeks;
            HandicapBase = handicapBase;
            MaxBowlersPerTeam = maxTeamSize;
        }
    }
}
