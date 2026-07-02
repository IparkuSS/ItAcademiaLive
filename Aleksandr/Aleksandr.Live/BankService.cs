namespace Aleksandr.Live
{
    public class BankService
    {

        public void Withdraw(decimal amount)
        {
            decimal balance = 500.00m;

            if (amount > balance)
            {
                throw new InsufficientFundsException(balance, amount);
            }
            //Логика, если всё хорошо.
        }

        public void RegisterUser(string username, string password)
        {
            if (password.Length < 6)
            {
                throw new InvalidPasswordException(password, "Длина пароля меньше 6 символов!");
            }
            //Логика, если всё хорошо.
        }

        public void GetClientData()
        {
            try
            {
                throw new Exception("Сервер БД временно недоступен");
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Не удалось загрузить данные клиента.", ex);
            }
        }
    }
}
