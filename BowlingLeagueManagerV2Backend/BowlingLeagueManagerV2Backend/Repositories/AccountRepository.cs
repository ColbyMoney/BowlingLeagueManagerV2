using BowlingLeagueManagerV2Backend.Data;
using BowlingLeagueManagerV2Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all bowlers
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        // Retrieve a specific bowler by ID
        public async Task<Account> GetAccountByIdAsync(long id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        // Retrieve an account by username
        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        }

        // Add a new bowler
        public async Task<Account> CreateAccountAsync(Account bowler)
        {
            _context.Accounts.Add(bowler);
            await _context.SaveChangesAsync();
            return bowler;
        }

        // Update an existing bowler
        public async Task<Account> UpdateAccountAsync(Account bowler)
        {
            _context.Accounts.Update(bowler);
            await _context.SaveChangesAsync();
            return bowler;
        }

        // Delete a bowler by ID
        public async Task DeleteAccountAsync(long id)
        {
            var bowler = await _context.Accounts.FindAsync(id);
            if (bowler != null)
            {
                _context.Accounts.Remove(bowler);
                await _context.SaveChangesAsync();
            }
        }
    }
}
