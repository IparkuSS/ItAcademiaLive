using System;
using System.Collections.Generic;
using System.Text;

namespace Matvey.Live
{
    public enum OrderStatus
    {
        Open,
        InProgress,
        Closed
    }

    public class Order
    {
        public int Id { get; set; }
        public required string SecondName { get; init; }
        public OrderStatus Status { get; set; }
        public string? Name { get; set; }
        public required string Email { get; set; }

        public override string ToString()
        {
            if (Status != OrderStatus.Closed)
            {
                return $"Order {{ Id = {Id} }}";
            }
            return $"Order {{ Name = {Name}, Email = {Email} }}";
        }
    }
}

