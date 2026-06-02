using System;
using System.Collections.Generic;
using System.Text;

namespace Olga.Live
{
    public class OrderRequest
    {
        public string? Name { get; set; }
        public required string Email { get; set; }
    }
}
