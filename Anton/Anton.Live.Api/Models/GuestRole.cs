using Anton.Live.Api.Models.Base;

namespace Anton.Live.Api.Models
{
    public class GuestRole : UserRole
    {
        public GuestRole() => RoleName = "Guest";

        public override bool CanDelete()
        {
            return false;
        }
    }
}
