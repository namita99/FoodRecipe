using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace AspFoodProject.Models
{
    [Table(name: "Competitions")]

    public class Competition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Event ID")]

        public int EventId { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [Display(Name = "Event Name")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} should have maximum {1} characters")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [Display(Name = "Venue")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} should have maximum {1} characters")]
        public string EventAddress { get; set; }

        [StringLength(120)]
        public string ImageUrl { get; set; } = null;

        [Required]
        [DefaultValue(false)]
        [Display(Name = "Event added")]

        public bool IsEnabled { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        [Display(Name = "Registration Start Date")]

        public DateTime OrderDateTime { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        [Display(Name = "Registration End Date")]

        public DateTime OrderDateTime1 { get; set; }

        [Display(Name = "Duration")]
        public String hours1 { get; set; }

        [Display(Name = "Type")]
        public String Phase { get; set; }


        #region Navigation Properties to the Register Model

        public ICollection<Registeration> Registerations { get; set; }


        #endregion

    }
}
