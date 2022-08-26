using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspFoodProject.Models
{

    [Table(name: "Subcategories")]

    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category ID")]
        public int SubcategoryId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name of the Subcategory")]
        public string SubcategoryName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(50, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(1000, ErrorMessage = "{0} should have maximum {1} characters")]
        [Display(Name = "Description of the Subcategory")]
        public string SubcategoryDescription { get; set; }

        [StringLength(120)]
        public string ImageUrl { get; set; } = null;

        #region Navigation Properties to the Category Model

        [Display(Name = "Category Name")]

        public int CategoryId { get; set; }

        [ForeignKey(nameof(SubCategory.CategoryId))]
        public Category Category { get; set; }

        #endregion
    }
}
