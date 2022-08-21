using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace AspFoodProject.Models
{
    [Table(name: "Recipes")]

    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Recipe ID")]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(50, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(1000, ErrorMessage = "{0} should have maximum {1} characters")]
        [Display(Name = "Ingredients")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(50, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(1000, ErrorMessage = "{0} should have maximum {1} characters")]
        [Display(Name = "How to make it")]
        public string RecipeDescription { get; set; }

        [StringLength(120)]
        public string ImageUrl { get; set; } = null;

        [Required]
        [DefaultValue(false)]
        [Display(Name = "Recipe added")]

        public bool IsEnabled { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [Display(Name = "Customer Name")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} should have maximum {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [StringLength(100)]
        [Display(Name = "Customer Address")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} should have maximum {1} characters")]
        public string Address { get; set; }


        [Required(ErrorMessage = "{0} cannot be Empty!")]

        [Display(Name = "Customer Email Address")]
        [EmailAddress]
        public string EmailID { get; set; }


        [Required]
        [Column(TypeName = "datetime2")]
        [Display(Name = "Date Time")]

        public DateTime OrderDateTime { get; set; }



        [Display(Name = "Cooking Time")]
        public String hours1 { get; set; }

        [Display(Name = "Preparation Time")]
        public String hours2 { get; set; }


        #region Navigation Properties to the Category Model

        [Display(Name = "Category Name")]

        public int CategoryId { get; set; }

        [ForeignKey(nameof(Recipe.CategoryId))]
        public Category Category { get; set; }

        #endregion




        #region Navigation Properties to the Recipe Model

        public ICollection<Comment> Comments { get; set; }


        #endregion

    }
}
