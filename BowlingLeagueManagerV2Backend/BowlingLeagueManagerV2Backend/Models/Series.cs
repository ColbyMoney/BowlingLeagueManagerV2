namespace BowlingLeagueManagerV2Backend.Models
{
    public class Series
    {
        public long SeriesId { get; set; }
        public long BowlerId { get; set; }
        public long WeekId { get; set; }
        public long LeagueId { get; set; }
        public int Game1 { get; set; } = 0;
        public int Game2 { get; set; } = 0;
        public int Game3 { get; set; } = 0;
        public int SeriesTotal { get; set; } = 0;
        

        public Series() { }

        public Series(long bowlerId, long weekId, long leagueId, int game1, int game2, int game3, int series)
        {
            BowlerId = bowlerId;
            WeekId = weekId;
            LeagueId = leagueId;
            Game1 = game1;
            Game2 = game2;
            Game3 = game3;
            SeriesTotal = series;
        }
    }
}
