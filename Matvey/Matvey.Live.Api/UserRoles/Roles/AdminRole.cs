namespace Matvey.Live.Api.UserRoles.Roles
{
    public class AdminRole : UserRole
    {
        public override bool CanDelete()
        {
            Console.WriteLine("Администратор: удаление разрешено");
            return true;
        }
    }
}