using System.Threading.Channels;

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



            //try
            //{
            //    const decimal discontRate = 0.2M;

            //    Console.WriteLine("Введите цену товара");
            //    decimal.TryParse(Console.ReadLine(), out decimal price);

            //    Console.WriteLine("Введите цену товара");
            //    int.TryParse(Console.ReadLine(), out int count);



            //    decimal subTotal = price * count;
            //    decimal discont = subTotal * discontRate;
            //    decimal totalPrice = subTotal - discont;
            //    Console.WriteLine($"Итоговая цена: {totalPrice}");
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("Ошибка");
            //}
            Console.WriteLine("Введите номер дня недели");
            if (!(int.TryParse(Console.ReadLine(), out int day) && day < 1 && day > 7)) { Console.WriteLine("Ошибка!"); }
            switch (day)
            {
                case (1):
                    Console.WriteLine("Сегодня понедельник");
                    break;
                case (2):
                    Console.WriteLine("Сегодня вторник");
                    break;
                case (3):
                    Console.WriteLine("Сегодня среда");
                    break;
                case (4):
                    Console.WriteLine("Сегодня четверг");
                    break;
                case (5):
                    Console.WriteLine("Сегодня пятница");
                    break;
                case (6):
                    Console.WriteLine("Сегодня суббота");
                    break;
                case (7):
                    Console.WriteLine("Сегодня воскресенье");
                    break;
                default:
                    Console.WriteLine("");
                    break;


            }

            


        }
    }
}
