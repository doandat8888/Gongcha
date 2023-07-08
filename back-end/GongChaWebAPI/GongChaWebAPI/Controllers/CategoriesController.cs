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
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryById(int id)
        {
            if(!_categoryRepository.CategoryExists(id))
            {
                return NotFound();
            }

            var category = _categoryRepository.GetCategory(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }

        //// PUT: api/Categories/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(int id, Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
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

        //// POST: api/Categories
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Category>> PostCategory(Category category)
        //{
        //  if (_context.Category == null)
        //  {
        //      return Problem("Entity set 'GongChaWebAPIContext.Category'  is null.");
        //  }
        //    _context.Category.Add(category);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        //}

        //// DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    if (_context.Category == null)
        //    {
        //        return NotFound();
        //    }
        //    var category = await _context.Category.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Category.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CategoryExists(int id)
        //{
        //    return (_context.Category?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
