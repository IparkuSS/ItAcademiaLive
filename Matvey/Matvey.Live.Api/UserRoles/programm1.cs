using Matvey.Live.Api.UserRoles.Models1;
using Matvey.Live.Api.UserRoles.Roles;

namespace Matvey.Live.Api.UserRoles
{
    class programm1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            User admin = new User("Иван Петров", new AdminRole());

            User guest = new User("Анна Сидорова", new GuestRole());

            admin.ShowPermissions();
            guest.ShowPermissions();

            Console.WriteLine("\n=== Проверка удаления ===");

            if (admin.Role.CanDelete())
            {
                Console.WriteLine($"{admin.Name} успешно удалил запись");
            }

            if (!guest.Role.CanDelete())
            {
                Console.WriteLine($"{guest.Name} не может удалить запись");
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
