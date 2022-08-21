using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspFoodProject.Data;
using AspFoodProject.Models;
using Microsoft.Extensions.Logging;

namespace AspFoodProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SubCategoriesController> _logger;


        public SubCategoriesController(
                   ApplicationDbContext context,
                   ILogger<SubCategoriesController> logger)
        {
            _context = context;
            _logger = logger;

        }

        // GET: api/SubCategories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubcategories()
        //{
        //    return await _context.Subcategories.ToListAsync();
        //}

        public async Task<IActionResult> GetSubCategories()
        {
            try
            {
                var Subcategories = await _context.Subcategories.ToListAsync();

                if (Subcategories == null)
                {
                    _logger.LogWarning("No Categories were found in the database");
                    return NotFound();
                }
                _logger.LogInformation("Extracted all the Categories from database");
                return Ok(Subcategories);
            }
            catch
            {
                _logger.LogError("There was an attempt to retrieve information from the database");
                return BadRequest();
            }
        }
        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var SubCategory = await _context.Subcategories.FindAsync(id);
                //var category = await _context.Categories
                //                             .Include(c => c.Books)
                //                             .SingleOrDefaultAsync(c => c.CategoryId == id);

                if (SubCategory == null)
                {
                    return NotFound();
                }

                return Ok(SubCategory);
            }
            catch
            {
                return BadRequest();
            }
        }


        // PUT: api/SubCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategory subCategory)
        {
            if (id != subCategory.SubcategoryId)
            {
                return BadRequest();
            }

            _context.Entry(subCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST: api/SubCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostSubCategory(SubCategory subCategory)
        {
            try
            {
                _context.Subcategories.Add(subCategory);

                int countAffected = await _context.SaveChangesAsync();
                if (countAffected > 0)
                {
                    // Return the link to the newly inserted row 
                    var result = CreatedAtAction("GetSubcategory", new { id = subCategory.SubcategoryId }, subCategory);
                    return Ok(result);

                    // NOTE: Return the HTTP RESPONSE CODE 201 "Created"
                    // Uri url;
                    // System.Uri.TryCreate($"~/api/Categories/{category.CategoryId}", UriKind.Relative, out url); 
                    // return Created(url, result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception exp)
            {
                ModelState.AddModelError("Post", exp.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategory>> DeleteSubCategory(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var subCategory = await _context.Subcategories.FindAsync(id);
                if (subCategory == null)
                {
                    return NotFound();
                }

                _context.Subcategories.Remove(subCategory);
                await _context.SaveChangesAsync();

                return Ok(subCategory);
            }

            catch
            {
                return BadRequest();
            }
        }

        private bool SubCategoryExists(int id)
        {
            return _context.Subcategories.Any(e => e.SubcategoryId == id);
        }
    }
}
