namespace Anton.Live.Api.Services;
using Anton.Live.Api.Models;

public class DataService
{
    public async Task<User> LoadUserAsync(CancellationToken cf = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cf);
        return new User("Юзер");
    }

    public async Task<Settings> LoadSettingsAsync(CancellationToken cf = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cf);
        return new Settings("Настройки");
    }
}