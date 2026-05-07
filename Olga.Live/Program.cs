namespace Olga.Live
{
    class Program
    {
        static void Main()
        {
            //int userAge = 25;
            //decimal productPrice = 99.99m;
            //bool isPaid = false;
            //char firstLetterName = 'O';

            Console.WriteLine("Enter number");
            var msg = Console.ReadLine();
            bool isNumber = int.TryParse(msg, out var value);
            if (isNumber)
            {
                if (value > 0)
                {
                    Console.WriteLine("Number positive");
                }
                else { Console.WriteLine("Number negative"); }
            }
            else {
                Console.WriteLine("Not number");
            }


        }
    }
}