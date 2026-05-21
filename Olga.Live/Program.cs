namespace Olga.Live
{
    class Program
    {
        static void Main()
        {
            Numbers numbers = new Numbers(3, 1);
            Console.WriteLine(numbers.GetSum());
        }
    }
}