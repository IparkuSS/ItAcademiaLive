using Anton.Live.Api.Models;
using Anton.Live.Api.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace Anton.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Админ Иван", Role = new AdminRole() },
        new User { Id = 2, Name = "Гость Петр", Role = new GuestRole() },
        new User { Id = 3, Name = "Обычный ваня", Role = new UserRole() }
    };

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromQuery] int executorId)
        {
            var executor = _users.FirstOrDefault(u => u.Id == executorId);
            if (executor == null)
                return NotFound(new { Error = "кто удаляет не найден" });

            var target = _users.FirstOrDefault(u => u.Id == id);
            if (target == null)
                return NotFound(new { Error = "Пользователь для удаления не найден" });

            if (!executor.Role.CanDelete())
            {
                return StatusCode(403, new
                {
                    Error = $"Роль '{executor.Role.RoleName}' не имеет прав на удаление",
                    CanDelete = executor.Role.CanDelete()
                });
            }

            _users.Remove(target);
            return Ok(new { Message = $"Пользователь '{target.Name}' удалён пользователем '{executor.Name}'" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _users.Select(u => new
            {
                u.Name,
                Role = u.Role.RoleName,
                CanDelete = u.Role.CanDelete()
            });
            return Ok(result);
        }
    }

}

