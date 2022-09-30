using System.ComponentModel.DataAnnotations;

namespace LoginRegister.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Please enter correct format")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "ConfirmPassword is required"),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
