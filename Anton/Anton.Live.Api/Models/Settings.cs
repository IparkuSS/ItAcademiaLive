namespace Anton.Live.Api.Models
{
    public class Settings
    {
        public string Msg { get; set; } = string.Empty;
        public Settings(string msg)
        {
            Msg = msg;
        }

    }
}
