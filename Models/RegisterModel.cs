using System.ComponentModel.DataAnnotations;

namespace GrainMaster.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "E-Mail Address")]
        public string Email { get; set; }

        [Required, Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}