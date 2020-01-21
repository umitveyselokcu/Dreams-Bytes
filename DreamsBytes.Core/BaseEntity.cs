using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Core
{
    public abstract partial class BaseEntity
    {       
        public int Id { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
