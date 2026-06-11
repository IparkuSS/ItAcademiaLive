namespace Matvey.Live.Api.Services
{
    public class UserAccount
    {
        private decimal _balance;
        private readonly object _lockObject = new object();

        public string UserId { get; }
        public string Username { get; }

        public UserAccount(string userId, string username, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId cannot be empty", nameof(userId));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty", nameof(username));

            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative", nameof(initialBalance));

            UserId = userId;
            Username = username;
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive", nameof(amount));

            lock (_lockObject)
            {
                _balance += amount;
            }
        }

        public bool TryWithdraw(decimal amount, out decimal currentBalance)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive", nameof(amount));

            lock (_lockObject)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    currentBalance = _balance;
                    return true;
                }

                currentBalance = _balance;
                return false;
            }
        }

        public decimal GetBalance()
        {
            lock (_lockObject)
            {
                return _balance;
            }
        }

        public override string ToString()
        {
            return $"User: {Username} (ID: {UserId}), Balance: {GetBalance():C}";
        }
    }
}
