using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anton.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostRequestIdsController : ControllerBase
    {
        private static UserAccount _account = new UserAccount();

        [HttpGet]
        public IActionResult GetBalance()
        {
            return Ok(_account.GetBalance());
        }
        [HttpPost("deposit")]
        public IActionResult Deposit([FromBody] int amount)
        {
            _account.Deposit(amount);
            return Ok(_account.GetBalance());
        }
        [HttpPost("withdraw")]
        public IActionResult Withdraw([FromBody] int amount)
        {
            if (!_account.TryWithdraw(amount))
                return BadRequest("Недостаточно средств");

            return Ok(_account.GetBalance());
        }
        

        public class UserAccount
        {
            private decimal balance;

            public UserAccount()
            {
                balance = 0;
            }
            
            public decimal GetBalance()
            {
                return balance;
            }
            
            public void Deposit(decimal amount)
            {
                if (IsValidAmount(amount))
                {
                    balance += amount;
                }
            }

            public bool TryWithdraw(decimal amount)
            {
                if (CanWithdraw(amount))
                {
                    balance -= amount;
                    return true;
                }
                return false;
            }

            private bool IsValidAmount(decimal amount)
            {
                return amount > 0;
            }

            private bool CanWithdraw(decimal amount)
            {
                return IsValidAmount(amount) && balance >= amount;
            }
        }
    }
}

