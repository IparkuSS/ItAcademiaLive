using System;
using System.Collections.Generic;
using System.Text;

namespace Matvey.Live
{
    public record OrderRequest
    {
        public string? Name { get; set; }
        public required string Email { get; set; }
    }
}
