using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using System.Collections.Generic;

namespace AspFoodProject.Models
{
    [Table(name: "Customers")]

    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer ID")]

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [Display(Name = "Customer Name")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} should have maximum {1} characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [StringLength(100)]
        [Display(Name = "Customer Address")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} should have maximum {1} characters")]
        public string CustomerAddress { get; set; }


        [Required(ErrorMessage = "{0} cannot be Empty!")]
        
        [Display(Name = "Customer Number")]

        [Phone]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]

        [Display(Name = "Customer Email Address")]
        [EmailAddress]
        public string EmailID { get; set; }


        #region Navigation Properties to the Register Model

        public ICollection<Registeration> Registerations { get; set; }


        #endregion




    }
}
