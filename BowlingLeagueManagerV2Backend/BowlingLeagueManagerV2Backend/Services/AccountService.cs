using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Repositories;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BowlingLeagueManagerV2Backend.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly PasswordHasher<Account> _passwordHasher;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = new PasswordHasher<Account>();
        }

        // Retrieve all accounts
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAccountsAsync();
        }

        // Retrieve a specific account by ID
        public async Task<Account> GetAccountByIdAsync(long id)
        {
            var account = await _accountRepository.GetAccountByIdAsync(id);
            if (account == null)
            {
                throw new Exception($"Account not found with id: {id}");
            }
            return account;
        }

        // Retrieve a specific account by Username
        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _accountRepository.GetAccountByUsernameAsync(username);
        }

        // Create a new account
        public async Task<Account> CreateAccountAsync(Account account, string password)
        {
            account.PasswordHash = _passwordHasher.HashPassword(account, password);
            return await _accountRepository.CreateAccountAsync(account);
        }

        // Update an existing account
        public async Task<Account> UpdateAccountAsync(long id, Account updatedAccount)
        {
            var existingAccount = await _accountRepository.GetAccountByIdAsync(id);
            if (existingAccount != null)
            {
                existingAccount.BowlerId = updatedAccount.BowlerId;
                existingAccount.FirstName = updatedAccount.FirstName;
                existingAccount.LastName = updatedAccount.LastName;
                existingAccount.EmailAddress = updatedAccount.EmailAddress;
                existingAccount.Username = updatedAccount.Username;

                // Check if the password is being updated
                if (!string.IsNullOrEmpty(updatedAccount.PasswordHash) &&
                    _passwordHasher.VerifyHashedPassword(existingAccount, existingAccount.PasswordHash, updatedAccount.PasswordHash) == PasswordVerificationResult.Failed)
                {
                    // Hash the new password if it has changed
                    existingAccount.PasswordHash = _passwordHasher.HashPassword(existingAccount, updatedAccount.PasswordHash);
                }

                // Save the updated account
                return await _accountRepository.UpdateAccountAsync(existingAccount);
            }
            else
            {
                throw new Exception($"Account not found with id {id}");
            }
        }

        // Login functionality with password verification
        public async Task<Account> LoginAsync(string username, string password)
        {
            var account = await _accountRepository.GetAccountByUsernameAsync(username);

            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            // Verify the entered password with the stored hash
            var verificationResult = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, password);

            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid password.");
            }

            return account;
        }

        // Delete a account by ID
        public async Task DeleteAccountAsync(long id)
        {
            await _accountRepository.DeleteAccountAsync(id);
        }
    }
}