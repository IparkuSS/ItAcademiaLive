using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Aleksandr.Live
{
    internal class Order
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

    }
}
