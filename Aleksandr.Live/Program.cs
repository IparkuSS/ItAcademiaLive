namespace Cacl //HomeWork1
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


        static void Main(string[] args) //ClassWork
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

            double pos = 50; // Посещаемость в %
            double mid = 5; // Средний балл

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

            static void Ishop(string[] args) //HomeWork2
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
            static void DayOfWeek(string[] args)
            {
                Console.WriteLine("Введите номер дня недели:");
                int day = int.Parse(Console.ReadLine());

                switch (day)
                {
                    case 1:
                        Console.WriteLine("Понедельник.");
                        break;
                    case 2:
                        Console.WriteLine("Вторник.");
                        break;
                    case 3:
                        Console.WriteLine("Среда.");
                        break;
                    case 4:
                        Console.WriteLine("Четверг.");
                        break;
                    case 5:
                        Console.WriteLine("Пятница.");
                        break;
                    case 6:
                        Console.WriteLine("Суббота.");
                        break;
                    case 7:
                        Console.WriteLine("Воскресенье.");
                        break;
                    default:
                        Console.WriteLine("Такого дня нет.");
                        break;
                }
            }

            static void myArray(string[] args)
            {

                int[] myArray = { 2, 1, 2, 3, -5, 7 };
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] < 0)
                    {
                        Console.WriteLine($"Итерация {i+1}");
                        break;
                    }
                }
            }
        }
    }
}
