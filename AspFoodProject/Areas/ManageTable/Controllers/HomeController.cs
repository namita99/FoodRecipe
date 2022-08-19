using AspFoodProject.Areas.ManageTable.ViewModels;
using AspFoodProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AspFoodProject.Areas.ManageTable.Controllers
{
    [Area("ManageTable")]

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            // Populate the data for the drop-down select list
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Selected = true, Value = "", Text = "-- select a category --" });
            categories.AddRange(new SelectList(_context.Categories, "CategoryId", "CategoryName"));
            ViewData["CategoryId"] = categories.ToArray();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("CategoryId")] ShowCategoryViewModel model)
        {
            // Retrieve the Menu Items for the selected category
            var items = _context.Subcategories.Where(m => m.CategoryId == model.CategoryId);

            // Populate the data into the viewmodel object
            model.Subcategories = items.ToList();

            // Populate the data for the drop-down select list
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            // Display the View
            return View("Index", model);
        }

        public IActionResult Index1()
        {
            // Populate the data for the drop-down select list
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Selected = true, Value = "", Text = "-- select a category --" });
            categories.AddRange(new SelectList(_context.Categories, "CategoryId", "CategoryName"));
            ViewData["CategoryId"] = categories.ToArray();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index1([Bind("CategoryId")] ShowRecipeViewModel model1)
        {
            // Retrieve the Menu Items for the selected category
            var items = _context.Recipes.Where(m1 => m1.CategoryId == model1.CategoryId);

            // Populate the data into the viewmodel object
            model1.Recipes = items.ToList();

            // Populate the data for the drop-down select list
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            // Display the View
            return View("Index1", model1);
        }
    }
}
