using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GongChaWebAPI.Data;
using GongChaWebAPI.Models;
using GongChaWebAPI.Interfaces;
using GongChaWebAPI.Repository;

namespace GongChaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProductById(int id)
        {
            if (!_productRepository.ProductExists(id))
            {
                return NotFound();
            }

            var product = _productRepository.GetProduct(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(product);
        }

        [HttpGet("{categoryId}/productByCategory")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
            var products = _productRepository.GetProductsByCategoryId(categoryId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduct(int id, [FromBody]Product updatedProduct)
        {
            if(updatedProduct == null)
            {
                return BadRequest(ModelState);
            }

            if(id != updatedProduct.Id)
            {
                return BadRequest(ModelState);
            }

            if(!_productRepository.ProductExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(!_productRepository.UpdateProduct(updatedProduct))
            {
                ModelState.AddModelError("", "Something went wrong when updating the product");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product addedProduct)
        {
            if (addedProduct == null)
            {
                return BadRequest(ModelState);
            }

            var products = _productRepository.GetProduct(addedProduct.Name);
            if (products != null)
            {
                ModelState.AddModelError("", "Product already exists");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_productRepository.UpdateProduct(addedProduct))
            {
                ModelState.AddModelError("", "Something went wrong when creating the product");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    if (_context.Product == null)
        //    {
        //        return NotFound();
        //    }
        //    var product = await _context.Product.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Product.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProductExists(int id)
        //{
        //    return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
    }
