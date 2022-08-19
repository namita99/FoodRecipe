using AspFoodProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspFoodProject.Areas.ManageTable.ViewModels
{
    public class ShowRecipeViewModel
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public ICollection<Recipe> Recipes { get; set; }

        public int? Quantity { get; set; }
    }
}
