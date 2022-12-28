using System.ComponentModel.DataAnnotations;

namespace AlphaLife.WebApplication.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "EmailAddress is required")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
