namespace Matvey.Live
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите свое число");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number > 0)
                {
                    Console.WriteLine("Число положительное1");
                }
                else
                {
                    Console.WriteLine("Число отрицательное123");
                }
                return;
            }

        }
    }
}