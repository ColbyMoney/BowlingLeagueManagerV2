using BowlingLeagueManagerV2Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(long id);
        Task<Account> GetAccountByUsernameAsync(string username);
        Task<Account> CreateAccountAsync(Account bowler);
        Task<Account> UpdateAccountAsync(Account bowler);
        Task DeleteAccountAsync(long id);
    }
}
