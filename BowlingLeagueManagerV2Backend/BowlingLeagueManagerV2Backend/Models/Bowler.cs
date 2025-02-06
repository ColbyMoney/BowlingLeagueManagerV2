namespace BowlingLeagueManagerV2Backend.Models
{
    public class Bowler
    {
        public long BowlerId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string BowlerImage { get; set; } = "";
        public string BowlerImageAltText { get; set; } = "";

        public Bowler() { }

        public Bowler(string firstName, string lastName, string image, string imageAltText)
        {
            FirstName = firstName;
            LastName = lastName;
            BowlerImage = image;
            BowlerImageAltText = imageAltText;
        }
    }
}
