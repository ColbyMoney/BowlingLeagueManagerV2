using BowlingLeagueManagerV2Backend.DTOs;
using BowlingLeagueManagerV2Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeagueManagerV2Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<BowlerLeagueCombo> BowlerLeagueCombos { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<LeagueDetailsDto> LeagueDetailsDto { get; set; }
        public DbSet<Account> Accounts { get; set; }

        // Add other DbSets for your models here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeagueDetailsDto>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}