using BowlingLeagueManagerV2Backend.DTOs;
using BowlingLeagueManagerV2Backend.Models;
using BowlingLeagueManagerV2Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingLeagueManagerV2Backend.Controllers
{
    [ApiController]
    [Route("bowlingLeagueManager/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly PasswordHasher<Account> _passwordHasher;

        // Constructor injection for the service
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            _passwordHasher = new PasswordHasher<Account>();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDetails)
        {
            try
            {
                // Try to retrieve the account based on the username
                var account = await _accountService.GetAccountByUsernameAsync(loginDetails.Username);

                if (account == null)
                {
                    return Unauthorized(new { message = "Invalid username or password" });
                }

                // Verify the provided password with the stored hash
                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, loginDetails.Password);

                if (passwordVerificationResult == PasswordVerificationResult.Failed)
                {
                    return Unauthorized(new { message = "Invalid username or password" });
                }

                // At this point, the login is successful. You may return account info or generate a token
                return Ok(account);  // or return a token instead of account data
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // Endpoint to retrieve a specific account by ID
        [HttpGet("get")]
        public async Task<ActionResult<Account>> GetAccountById([FromQuery] long accountId)
        {
            var account = await _accountService.GetAccountByIdAsync(accountId);
            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            var createdAccount = await _accountService.CreateAccountAsync(account, account.PasswordHash); // Call service method to create a new account
            return CreatedAtAction(nameof(CreateAccount), new { id = createdAccount.AccountId }, createdAccount); // Return created account with HTTP status 201 (CREATED)
        }

        // Endpoint to update an existing account
        [HttpPut("update")]
        public async Task<ActionResult<Account>> UpdateAccount([FromQuery] long accountId, [FromBody] Account updatedAccount)
        {
            var existingAccount = await _accountService.GetAccountByIdAsync(accountId);
            if (existingAccount != null)
            {
                var updated = await _accountService.UpdateAccountAsync(accountId, updatedAccount);
                return Ok(updated);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to delete a account
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAccount([FromQuery] long accountId)
        {
            var account = await _accountService.GetAccountByIdAsync(accountId);
            if (account != null)
            {
                await _accountService.DeleteAccountAsync(accountId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
