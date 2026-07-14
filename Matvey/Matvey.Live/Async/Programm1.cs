using Matvey.Live.Async.Services;

namespace Matvey.Live
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var service = new UserService();

            var (user, settings) = await service.LoadUserAndSettingsAsync();

            Console.WriteLine($"Пользователь: {user.Name}");
            Console.WriteLine($"Настройки: тема={settings.Theme}, язык={settings.Language}");
        }
    }
}