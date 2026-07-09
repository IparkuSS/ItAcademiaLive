namespace Matvey.Live.Api
{
    public class BankAccount
    {
        private decimal _balance;
        private readonly object _lock = new object();

        public BankAccount(decimal initialBalance = 0)
        {
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Сумма пополнения не может быть отрицательной");

            lock (_lock)
            {
                _balance += amount;
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Пополнение: +{amount}, Баланс: {_balance}");
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Сумма снятия не может быть отрицательной");

            lock (_lock)
            {
                if (_balance < amount)
                {
                    Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Недостаточно средств. Баланс: {_balance}, Запрос: {amount}");
                    return false;
                }

                _balance -= amount;
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Снятие: -{amount}, Баланс: {_balance}");
                return true;
            }
        }

        public decimal GetBalance()
        {
            lock (_lock)
            {
                return _balance;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var account = new BankAccount(1000);

            // Создаем несколько потоков для тестирования
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 3; j++)
                    {
                        account.Deposit(100);
                        Thread.Sleep(10);
                    }
                });
            }

            for (int i = 5; i < 10; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 3; j++)
                    {
                        account.Withdraw(50);
                        Thread.Sleep(10);
                    }
                });
            }

            foreach (var t in threads)
                t.Start();

            foreach (var t in threads)
                t.Join();

            Console.WriteLine($"\nИтоговый баланс: {account.GetBalance()}");
        }
    }
}
