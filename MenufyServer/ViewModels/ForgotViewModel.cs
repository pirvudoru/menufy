using System.ComponentModel.DataAnnotations;

namespace MenufyServer.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}