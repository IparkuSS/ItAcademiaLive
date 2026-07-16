using System.Reflection;

namespace Aleksandr.Live
{
    class Program
    {
        static void Main()
        {
            Type type = typeof(User);

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine($"--- Найдено приватных полей: {fields.Length} ---");

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"Тип: {field.FieldType.Name} | Имя: {field.Name}");
            }
        }
    }

    class User
    {
        private string _name = "Алексей";
        private int _age = 25;

        public string PublicField = string.Empty;
        public decimal Salary;
    }
}


