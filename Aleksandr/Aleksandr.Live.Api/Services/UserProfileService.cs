using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.DTO;
using Aleksandr.Live.Api.Services.Interfaces;

namespace Aleksandr.Live.Api.Services
{
    public class UserProfileService(IUserService userService, ISettingsService settingsService)
    {
        public async Task<UserProfileDto> GetUserProfileAsync(int userId)
        {
            // 1. Обе задачи параллельно
            Task<User> userTask = userService.GetUserAsync(userId);
            Task<Settings> settingsTask = settingsService.GetSettingsAsync(userId);

            // 2. Ожидаем завершения обеих задач
            await Task.WhenAll(userTask, settingsTask);

            // 3. Собираем результат в общую DTO
            return new UserProfileDto(await userTask, await settingsTask);
        }
    }
}