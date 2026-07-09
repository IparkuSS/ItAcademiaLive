using System.Text.RegularExpressions;

namespace Matvey.Live.Api
{
    public class PasswordValidator
    {
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length < 8)
                return false;

            if (!Regex.IsMatch(password, @"\d"))
                return false;

            int upperCount = Regex.Matches(password, @"[A-Z]").Count;
            if (upperCount < 3)
                return false;

            return true;
        }
    }

    class Program1
    {
        static void Main()
        {
            string[] passwords = new string[6];

            Console.WriteLine("Введите 6 паролей для проверки:\n");

            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Пароль #{i + 1}: ");
                passwords[i] = Console.ReadLine() ?? string.Empty;
            }

            Console.WriteLine("\nРезультаты\n");

            foreach (string pwd in passwords)
            {
                bool isValid = PasswordValidator.IsValidPassword(pwd);
                Console.WriteLine($"Пароль \"{pwd}\" - {(isValid ? "ВАЛИДНЫЙ" : "НЕВАЛИДНЫЙ")}");
            }
        }
    }
}