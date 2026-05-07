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

            

            try
            {
                const decimal discontRate = 0.2M;

                Console.WriteLine("Введите цену товара");
                decimal.TryParse(Console.ReadLine(), out decimal price);

                Console.WriteLine("Введите цену товара");
                int.TryParse(Console.ReadLine(), out int count);

               

                decimal subTotal = price * count;
                decimal discont = subTotal * discontRate;
                decimal totalPrice = subTotal - discont;
                Console.WriteLine($"Итоговая цена: {totalPrice}");
            }
            catch (Exception)
            {

                Console.WriteLine("Ошибка");
            }
            
            
        }
        }
    }
