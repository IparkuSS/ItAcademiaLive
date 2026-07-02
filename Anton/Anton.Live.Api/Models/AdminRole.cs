using Anton.Live.Api.Models.Base;

namespace Anton.Live.Api.Models
{
    public class AdminRole : UserRole
    {
        public AdminRole() => RoleName = "Admin";

        public override bool CanDelete()
        {
            return true;
        }
    }
}
