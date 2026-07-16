using Aleksandr.Live.Api.Domains;

namespace Aleksandr.Live.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userId, CancellationToken ct);
    }
}
