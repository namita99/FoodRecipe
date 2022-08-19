using Microsoft.AspNetCore.Mvc;

namespace AspFoodProject.Areas.Food.Controllers
{
    [Area("HomePage")]
    public class FoodRecipesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
