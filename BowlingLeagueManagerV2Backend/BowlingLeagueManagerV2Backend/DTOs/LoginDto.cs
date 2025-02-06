using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeagueManagerV2Backend.DTOs
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
