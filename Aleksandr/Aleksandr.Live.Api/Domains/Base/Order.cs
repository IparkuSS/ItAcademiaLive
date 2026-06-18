namespace Aleksandr.Live.Api.Domains.Base
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
