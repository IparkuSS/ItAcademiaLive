using Aleksandr.Live.Api.Controllers;

namespace Aleksandr.Live.Api.Services
{
    public class AccountService
    {

        private decimal _balance;

        public decimal Balance => _balance;

        private readonly object _lockObj = new();
        
        public decimal GetBalance()
        {

            lock (_lockObj)
            {
                return _balance;
            }

        }
        public void AddFunds(decimal amount)
        {
            lock (_lockObj)
            {
                if (amount <= 0)
                    throw new ArgumentException("Сумма должна быть больше нуля.");

                _balance += amount;
            }
        }
        public void Withdraw(decimal amount)
        {
            lock (_lockObj)
            {
                if (amount <= 0)
                    throw new ArgumentException("Сумма должна быть больше нуля.");

                if (amount > _balance)
                    throw new InvalidOperationException("Недостаточно средств на счете.");

                _balance -= amount;
            }
        }
    }
}
