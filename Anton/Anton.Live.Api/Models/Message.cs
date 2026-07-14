namespace Anton.Live.Api.Models
{
    public class Message
    {
        public async Task<string> MessageAsync(CancellationToken cf = default) 
        { 
            await Task.Delay(TimeSpan.FromSeconds(1), cf);
            return "message";
        }
    }
}
