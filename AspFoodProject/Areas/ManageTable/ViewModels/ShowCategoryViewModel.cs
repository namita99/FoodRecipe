using AspFoodProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspFoodProject.Areas.ManageTable.ViewModels
{
    public class ShowCategoryViewModel
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public ICollection<SubCategory> Subcategories { get; set; }

        public int? Quantity { get; set; }
    }
}
