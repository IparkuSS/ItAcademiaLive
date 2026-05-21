namespace Aleksandr.Live
{
    class Program
    {
        void PrintDayTime(DayTime dayTime)
        {

            switch (dayTime)
            {
                case DayTime.Morning:
                    Console.WriteLine("Доброе утро");
                    break;
                case DayTime.Afternoon:
                    Console.WriteLine("Добрый день");
                    break;
                case DayTime.Evening:
                    Console.WriteLine("Добрый вечер");
                    break;
                case DayTime.Night:
                    Console.WriteLine("Доброй ночи");
                    break;
            }
        }
        enum DayTime
        {
            Morning,
            Afternoon,
            Evening,
            Night
        }

    }
}
