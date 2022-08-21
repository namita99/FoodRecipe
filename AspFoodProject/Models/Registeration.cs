using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AspFoodProject.Models
{
    [Table(name: "Registerations")]

    public class Registeration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Register ID")]

        public int RegisterId { get; set; }


        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [StringLength(100)]
        [Display(Name = "Customer Address")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} should have maximum {1} characters")]
        public string RegisterAddress { get; set; }


        [Required(ErrorMessage = "{0} cannot be Empty!")]

        [Display(Name = "Customer Number")]

        [Phone]
        public string RegisterNo { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]

        [Display(Name = "Customer Email Address")]
        [EmailAddress]
        public string RegisterEmailID { get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name = "Registerd")]

        public bool IsEnabled { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        [Display(Name = "Date Time")]

        public DateTime OrderDateTime { get; set; }


        #region Navigation Properties to the Competition Model

        [Display(Name = "Event Name")]

        public int EventId { get; set; }

        [ForeignKey(nameof(Registeration.EventId))]
        public Competition Competition { get; set; }

        #endregion


        #region Navigation Properties to the Customer Model

        [Display(Name = "Customer Name")]

        public int CustomerId { get; set; }

        [ForeignKey(nameof(Registeration.CustomerId))]
        public Customer Customer { get; set; }

        #endregion



    }
}
