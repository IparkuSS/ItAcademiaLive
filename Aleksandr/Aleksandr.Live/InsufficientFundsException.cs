namespace Aleksandr.Live
{
    public class InsufficientFundsException : Exception
    {
        public decimal CurrentBalance { get; }
        public decimal RequestedAmount { get; }

        public InsufficientFundsException(decimal balance, decimal amount)
            : base($"Недостаточно средств. Текущий баланс: {balance}, Запрошено: {amount}")
        {
            CurrentBalance = balance;
            RequestedAmount = amount;
        }
    }
}
