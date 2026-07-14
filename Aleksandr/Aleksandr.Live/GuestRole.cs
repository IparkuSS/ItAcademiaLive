namespace Aleksandr.Live
{
    public class GuestRole : UserRole
    {
        public override bool CanDelete()
        {
            return false;
        }
    }
}
