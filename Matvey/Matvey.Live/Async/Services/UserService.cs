using Matvey.Live.Async.Models;

namespace Matvey.Live.Async.Services
{
    public class UserService
    {
        public async Task<User> GetUserAsync()
        {
            return new User { Id = 1, Name = "Иван Петров" };
        }

        public async Task<Settings> GetSettingsAsync()
        {
            return new Settings { Theme = "Тёмная", Language = "ru" };
        }

        public async Task<(User user, Settings settings)> LoadUserAndSettingsAsync()
        {
            Task<User> userTask = GetUserAsync();
            Task<Settings> settingsTask = GetSettingsAsync();

            await Task.WhenAll(userTask, settingsTask);

            User user = await userTask;
            Settings settings = await settingsTask;

            return (user, settings);
        }
    }
}