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

namespace GongChaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeSizesController : Controller
    {
        private readonly IProductTypeSizeRepository _productTypeSizeRepository;

        public ProductTypeSizesController(IProductTypeSizeRepository productTypeSizeRepository)
        {
            _productTypeSizeRepository = productTypeSizeRepository;
        }

        // GET: api/ProductTypeSizes/productId
        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductTypeSize>))]
        public IActionResult GetProductTypeSizes(int productId)
        {
            var productTypeSizes = _productTypeSizeRepository.GetProductTypeSizesByProductId(productId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(productTypeSizes);
        }

        //// GET: api/ProductTypeSizes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductTypeSize>> GetProductTypeSize(int id)
        //{
        //  if (_context.ProductTypeSize == null)
        //  {
        //      return NotFound();
        //  }
        //    var productTypeSize = await _context.ProductTypeSize.FindAsync(id);

        //    if (productTypeSize == null)
        //    {
        //        return NotFound();
        //    }

        //    return productTypeSize;
        //}

        //// PUT: api/ProductTypeSizes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProductTypeSize(int id, ProductTypeSize productTypeSize)
        //{
        //    if (id != productTypeSize.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(productTypeSize).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductTypeSizeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ProductTypeSizes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ProductTypeSize>> PostProductTypeSize(ProductTypeSize productTypeSize)
        //{
        //  if (_context.ProductTypeSize == null)
        //  {
        //      return Problem("Entity set 'GongChaWebAPIContext.ProductTypeSize'  is null.");
        //  }
        //    _context.ProductTypeSize.Add(productTypeSize);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProductTypeSize", new { id = productTypeSize.Id }, productTypeSize);
        //}

        //// DELETE: api/ProductTypeSizes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProductTypeSize(int id)
        //{
        //    if (_context.ProductTypeSize == null)
        //    {
        //        return NotFound();
        //    }
        //    var productTypeSize = await _context.ProductTypeSize.FindAsync(id);
        //    if (productTypeSize == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ProductTypeSize.Remove(productTypeSize);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProductTypeSizeExists(int id)
        //{
        //    return (_context.ProductTypeSize?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
