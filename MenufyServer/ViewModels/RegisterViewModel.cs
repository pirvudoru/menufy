using System.ComponentModel.DataAnnotations;

namespace MenufyServer.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Constitution")]
        public string Constitution { get; set; }

        [Required]
        [Display(Name = "BirthDate")]
        public string BirthDate { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public string Weight { get; set; }

        [Required]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [Required]
        [Display(Name = "Lifestyle")]
        public string Lifestyle { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}