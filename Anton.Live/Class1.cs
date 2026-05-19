using System;
using System.Collections.Generic;
using System.Text;

namespace Anton.Live
{
    public class StatusTracker
    {
        public string Status { get; private set; } = "Bad";

        public void SetStatus(string status)
        {
            Status = status;
        }
    }
}
