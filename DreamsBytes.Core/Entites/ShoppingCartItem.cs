using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Core.Entites
{
    public class ShoppingCartItem : BaseEntity
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
   
        public virtual Product Product { get; set; }
    
        public virtual User User { get; set; }

    }
}
