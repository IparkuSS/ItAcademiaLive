using System;
using System.Collections.Generic;
using System.Text;

namespace Aleksandr.Live
{
    internal class HomeWork2
    {
        static void Ishop(string[] args)
        {
            decimal amount = 10000; //Сумма заказа
            bool isVip = false;
            bool isFirstOrder = false;
            bool hasPromo = true;
            decimal discont = 0;
            int discontCounter = 0;
            decimal delivery = 0;

            if (isVip)
            {
                discont += 7;
                discontCounter++;
            }

            if (isFirstOrder)
            {
                discont += 5;
                discontCounter++;
            }

            if (hasPromo)
            {
                discont += 10;
                discontCounter++;
            }

            if (discont > 20)
            {
                discont = 20;
            }

            if (amount >= 15000)
            {
                delivery = 0;
            }
            else
            {
                delivery = 1200;
            }

            switch (discontCounter)
            {
                case 0:
                    Console.WriteLine("Без скидок.");
                    break;
                case 1:
                    Console.WriteLine("Только одна скидка.");
                    break;
                case 3:
                    Console.WriteLine("Все скидки.");
                    break;
            }

            Console.WriteLine($"Итоговая скидка: {discont}%");
            Console.WriteLine($"Стоимость доставки: {delivery}");
            Console.WriteLine($"Финальная сумма к оплате: {amount * (1 - discont / 100) + delivery}");

            if (amount == 15000)
            {
                Console.WriteLine("Заказ на границе 15000.");
            }
        }

        static void Salary2(string[] args)
        {
            decimal dayHours = 100;
            decimal nightHours = 50;
            decimal dayRate = 50;
            decimal nightRate = 80;
            decimal gross = 0;
            decimal bonus = 0;

            bool weekendShift = true;

            decimal baseSalary = dayHours * dayRate + nightHours * nightRate;

            if ((dayHours + nightHours) > 160)
            {
                decimal overHours = nightHours + dayHours - 160;
                gross = baseSalary + overHours * dayRate * 1.5M;
            }
            else
            {
                gross = baseSalary;
            }

            if (weekendShift)
            {
                bonus = baseSalary * 0.5M;
            }

            gross += bonus;

            decimal net = gross * 0.9M;

            Console.WriteLine($"До налога: {gross}.");
            Console.WriteLine($"После налога: {net}.");

            switch (dayHours + nightHours)
            {
                case 160:
                    Console.WriteLine("160 часов.");
                    break;
                case > 160:
                    Console.WriteLine("Более 160 часов.");
                    break;
                default:
                    Console.WriteLine("Менее 160 часов.");
                    break;
            }
        }


    }
}
