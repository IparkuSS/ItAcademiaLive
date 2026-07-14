namespace Aleksandr.Live
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Ожидание 1 секунду...");

            string result = await WaitAndGetStringAsync();

            Console.WriteLine(result);
        }

        public static async Task<string> WaitAndGetStringAsync()
        {

            await Task.Delay(1000);

            return "Прошла 1 секунда, вернул строку";
        }
    }
}

