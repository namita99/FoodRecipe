using System.ComponentModel.DataAnnotations;

namespace AspFoodProject.Models
{
    public enum MyIdentityRoleNames
    {
        [Display(Name = "Admin Role")]    // Admin
        AppAdmin,


        [Display(Name = "User Role")]     //User
        AppUser   
    }
}
