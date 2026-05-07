namespace Anton.Live
{
    class Program
    {
        static void Main()
        {
            //int i = 0;

            //while (i < 5)
            //{
            //    string text = Console.ReadLine();
            //    if (int.TryParse(text, out int number))
            //    {
            //        if (number > 0)
            //            Console.WriteLine("Положительное");
            //        else
            //            Console.WriteLine("Отрицательное");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Не число ");

            //    }
            //    i++;

            double.TryParse(Console.ReadLine(), out double price);
            int.TryParse(Console.ReadLine(), out int count);
            const double discontRate = 0.2;

            try
            {
                double subTotal = price * count;
                double discont = subTotal * discontRate;
                double totalPrice = subTotal - discont;
                Console.WriteLine(totalPrice);
            }
            catch (Exception)
            {

                throw;
            }

            
        }
        }
    }
