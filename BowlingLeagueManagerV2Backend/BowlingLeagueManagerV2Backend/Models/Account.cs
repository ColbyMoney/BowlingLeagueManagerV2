using System.Text;
using System.Security.Cryptography;

namespace BowlingLeagueManagerV2Backend.Models
{
    public class Account
    {
        public long AccountId { get; set; }
        public long BowlerId { get; set; } = -1;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string GUID { get; set; } = Guid.NewGuid().ToString();

        public Account() { }

        public Account(string firstName, string lastName, string emailAddress, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Username = username;
            PasswordHash = HashPassword(password);
            GUID = Guid.NewGuid().ToString();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
