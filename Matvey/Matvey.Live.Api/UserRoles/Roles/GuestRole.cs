namespace Matvey.Live.Api.UserRoles.Roles
{
    public class GuestRole : UserRole
    {
        public override bool CanDelete()
        {
            Console.WriteLine("Гость: удаление запрещено");
            return false;
        }
    }
}