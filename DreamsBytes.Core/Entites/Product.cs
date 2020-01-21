using System.Collections.Generic;

namespace DreamsBytes.Core.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<ShoppingCartItem> CartItems { get; set; }

    }

   
}
