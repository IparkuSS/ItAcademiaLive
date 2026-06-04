using System.Text.RegularExpressions;

namespace Aleksandr.Live.Api.Domains
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        private string? _email;
        public string? Email
        {
            get => _email;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email is empty.");

                // Выражение для проверки базового формата email
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                // Проверка с использованием регулярного выражения
                if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException($"Incorrect email: {value}");
                }

                _email = value;

            }
        }
        public bool IsClosed { get; set; }
        public Order(int id, string name, string email, bool isClosed)
        {
            Id = id;
            Name = name;
            Email = email;
            IsClosed = isClosed;
        }


        public override string ToString()
        {
            return IsClosed
                ? $"Order ID: {Id}"
                : $"Order Details - Name: {Name}, Email: {Email}";
        }

    }
}
