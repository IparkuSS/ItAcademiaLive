using Matvey.Live.Services;

namespace Matvey.Live
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var externalCts = new CancellationTokenSource();

            externalCts.CancelAfter(3000);

            var service = new UserService();

            try
            {
                Console.WriteLine("Загрузка начата...");

                var (user, settings) = await service.LoadUserAndSettingsAsync(externalCts.Token);

                Console.WriteLine($"Пользователь: {user.Name}");
                Console.WriteLine($"Настройки: тема={settings.Theme}, язык={settings.Language}");
                Console.WriteLine("Загрузка успешно завершена!");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция была отменена (таймаут или ручная отмена)");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
        }
    }
}
