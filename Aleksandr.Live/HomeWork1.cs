using System;
using System.Collections.Generic;
using System.Text;

namespace Aleksandr.Live
{
    internal class HomeWork1
    {
        static void Calc(string[] args)
        {

        vvod1:

            Console.Write("Введите первое число: ");
            string? input1 = Console.ReadLine();
            bool result1 = decimal.TryParse(input1, out decimal a);

            if (result1 == false)
            {
                Console.WriteLine("Введено не число");
                goto vvod1;
            }

        vvod2:

            Console.Write("Введите второе число: ");
            string? input2 = Console.ReadLine();
            bool result2 = decimal.TryParse(input2, out decimal b);

            if (result2 == false)
            {
                Console.WriteLine("Введено не число");
                goto vvod2;
            }

            Console.Write("Выберите операцию (+, -, *, /): ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "+":
                    Console.WriteLine($"Результат: {a + b}");
                    break;
                case "-":
                    Console.WriteLine($"Результат: {a - b}");
                    break;
                case "*":
                    Console.WriteLine($"Результат: {a * b}");
                    break;
                case "/":
                    if (b == 0)
                        Console.WriteLine("Ошибка: деление на 0");
                    else
                        Console.WriteLine($"Результат: {a / b}");
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }

        }

        static void AgeStatus(string[] args)
        {

            bool inputCheckError = true;

            Console.WriteLine("Введите возраст");
            string? age = Console.ReadLine();
            bool result = int.TryParse(age, out int parsedAge);

            while (inputCheckError)
            {
                if (result == false || parsedAge > 100 || parsedAge < 1)

                {
                    Console.WriteLine("Неверно, введите цифры от 1 до 100");
                }

                inputCheckError = false;
            }

            if (parsedAge >= 18)
            {
                Console.WriteLine("Человек совершеннолетний.");
            }
            else
            {
                Console.WriteLine("Человек несовершеннолетний.");
            }
        }

        static void Salary(string[] args)
        {
            const int kpi1 = 75;
            const int kpi2 = 90;
            const decimal bonusKpi1 = 0.1M;
            const int bonusKpi2 = 20;

        vvod:

            Console.WriteLine("Введите начисленную зарплату");
            string? salary = Console.ReadLine();
            bool result = decimal.TryParse(salary, out decimal salaryParsed);

            if (result == false)
            {
                Console.WriteLine("Неверное значение");
                goto vvod;
            }

        vvod2:

            Console.WriteLine("Введите KPI");
            string? kpi = Console.ReadLine();
            bool result1 = decimal.TryParse(kpi, out decimal kpiParsed);

            if (result1 == false)
            {
                Console.WriteLine("Неверное значение KPI");
                goto vvod2;
            }

            if (kpiParsed >= kpi2)
            {
                Console.WriteLine($"Бонус: {salaryParsed * bonusKpi2 / 100}");
            }
            else if (kpiParsed >= kpi1 && kpiParsed < kpi2)
            {
                Console.WriteLine($"Бонус: {salaryParsed * bonusKpi1}");
            }
            else
            {
                Console.WriteLine("В этом месяце нет бонуса.");
            }
        }
    }
}
