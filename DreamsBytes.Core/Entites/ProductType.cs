using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Core.Entites
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
