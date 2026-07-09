using System.Text.RegularExpressions;

namespace Aleksandr.Live
{
    class Program
    {
        public static void Main()
        {

            List<string> passwords = new List<string>
        {
            "Pass1word", // Валидный (3 заглавных, 1 цифра, 9 символов)
            "P@ssword1", // Невалидный (всего 1 заглавная)
            "ABCdef12",  // Валидный (3 заглавных, 2 цифры, 8 символов)
            "paSSWord1", // Невалидный (всего 2 заглавные)
            "PASSw1234", // Валидный (4 заглавных, 4 цифры, 9 символов)
            "short"      // Невалидный (короткий, нет цифр, нет заглавных)
        };

            string pattern = @"^(?=.*\d)(?=(?:.*[A-Z]){3,}).{8,}$";
           
            Regex regex = new Regex(pattern);

            foreach (var password in passwords)
            {
                bool isValid = regex.IsMatch(password);
                Console.WriteLine($"Пароль: \"{password}\" - Валиден: {isValid}");
            }
        }
    }
}