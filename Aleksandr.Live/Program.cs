namespace Cacl
{
    internal class Program
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

            while (inputCheckError)
            {
                Console.WriteLine("Введите возраст");
                string? age = Console.ReadLine();
                bool result = int.TryParse(age, out int parsedAge);

                if (result == false || parsedAge > 100 || parsedAge < 1)
                {
                    Console.WriteLine("Неверно, введите цифры от 1 до 100");
                }

                inputCheckError = false;
            }

            if (parsedAge >= 18) //Почему ошибка
            {
                Console.WriteLine("Человек совершеннолетний.");
            }
            else
            {
                Console.WriteLine("Человек несовершеннолетний.");
            }
        }

        static void Zarplata(string[] args)
        {
            const int kpi1 = 75;
            const int kpi2 = 90;
            const decimal bonusKpi1 = 0.1M;
            const int bonusKpi2 = 20;

        vvod:

            Console.WriteLine("Введите начисленную зарплату");
            string? zarplata = Console.ReadLine();
            bool result = decimal.TryParse(zarplata, out decimal zarplataParsed);

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
                Console.WriteLine($"Бонус: {zarplataParsed * bonusKpi2 / 100}");
            }
            else if (kpiParsed >= kpi1 && kpiParsed < kpi2)
            {
                Console.WriteLine($"Бонус: {zarplataParsed * bonusKpi1}");
            }
            else
            {
                Console.WriteLine("В этом месяце нет бонуса.");
            }
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Введите пароль ");
            string? password = Console.ReadLine();

            if (password != null && password.Length >= 8)
            {
                Console.WriteLine("Пароль валиден ");
            }
            else
            {
                Console.WriteLine("Пароль слишком короткий");
            }


        }


        static void Main()
        {

            Console.WriteLine("Введите посещаемость");
            double pos = double.Parse(Console.ReadLine()); // Посещаемость в %
            Console.WriteLine("Введите средний бал");
            double mid = double.Parse(Console.ReadLine()); // Средний балл
            bool hasDebts = false;      // Долги
            bool hasOverride = false;   // override
            bool Dopusk = false;

            bool Dop = (pos >= 70) && (mid >= 60) && (!hasDebts);

            if (Dop || hasOverride)
            {
                Dopusk = true;
            }


            if (Dopusk)
            {
                Console.WriteLine("Студент допущен.");
            }
            else
            {
                Console.WriteLine("Студент не допущен.");
            }

            static void DefectRate(string[] args)
            {

                double defectRate = 3; // процент брака
                double temp = 92;      // температура
                double humidity = 75;  // влажность

                bool emergencySignal = false; // аварийный сигнал

                if (defectRate >= 5 || temp >= 95 || humidity >= 80 || emergencySignal)
                {
                    Console.WriteLine("REJECT");
                }
                else if (defectRate >= 2 || temp >= 90 || humidity >= 70)
                {
                    Console.WriteLine("RECHECK");
                }
                else
                {
                    Console.WriteLine("ACCEPT");
                }

            }

            static void Main(string[] args)
            {
                int age = 30;
                double income = 260000; //доход
                bool badCreditStory = true;

                if (age >= 21 && age <= 60 && income >= 250000 && badCreditStory)
                {
                    Console.WriteLine("APPROVED");
                }
                else
                {
                    Console.WriteLine("REJECTED");
                }

            }

        }
    }
}
