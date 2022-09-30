using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LoginRegister.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter correct email address")]
        public string EmailorUserName { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }
}
