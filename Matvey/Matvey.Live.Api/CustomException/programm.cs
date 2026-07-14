using Matvey.Live.Api.CustomException.Exceptions;

namespace Matvey.Live.Api.CustomException
{
    public class programm
    {
        class Program
        {
            static void Main()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("=== Кейс 1: Проверка возраста ===");
                try
                {
                    ValidateAge(-5);
                }
                catch (InvalidAgeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine($"Неверный возраст: {ex.InvalidAge}\n");
                }

                Console.WriteLine("=== Кейс 2: Повторные попытки ===");
                try
                {
                    ExecuteWithRetry(3, () =>
                    {
                        if (new Random().Next(1, 10) != 10)
                            throw new Exception("Ошибка соединения");
                        Console.WriteLine("Успешно!");
                    });
                }
                catch (MaxRetryExceededException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine($"Операция: {ex.OperationName}, Попыток: {ex.MaxRetries}\n");
                }

                Console.WriteLine("=== Кейс 3: Конфигурация ===");
                try
                {
                    LoadConfig("Timeout", "не число");
                }
                catch (InvalidConfigurationException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine($"Ключ: {ex.ConfigKey}, Значение: {ex.ConfigValue}\n");
                }
            }


            static void ValidateAge(int age)
            {
                if (age <= 0)
                    throw new InvalidAgeException(age, "Возраст не может быть <= 0");

                if (age > 150)
                    throw new InvalidAgeException(age, "Максимальный возраст 150 лет");

                Console.WriteLine($"Возраст {age} корректен");
            }

            static void ExecuteWithRetry(int maxRetries, Action action)
            {
                for (int attempt = 1; attempt <= maxRetries; attempt++)
                {
                    try
                    {
                        action();
                        return;
                    }
                    catch (Exception ex) when (attempt < maxRetries)
                    {
                        Console.WriteLine($"Попытка {attempt} не удалась: {ex.Message}. Повтор...");
                    }
                }
                throw new MaxRetryExceededException("DBOperation", maxRetries);
            }

            static void LoadConfig(string key, string value)
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new InvalidConfigurationException(key, value, "Ключ не может быть пустым");

                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidConfigurationException(key, value, "Значение не может быть пустым");

                if (key == "Timeout" && !int.TryParse(value, out _))
                    throw new InvalidConfigurationException(key, value, "Timeout должен быть числом");

                Console.WriteLine($"Загружено: {key} = {value}");
            }
        }
    }
}
