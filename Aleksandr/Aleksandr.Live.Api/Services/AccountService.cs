using Aleksandr.Live.Api.Controllers;

namespace Aleksandr.Live.Api.Services
{
    public class AccountService
    {

        private decimal _balance;

        public decimal Balance => _balance;
        public decimal GetBalance()
        {

            return _balance;

        }
        public void AddFunds(decimal amount)
        {
            _balance += amount;
        }
        public bool Withdraw(decimal withdraw)
        {
            if (withdraw > _balance)
            {
                return false;
            }
            else
            {
                _balance -= withdraw;

                return true;
            }
        }
    }
}
