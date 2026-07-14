namespace Aleksandr.Live
{
    public class AdminRole : UserRole
    {
        public override bool CanDelete()
        {
            return true;
        }
    }
}
