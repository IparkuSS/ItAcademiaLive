namespace Aleksandr.Live
{
    class Program
    {
        public static void Main()
        {

            UserRole admin = new AdminRole();
            UserRole guest = new GuestRole();

            bool adminCanDelete = admin.CanDelete();
            Console.WriteLine($"Администратор может удалять: {adminCanDelete}");

            bool guestCanDelete = guest.CanDelete();
            Console.WriteLine($"Гость может удалять: {guestCanDelete}");
        }
    }
}