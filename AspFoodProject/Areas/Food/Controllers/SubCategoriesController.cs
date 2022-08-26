using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspFoodProject.Data;
using AspFoodProject.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AspFoodProject.Areas.Food.Controllers
{
    [Area("Food")]
    [Authorize(Roles = "AppAdmin")]

    public class SubCategoriesController : Controller
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

        // GET: Food/SubCategories
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("-------------- Retrieved all the Categories from the database");

            var applicationDbContext = _context.Subcategories.Include(s => s.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Food/SubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.Subcategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SubcategoryId == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // GET: Food/SubCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Food/SubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubcategoryId,SubcategoryName,SubcategoryDescription,ImageUrl,CategoryId")] SubCategory subcategoryModel)
        {
            if (ModelState.IsValid)
            {
                // Sanitize the data before consumption
                subcategoryModel.SubcategoryName = subcategoryModel.SubcategoryName.Trim();

                // Check for Duplicate CategoryName
                bool isDuplicateFound
                    = _context.Subcategories.Any(c => c.SubcategoryName == subcategoryModel.SubcategoryName);
                if (isDuplicateFound)
                {
                    ModelState.AddModelError("SubcategoryName", "Duplicate! Another subcategory with same name exists");
                }
                else
                {
                    // Save the changes 
                    _context.Add(subcategoryModel);
                    await _context.SaveChangesAsync();              // update the database
                    return RedirectToAction(nameof(Index));
                }



            }
            return View(subcategoryModel);
        }

        // GET: Food/SubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.Subcategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", subCategory.CategoryId);
            return View(subCategory);
        }

        // POST: Food/SubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubcategoryId,SubcategoryName,SubcategoryDescription,ImageUrl,CategoryId")] SubCategory subcategoryModel)
        {
            if (id != subcategoryModel.SubcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Sanitize the data before consumption
                subcategoryModel.SubcategoryName = subcategoryModel.SubcategoryName.Trim();

                // Check for duplicate Category
                bool isDuplicateFound
                    = _context.Subcategories.Any(c => c.SubcategoryName == subcategoryModel.SubcategoryName
                                                   && c.SubcategoryId != subcategoryModel.SubcategoryId);
                if (isDuplicateFound)
                {
                    ModelState.AddModelError("SubcategoryName", "A Duplicate Subcategory was found!");
                }
                else
                {
                    try
                    {
                        _context.Update(subcategoryModel);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SubCategoryExists(subcategoryModel.SubcategoryId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
                
            return View(subcategoryModel);
        }

        // GET: Food/SubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.Subcategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SubcategoryId == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // POST: Food/SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _context.Subcategories.FindAsync(id);
            _context.Subcategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoryExists(int id)
        {
            return _context.Subcategories.Any(e => e.SubcategoryId == id);
        }
    }
}
