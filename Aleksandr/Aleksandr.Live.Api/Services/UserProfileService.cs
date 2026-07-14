using Aleksandr.Live.Api.DTO;
using Aleksandr.Live.Api.Services.Interfaces;

namespace Aleksandr.Live.Api.Services
{
    public class UserProfileService(IUserService userService, ISettingsService settingsService)
    {
        public async Task<UserProfileDto> GetUserProfileAsync(int userId, CancellationToken ct)
        {
            // Создаем связанный токен. Он отменится, если отменится внешний ct 
            // ИЛИ если мы вызовем cts.Cancel() при ошибке.
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);

            // Для отмены всех задач при падении одной из них
            async Task<T> MonitorTask<T>(Task<T> task)
            {
                try
                {
                    return await task;
                }
                catch
                {
                    cts.Cancel(); // Отменяем все остальные связанные задачи
                    throw;
                }
            }

            try
            {
                // Передаем внутренний токен 'cts.Token' в оба метода
                var userTask = MonitorTask(userService.GetUserAsync(userId, cts.Token));
                var settingsTask = MonitorTask(settingsService.GetSettingsAsync(userId, cts.Token));

                // Ожидаем завершения обеих операций
                await Task.WhenAll(userTask, settingsTask);

                return new UserProfileDto(await userTask, await settingsTask);
            }
            catch (Exception)
            {
                // Если внешний токен был отменен пользователем, выбрасываем OperationCanceledException
                ct.ThrowIfCancellationRequested();

                // В противном случае пробрасываем исходную ошибку, которая вызвала отмену
                throw;
            }
        }
    }
}