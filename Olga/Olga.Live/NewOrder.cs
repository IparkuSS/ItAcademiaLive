using System;
using System.Collections.Generic;
using System.Text;

namespace Olga.Live
{
    public class NewOrder
    {
        public required string SecondName { get; init; }

        public int OrderId { get; set; }

        public string? Name { get; set; }

        public required string Email { get; set; }

        public OrderStatus Status { get; set; }

        public override string ToString()
        {
            if (Status == OrderStatus.Closed)
            {
                return $"Name: {Name}, Email: {Email}";
            }

            return $"OrderId: {OrderId}";
        }
    }
}
