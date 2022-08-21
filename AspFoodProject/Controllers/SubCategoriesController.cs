﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspFoodProject.Data;
using AspFoodProject.Models;

namespace AspFoodProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubcategories()
        {
            return await _context.Subcategories.ToListAsync();
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(int id)
        {
            var subCategory = await _context.Subcategories.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return subCategory;
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
        public async Task<ActionResult<SubCategory>> PostSubCategory(SubCategory subCategory)
        {
            _context.Subcategories.Add(subCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubCategory", new { id = subCategory.SubcategoryId }, subCategory);
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategory>> DeleteSubCategory(int id)
        {
            var subCategory = await _context.Subcategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            _context.Subcategories.Remove(subCategory);
            await _context.SaveChangesAsync();

            return subCategory;
        }

        private bool SubCategoryExists(int id)
        {
            return _context.Subcategories.Any(e => e.SubcategoryId == id);
        }
    }
}
