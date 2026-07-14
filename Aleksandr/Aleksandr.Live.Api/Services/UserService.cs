using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.Services.Interfaces;

namespace Aleksandr.Live.Api.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserAsync(int userId)
        {
            await Task.Delay(500); // Имитация запроса к БД/API
            return new User(userId, "Иван Иванов", "ivan@example.com");
        }
    }
}