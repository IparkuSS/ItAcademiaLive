using Aleksandr.Live.Api.Domains;

namespace Aleksandr.Live.Api.Services.Interfaces
{
    public interface ISettingsService
    {
        Task<Settings> GetSettingsAsync(int userId);
    }
}
