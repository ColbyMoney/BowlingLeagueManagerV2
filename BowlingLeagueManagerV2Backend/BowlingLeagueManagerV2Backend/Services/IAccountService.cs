using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();

        // Retrieve a specific account by ID
        Task<Account> GetAccountByIdAsync(long id);

        // Retrieve an account by username
        Task<Account> GetAccountByUsernameAsync(string username);

        // Login
        Task<Account> LoginAsync(string username, string password);

        // Create a new account
        Task<Account> CreateAccountAsync(Account account, string password);

        // Update an existing account
        Task<Account> UpdateAccountAsync(long id, Account updatedAccount);

        // Delete a account by ID
        Task DeleteAccountAsync(long id);
    }
}