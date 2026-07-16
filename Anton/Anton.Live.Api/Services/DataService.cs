namespace Anton.Live.Api.Services;
using Anton.Live.Api.Models;

public class DataService
{
    public async Task<User> LoadUserAsync(CancellationToken ct = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), ct);
        return new User("Юзер");
    }

    public async Task<Settings> LoadSettingsAsync(CancellationToken ct = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), ct);
        return new Settings("Настройки");
    }
}