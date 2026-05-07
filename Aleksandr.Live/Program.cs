using System.ComponentModel.Design;

namespace Aleksandr.Live
{

    class Program
    {
        static void Main()
        {
            const double DiscountRate = 0.1;
            double subtotal;
            double total;
            int discount;
            int quantity;

            Console.Write("Введите стоимось : ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Введите количество : ");
            int quantityi = int.Parse(Console.ReadLine());


            subtotal = price * quantity;
            discount = subtotal * DiscountRate;
            total = subtotal * DiscountRate;

            {
                Console.WriteLine($"Итоговая стоимость {total}");

            }


        }
    }
}