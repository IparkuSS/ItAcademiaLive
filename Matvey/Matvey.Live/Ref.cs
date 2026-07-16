namespace Matvey.Live { 

public struct MyStruct
{
    public int X;
    public string Y;
}

class Program2
{
    static void Main()
    {
        Type[] types = new Type[]
        {
            typeof(int),
            typeof(string),
            typeof(DateTime),
            typeof(List<string>),
            typeof(MyStruct)
        };

        foreach (Type type in types)
        {
            Console.WriteLine($"=== {type.Name} ===");
            Console.WriteLine($"Полное имя: {type.FullName}");

            bool isValueType = type.IsValueType;
            Console.WriteLine($"Тип: {(isValueType ? "Value Type" : "Reference Type")}");

            bool isClass = type.IsClass;
            Console.WriteLine($"Является классом: {isClass}");

            bool isGeneric = type.IsGenericType;
            Console.WriteLine($"Обобщённый: {isGeneric}");

            if (isGeneric)
            {
                var genericArgs = type.GetGenericArguments();
                Console.WriteLine($"Generic аргументы: {string.Join(", ", (object[])genericArgs)}");
                Console.WriteLine($"Определение обобщённого типа: {type.GetGenericTypeDefinition()}");
            }

            Console.WriteLine();
        }
    }
}
}