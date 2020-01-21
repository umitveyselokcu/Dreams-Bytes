using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamsBytes.Core.Entites;
using DreamsBytes.Data.UnitOfWork;
using DreamsBytes.Data.Repositories;


namespace DreamsBytes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsApiController : ControllerBase
    {
        private readonly IRepository<Product> _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsApiController(IUnitOfWork context)
        {
          
            _context = context.GetRepository<Product>();
            _unitOfWork = context;
            _unitOfWork.GetRepository<ProductType>().GetAll();
        }

        // GET: api/ProductsApi
        [HttpGet]
        public  IEnumerable<Product> GetProducts()
        {
            return _context.GetAll(); 
        }

        // GET: api/ProductsApi/5
        [HttpGet("{id}")]
        public  ActionResult<Product> GetProduct(int id)
        {
            var product =  _context.Find(x=>x.Id==id);

            if (product == null)
            {
                return NotFound();
            }

            return product.First();
        }

        // PUT: api/ProductsApi/5       
        [HttpPut("{id}")]
        public  IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                 _context.Add(product);
                _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductsApi
        [HttpPost]
        public  ActionResult<Product> PostProduct(Product product)
        {
            _context.Add(product);
            _unitOfWork.Complete();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/ProductsApi/5
        [HttpDelete("{id}")]
        public  ActionResult<Product> DeleteProduct(int id)
        {
            var product =  _context.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
             
            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Find(x=>x.Id==id).Any();
        }
    }
}
