using Matvey.Live.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matvey.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly ConcurrentDictionary<string, UserAccount> _accounts = new();

        [HttpPost("create")]
        public IActionResult CreateAccount(string userId, string username, decimal initialBalance = 0)
        {
            if (_accounts.ContainsKey(userId))
                return BadRequest($"Account with ID {userId} already exists");

            var account = new UserAccount(userId, username, initialBalance);
            _accounts[userId] = account;

            return Ok(new { userId, username, balance = account.GetBalance() });
        }

        [HttpGet("{userId}")]
        public IActionResult GetAccount(string userId)
        {
            if (!_accounts.TryGetValue(userId, out var account))
                return NotFound($"Account {userId} not found");

            return Ok(new { account.UserId, account.Username, balance = account.GetBalance() });
        }

        [HttpPost("{userId}/deposit")]
        public IActionResult Deposit(string userId,DepositRequest request)
        {
            if (!_accounts.TryGetValue(userId, out var account))
                return NotFound($"Account {userId} not found");

            try
            {
                account.Deposit(request.Amount);
                return Ok(new TransactionResponse
                {
                    Success = true,
                    CurrentBalance = account.GetBalance(),
                    Message = $"Deposited {request.Amount:C}"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new TransactionResponse
                {
                    Success = false,
                    CurrentBalance = account.GetBalance(),
                    Message = ex.Message
                });
            }
        }

        [HttpPost("{userId}/withdraw")]
        public IActionResult Withdraw(string userId,WithdrawRequest request)
        {
            if (!_accounts.TryGetValue(userId, out var account))
                return NotFound($"Account {userId} not found");

            try
            {
                bool success = account.TryWithdraw(request.Amount, out decimal currentBalance);

                return Ok(new TransactionResponse
                {
                    Success = success,
                    CurrentBalance = currentBalance,
                    Message = success ? $"Withdrew {request.Amount:C}" : "Insufficient funds"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new TransactionResponse
                {
                    Success = false,
                    CurrentBalance = account.GetBalance(),
                    Message = ex.Message
                });
            }
        }
    }
}
