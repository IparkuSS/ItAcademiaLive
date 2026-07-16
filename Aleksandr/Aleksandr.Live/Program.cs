namespace Aleksandr.Live
{
    class Program
    {
        public struct MyStruct { }
        static void Main()
        {
            DisplayTypeInfo(typeof(int), "int");
            
            DisplayTypeInfo(typeof(string), "string");
            
            DisplayTypeInfo(typeof(DateTime), "DateTime");
            
            DisplayTypeInfo(typeof(List<string>), "List<string>");
            
            DisplayTypeInfo(typeof(MyStruct), "MyStruct");
        }

        static void DisplayTypeInfo(Type type, string alias)
        {
            Console.WriteLine($"=== Анализ типа: {alias} ===");

            Console.WriteLine($"Имя: {type.Name}");

            Console.WriteLine($"Полное имя: {type.FullName}");

            Console.WriteLine($"Тип: {(type.IsValueType ? "ValueType" : "ReferenceType")}");

            Console.WriteLine($"Это класс: {type.IsClass}");

            Console.WriteLine($"Обобщённый: {type.IsGenericType}");
            
            Console.WriteLine();
        }
    }
}

