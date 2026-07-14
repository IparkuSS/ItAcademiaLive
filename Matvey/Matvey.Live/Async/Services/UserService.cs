using Matvey.Live.Async.Models;

namespace Matvey.Live.Services
{
    public class UserService
    {
        public async Task<User> GetUserAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1500, cancellationToken);

            return new User { Id = 1, Name = "Иван Петров" };
        }

        public async Task<Settings> GetSettingsAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(2000, cancellationToken);
            return new Settings { Theme = "Тёмная", Language = "ru" };
        }

        public async Task<(User user, Settings settings)> LoadUserAndSettingsAsync(
            CancellationToken cancellationToken = default)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            var ct = cts.Token;

            try
            {
                Task<User> userTask = GetUserAsync(ct);
                Task<Settings> settingsTask = GetSettingsAsync(ct);

                await Task.WhenAll(userTask, settingsTask).ConfigureAwait(false);

                return (userTask.Result, settingsTask.Result);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                await cts.CancelAsync();

                throw new InvalidOperationException(
                    $"Ошибка при загрузке данных: {ex.Message}", ex);
            }
        }
    }
}