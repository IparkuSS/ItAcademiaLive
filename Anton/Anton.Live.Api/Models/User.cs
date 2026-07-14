using Anton.Live.Api.Models.Base;

namespace Anton.Live.Api.Models
{
    public class User
    {
        public string Msg { get; set; } = string.Empty;
        public User(string msg)
        {
            Msg = msg;
        }

    }
}
