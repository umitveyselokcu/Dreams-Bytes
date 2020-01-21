using DreamsBytes.Core.Entites;
using DreamsBytes.Data.Context;
using DreamsBytes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamsBytes.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly EFDataContext _context;
        private readonly IStoreService _storeService;

        public ProductController(IStoreService storeService,
            EFDataContext context)
        {
            _context = context;
            _storeService = storeService;
        }


        public IActionResult Index()
        {
            return View(_storeService.GetProducts());
        }

        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Quantity,Price,ProductTypeId,Id,CreatedOnUtc")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Name", product.ProductTypeId);
            return View(product);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Name", product.ProductTypeId);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Quantity,Price,ProductTypeId,Id,CreatedOnUtc")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Name", product.ProductTypeId);
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int productId)
        {

            bool result = _storeService.RemoveItem(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public bool AddCart(int id)
        {
            int userId = GetUserId();
            bool result = _storeService.AddToCart(userId, id);
            return result;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        [HttpPost, ActionName("DeleteCartItem")]
        public IActionResult DeleteCartItem(int productId,int userId)
        {
            dynamic result = _storeService.RemoveFromCart(productId, userId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Orders()
        {
            int userId = GetUserId();
            var model = _storeService.GetOrders(userId);
            return View(model);
        }
        [HttpPost, ActionName("ConfirmOrder")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmOrder()
        {
            int userId = GetUserId();
            bool result = _storeService.ConfirmOrder(userId);
            return RedirectToAction(nameof(Orders));
        }
        public dynamic GetUserId()
        {
            string userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value;
            if (userId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return Convert.ToInt32(userId);
        }
    }
}
