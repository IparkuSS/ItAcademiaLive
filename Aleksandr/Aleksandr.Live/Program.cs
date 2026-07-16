using System.Reflection;

namespace Aleksandr.Live
{

    [AttributeUsage(AttributeTargets.Property)]
    public class MyDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; }

        public MyDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var myObject = new Person();

            Type type = myObject.GetType();

            Console.WriteLine("--- Отображаемые имена и типы ---");
            foreach (var prop in type.GetProperties())
            {
                var attr = prop.GetCustomAttribute<MyDisplayNameAttribute>();
                string displayName = attr != null ? attr.DisplayName : prop.Name;
                Console.WriteLine($"{displayName} → {prop.PropertyType.Name}");
            }

            Console.WriteLine("\n--- Проверка пустых значений ---");

            string[] testStrings = { "Вася", null, "", "   ", "Петя" };

            foreach (var str in testStrings)
            {
                var error = ValidateString(str);
                if (error != null)
                {
                    Console.WriteLine($"Ошибка: {error}");
                }
                else
                {
                    Console.WriteLine($"Успешно: {str}");
                }
            }
        }

        public static string ValidateString(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                return "Строка не может быть пустой, null или состоять только из пробелов.";
            }
            return null;
        }
    }

    public class Person
    {
        [MyDisplayName("Полное имя")]
        public string FullName { get; set; }

        [MyDisplayName("Возраст")]
        public int Age { get; set; }
    }
}


