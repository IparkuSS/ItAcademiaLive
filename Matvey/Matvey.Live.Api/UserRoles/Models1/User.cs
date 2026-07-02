using Matvey.Live.Api.UserRoles.Roles;

namespace Matvey.Live.Api.UserRoles.Models1
{
   
    public class User
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }

        public User(string name, UserRole role)
        {
            Name = name;
            Role = role;
        }

        public void ShowPermissions()
        {
            Console.WriteLine($"\nПользователь: {Name}");
            Console.WriteLine($"Роль: {Role.GetType().Name}");
            Console.WriteLine($"Может удалять: {(Role.CanDelete() ? "Да" : "Нет")}");
        }
    }
}

