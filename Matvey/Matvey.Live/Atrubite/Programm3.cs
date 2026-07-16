using System.Reflection;

namespace Matvey.Live.Atrubite
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ДЕМОНСТРАЦИЯ DisplayNameAttribute ===\n");

            var types = new Type[]
            {
            typeof(User),
            typeof(Point),
            typeof(Order)
            };

            foreach (var type in types)
            {
                ProcessType(type);
                Console.WriteLine();
            }

            Console.WriteLine("=== ДЕМОНСТРАЦИЯ ОБРАБОТКИ ОШИБОК ===\n");
            TestValidation();
        }

        static void ProcessType(Type type)
        {
            Console.WriteLine($"📦 {type.Name}");
            Console.WriteLine(new string('=', 50));

            var typeDisplayName = GetDisplayName(type);
            Console.WriteLine($"Тип: {typeDisplayName ?? "(без DisplayName)"} → {type.FullName}");
            Console.WriteLine();

            Console.WriteLine("  Поля:");
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                        BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var field in fields)
            {
                var displayName = GetDisplayName(field);
                Console.WriteLine($"    {displayName ?? "(без DisplayName)"} → {field.FieldType.Name} {field.Name}");
            }

            Console.WriteLine("  Свойства:");
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic |
                                                BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var prop in properties)
            {
                var displayName = GetDisplayName(prop);
                Console.WriteLine($"    {displayName ?? "(без DisplayName)"} → {prop.PropertyType.Name} {prop.Name}");
            }

            Console.WriteLine("  Детальная информация:");
            foreach (var prop in properties)
            {
                var attr = prop.GetCustomAttribute<DisplayNameAttribute>();
                if (attr != null)
                {
                    Console.WriteLine($"    {attr.DisplayName}:");
                    Console.WriteLine($"      - Описание: {attr.Description ?? "(нет)"}");
                    Console.WriteLine($"      - Порядок: {attr.Order}");
                }
            }
        }
        static string GetDisplayName(Type type)
        {
            var attr = type.GetCustomAttribute<DisplayNameAttribute>();
            return attr?.DisplayName;
        }
        static string GetDisplayName(FieldInfo field)
        {
            var attr = field.GetCustomAttribute<DisplayNameAttribute>();
            return attr?.DisplayName;
        }

        static string GetDisplayName(PropertyInfo property)
        {
            var attr = property.GetCustomAttribute<DisplayNameAttribute>();
            return attr?.DisplayName;
        }

        static void TestValidation()
        {
            var testCases = new Dictionary<string, Func<DisplayNameAttribute>>
            {
                ["null"] = () => new DisplayNameAttribute(null),
                ["пустая строка"] = () => new DisplayNameAttribute(""),
                ["пробелы"] = () => new DisplayNameAttribute("   "),
                ["табуляция"] = () => new DisplayNameAttribute("\t"),
                ["перевод строки"] = () => new DisplayNameAttribute("\n"),
                ["пробелы с текстом"] = () => new DisplayNameAttribute("   Текст   "), 
                ["нормальный текст"] = () => new DisplayNameAttribute("Заказ №1"), 
                ["текст с пробелами внутри"] = () => new DisplayNameAttribute("Имя пользователя"), 
            };

            Console.WriteLine("Проверка валидации DisplayNameAttribute:\n");

            foreach (var test in testCases)
            {
                try
                {
                    var attribute = test.Value();
                    Console.WriteLine($"[{test.Key}] Успешно создан: '{attribute.DisplayName}'");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[{test.Key}] Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{test.Key}] Неожиданная ошибка: {ex.Message}");
                }
            }
        }
    }
}