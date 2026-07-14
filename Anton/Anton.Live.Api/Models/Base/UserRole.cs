namespace Anton.Live.Api.Models.Base
{
    public class UserRole
    {
        public string RoleName { get; set; } = "User";

        public virtual bool CanDelete()
        {
            return false;
        }
    }
}
