using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.Services.Interfaces;

namespace Aleksandr.Live.Api.Services
{
    public class SettingsService : ISettingsService
    {
        public async Task<Settings> GetSettingsAsync(int userId)
        {
            await Task.Delay(300); // Имитация запроса к БД/Редису
            return new Settings(userId, "Dark", "ru-RU");
        }
    }
}
