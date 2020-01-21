using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DreamsBytes.Core.Entites
{
    public class User : BaseEntity
    {
        private ICollection<ShoppingCartItem> _shoppingCartItems;
        private ICollection<Order> _orders;
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserRole UserRoleId { get; set; }
        public virtual UserPassword UserPassword { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get => _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>());
            protected set => _shoppingCartItems = value;
        }
        public virtual ICollection<Order> Orders
        {
            get => _orders ?? (_orders = new List<Order>());
            protected set => _orders = value;
        }
    }

    public enum UserRole
    {
        [EnumMember(Value = "Admin")]
        Admin,
        [EnumMember(Value = "User")]
        User,
    }
}
