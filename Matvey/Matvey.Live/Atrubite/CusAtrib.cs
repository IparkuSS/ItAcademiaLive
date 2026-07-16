using System;
using System.Collections.Generic;
using System.Text;

namespace Matvey.Live.Atrubite
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Struct,
                    AllowMultiple = false,
                    Inherited = true)]
    public class DisplayNameAttribute : Attribute
    {
        public string DisplayName { get; }
        public string Description { get; set; }
        public int Order { get; set; }

        public DisplayNameAttribute(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("DisplayName не может быть null, пустым или состоять только из пробелов", nameof(displayName));

            DisplayName = displayName;
        }
    }
}