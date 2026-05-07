namespace Anton.Live
{
    class Program
    {
        static void Main()
        {
            int i = 0;
            
            while (i < 5)
            {
                string text = Console.ReadLine();
                if (int.TryParse(text, out int number))
                {
                    if (number > 0)
                        Console.WriteLine("Положительное");
                    else
                        Console.WriteLine("Отрицательное");
                }
                else
                {
                    Console.WriteLine("Не число ");

                }
                i++;
            }
        }
    }
}