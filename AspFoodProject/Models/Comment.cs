using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspFoodProject.Models
{
    [Table(name: "Comments")]

    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]

        [Display(Name = "Comment")]
        public string CommentName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [MinLength(10, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(1000, ErrorMessage = "{0} should have maximum {1} characters")]
        [Display(Name = "Message")]
        public string CommentDescription { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        
        [Display(Name = "Any Suggestions")]
        public string query { get; set; }

        #region Navigation Properties to the Recipe Model

        [Display(Name = "Recipe Name")]

        public int RecipeId { get; set; }

        [ForeignKey(nameof(Comment.RecipeId))]

        public Recipe Recipe { get; set; }

        #endregion



    }
}
