namespace Matvey.Live.Api.UserRoles.Roles
{
   
    public abstract class UserRole
    {
        public virtual bool CanDelete()
        {
            return false;
        }
    }
}
