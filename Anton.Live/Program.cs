using System.Threading.Channels;

namespace Anton.Live
{
    class Program
    {
        static void Main()
        {

            //Console.WriteLine("Введите номер дня недели");
            //if (!(int.TryParse(Console.ReadLine(), out int day) && day < 1 && day > 7)) { Console.WriteLine("Ошибка!"); }
            //switch (day)
            //{
            //    case (1):
            //        Console.WriteLine("Сегодня понедельник");
            //        break;
            //    case (2):
            //        Console.WriteLine("Сегодня вторник");
            //        break;
            //    case (3):
            //        Console.WriteLine("Сегодня среда");
            //        break;
            //    case (4):
            //        Console.WriteLine("Сегодня четверг");
            //        break;
            //    case (5):
            //        Console.WriteLine("Сегодня пятница");
            //        break;
            //    case (6):
            //        Console.WriteLine("Сегодня суббота");
            //        break;
            //    case (7):
            //        Console.WriteLine("Сегодня воскресенье");
            //        break;
            //    default:
            //        Console.WriteLine("");
            //        break;


            //}

            //int[] array = { 1, 2, 3, 4, 5, -1, 8, 12 };

            //for (int i = 0; i < array.Length; i++)
            //{

            //    if (array[i] < 0)
            //    {

            //        Console.WriteLine($"Номер отрицательного элемента: {i+1}");
            //        break;

            //    }

            int count = default;
            Console.WriteLine("Write word");
            string word = Console.ReadLine();

            foreach (char item in word)
            {
                if (item >= '0' && item <= '9')
                {
                    throw new Exception("number");
                }
                else
                {
                    if (item == 'б') { count++; }
                }


                }

            Console.WriteLine(count);





        }

    }
}
