using Anton.Live.Api.Exeptions;
using Anton.Live.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anton.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Иван", Age = 25, Email = "ivan@mail.com" },
        new User { Id = 2, Name = "Петр", Age = 30, Email = "petr@mail.com" }
    };

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                    throw new EmptyNameException();

                if (user.Age < 0 || user.Age > 100)
                    throw new InvalidAgeException(user.Age);

                if (!user.Email.Contains("@"))
                    throw new InvalidEmailException(user.Email);

                user.Id = _users.Count + 1;
                _users.Add(user);

                return Ok(new { Message = "Пользователь создан", User = user });
            }
            catch (EmptyNameException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidAgeException ex)
            {
                return BadRequest(new { Error = ex.Message, InvalidAge = ex.Age });
            }
            catch (InvalidEmailException ex)
            {
                return BadRequest(new { Error = ex.Message, InvalidEmail = ex.Email });
            }
        }

        [HttpGet("search")]
        public IActionResult SearchByEmail([FromQuery] string email)
        {
            try
            {
                if (!email.Contains("@"))
                    throw new InvalidEmailException(email);

                var user = _users.FirstOrDefault(u => u.Email == email);

                if (user == null)
                    return NotFound(new { Message = $"Пользователь с email {email} не найден" });

                return Ok(user);
            }
            catch (InvalidEmailException ex)
            {
                return BadRequest(new { Error = ex.Message, InvalidEmail = ex.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(new)
            }
        }
    }

}

