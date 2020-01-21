using AutoMapper;
using DreamsBytes.Core.Entites;
using DreamsBytes.Data.UnitOfWork;
using DreamsBytes.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace DreamsBytes.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public virtual Order GetOrderById(int orderId)
        {
            if (orderId == 0)
                return null;

            return null;// _unitOfWork.Orders.GetById(orderId);
        }
        public IList<Product> GetProducts()
        {
            var typo = _unitOfWork.GetRepository<ProductType>().GetAll();
            var products =  _unitOfWork.GetRepository<Product>();
            return products.GetAll().ToList();
        }


        public bool AddToCart(int userId, int productId)
        {
            var cartItemRepository = _unitOfWork.GetRepository<ShoppingCartItem>();
            var productRepository = _unitOfWork.GetRepository<Product>();
            var doesUserHasItem = cartItemRepository.Find(x => x.UserId == userId && x.ProductId == productId);
            var product = productRepository.Find(x => x.Id == productId);
            if (!product.Any() || product.First().Quantity == 0)
            {
                return false;
            }
            else if (product.First().Quantity > 0)
            {
                product.First().Quantity--;
            }
            if (!doesUserHasItem.Any())
            {
                cartItemRepository.Add(new ShoppingCartItem() { ProductId = productId, Quantity = 1, UserId = userId });
            }
            else
            {
                doesUserHasItem.First().Quantity++;
            };

            _unitOfWork.Complete();
            return true;
        }

        public bool RemoveFromCart(int productId, int userId)
        {
            var cartItemRepository = _unitOfWork.GetRepository<ShoppingCartItem>();
            var productRepository = _unitOfWork.GetRepository<Product>();
            var garbageItems = cartItemRepository.Find(x => x.ProductId == productId && x.UserId == userId);
            if (garbageItems.Any(x=>x.Id>0))
            {
                foreach (var item in garbageItems)
                {
                  var productData =   productRepository.GetById(item.ProductId);
                    productData.Quantity += item.Quantity;
                }
                cartItemRepository.RemoveRange(garbageItems);
            }
            _unitOfWork.Complete();
            return true;
        }

        public IList<ShoppingCartItemViewModel> GetShoppingCartItem(int userId)
        {
            IList<ShoppingCartItemViewModel> model = new List<ShoppingCartItemViewModel>();
            var repo = _unitOfWork.GetRepository<ShoppingCartItem>();
            var products = _unitOfWork.GetRepository<Product>();
            var raaepo = _unitOfWork.GetRepository<User>();
            var userCartItems = repo.Find(x => x.UserId == userId);
            products.GetAll();
            if (userCartItems.Any())
            {
                foreach (var item in userCartItems)
                {
                    var dest = _mapper.Map<ShoppingCartItem, ShoppingCartItemViewModel>(item);
                    var productInCart = model.Where(x => x.ProductId == dest.ProductId);
                    if (productInCart.Any())
                    {
                        productInCart.First().Quantity++;
                        
                    }
                    else
                    {
                         model.Add(dest);
                    }
                }
            }
            return model;
        }

        public bool RemoveItem(int productId)
        {
            var cartItemRepository = _unitOfWork.GetRepository<ShoppingCartItem>();
            var itemRepository = _unitOfWork.GetRepository<Product>();
           
            var garbageCartItems = cartItemRepository.Find(x => x.ProductId == productId );
            var garbageItems = itemRepository.Find(x => x.Id == productId );
            if (garbageItems.Any(x => x.Id > 0))
            {
                itemRepository.RemoveRange(garbageItems);
            }
            if (garbageCartItems.Any(x => x.Id > 0))
            {
                cartItemRepository.RemoveRange(garbageCartItems);
            }
            _unitOfWork.Complete();
            return true;
        }

        public IList<Order> GetOrders(int userId)
        {
            IList<Order> model = new List<Order>();
            _unitOfWork.GetRepository<OrderItem>().GetAll();
            var orderRepo = _unitOfWork.GetRepository<Order>();
            var orders = orderRepo.Find(x => x.UserId == userId);
            if (orders.Any(x => x.Id > 0))
            {
                model = orders.ToList();
            }

            return model;
        }
        public bool ConfirmOrder(int userId) 
        {
            var orderRepo = _unitOfWork.GetRepository<Order>();
            var orderItemRepo = _unitOfWork.GetRepository<OrderItem>();
            var productRepo = _unitOfWork.GetRepository<Product>().GetAll();
            var cartRepo = _unitOfWork.GetRepository<ShoppingCartItem>();
            var cartItems = cartRepo.Find(x => x.UserId == userId);
            Order order = new Order()
            {
                UserId = userId,
                OrderTotal = cartItems.Sum(x => x.Product.Price * x.Quantity)
            };
            orderRepo.Add(order);
            _unitOfWork.Complete();
            foreach (var item in cartItems)
            {
                var newItem = new OrderItem()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price,
                    Name = item.Product.Name,
                    OrderId = order.Id
                };
                orderItemRepo.Add(newItem);
                cartRepo.Remove(item);
            }
            _unitOfWork.Complete();
            return true;
        }
    }
}
