namespace Matvey.Live
{
    public class MyService 
    {
        public async Task<string> WaitAndReturnStringAsync()
        {
            await Task.Delay(1000);
            return "Проверка 1 секунды";
        }
    }
}