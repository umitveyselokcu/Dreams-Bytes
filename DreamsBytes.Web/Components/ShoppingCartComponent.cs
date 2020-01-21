using AutoMapper;

using DreamsBytes.Services;
using DreamsBytes.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamsBytes.Web.Components
{
    public class ShoppingCartComponent: ViewComponent
    {
        private readonly IStoreService _storeservice;
        public ShoppingCartComponent(IStoreService storeservice)
        {
        _storeservice = storeservice;
    }
        public IViewComponentResult Invoke()
        {
            IList<ShoppingCartItemViewModel> model = new List<ShoppingCartItemViewModel>();
            var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier);
            if (!userId .Any())
                return View(model);
            var shoppingCartItems =  _storeservice.GetShoppingCartItem(Convert.ToInt32(userId.First().Value));
            if (shoppingCartItems.Any())
            {
                model = shoppingCartItems;
                ViewBag.Total = model.Sum(x => x.Quantity * x.Product.Price);
            }
            return View(model);
        }
    }
}
