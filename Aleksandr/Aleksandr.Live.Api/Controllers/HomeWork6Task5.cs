using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aleksandr.Live.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _account;
        public AccountController(IAccountService account)
        {
            _account = account;
        }

        [HttpGet("balance")]
        public ActionResult<decimal> GetBalance()
        {
            var balance = _account.GetBalance();
            return Ok(new {Balance = _account.GetBalance() });
        }

        [HttpPost("balance")]
        public ActionResult Deposit([FromBody] decimal deposit)
        {
            if (_account.AddFunds(deposit))
            {
               return Ok(new { Message = "Депозит успешно внесен", NewBalance = _account.GetBalance() });
            }
            else
            {
                return BadRequest("Invalid operation");

            }
        }
        [HttpDelete("balance")]

        public ActionResult Withdraw([FromBody] decimal amount)
        {
            bool isSuccess = _account.Withdraw(amount);

            if (!isSuccess)
            {
                return BadRequest(new { Message = "Не удалось выполнить операцию. Недостаточно средств или сумма указана неверно." });
            }

            return Ok(new { Message = "Средства успешно сняты", NewBalance = _account.GetBalance() });
        }
    }
}

