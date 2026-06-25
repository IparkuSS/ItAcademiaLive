using System.Text.RegularExpressions;

namespace Aleksandr.Live.Api.Domains
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
