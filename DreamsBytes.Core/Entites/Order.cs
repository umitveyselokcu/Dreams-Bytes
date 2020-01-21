using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Core.Entites
{
    public class Order : BaseEntity
    {
        private ICollection<OrderItem> _orderItems;
        public int UserId { get; set; }
        public decimal OrderTotal { get; set; }               
        public virtual ICollection<OrderItem> OrderItems
        {
            get => _orderItems ?? (_orderItems = new List<OrderItem>());
            protected set => _orderItems = value;
        }
        public virtual User User { get; set; } 

    }
}
