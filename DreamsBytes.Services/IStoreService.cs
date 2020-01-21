using DreamsBytes.Core.Entites;
using DreamsBytes.Services.Models;
using System.Collections.Generic;

namespace DreamsBytes.Services
{
    public interface IStoreService
    {
        public IList<Order> GetOrders(int userId);
        public bool ConfirmOrder(int userId);
        public IList<Product> GetProducts();
        public bool AddToCart(int userId, int productId);
        public IList<ShoppingCartItemViewModel> GetShoppingCartItem(int userId);
        public bool RemoveFromCart(int productId, int userId);
        public bool RemoveItem(int productId);
    }
}
