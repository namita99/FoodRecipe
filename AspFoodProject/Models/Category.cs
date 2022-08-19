using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace AspFoodProject.Models
{
    [Table(name: "Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name of the Category")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(50, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(1000, ErrorMessage = "{0} should have maximum {1} characters")]
        [Display(Name = "Description of the Category")]
        public string CategoryDescription { get; set; }

        [StringLength(120)]
        public string ImageUrl { get; set; } = null;

        #region Navigation Properties to the Subcategory Model

        public ICollection<SubCategory> Subcategories { get; set; }


        #endregion

        #region Navigation Properties to the Recipe Model

        public ICollection<Recipe> Recipes { get; set; }


        #endregion

    }
}
