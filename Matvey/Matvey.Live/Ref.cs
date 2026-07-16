using System.Reflection;

namespace Matvey.Live
{


    public struct MyStruct
    {
        private int _id;
        private string _name;
        public int PublicField;
        internal int InternalField;
        private static int _staticPrivateField;
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
                }

                const BindingFlags flags = BindingFlags.NonPublic |
                                           BindingFlags.Instance |
                                           BindingFlags.DeclaredOnly;

                FieldInfo[] privateInstanceFields = type.GetFields(flags);

                if (privateInstanceFields.Length == 0)
                {
                    Console.WriteLine("  (нет private instance-полей)");
                }
                else
                {
                    foreach (FieldInfo field in privateInstanceFields)
                    {
                        Console.WriteLine($"  - {field.FieldType.Name} {field.Name}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}