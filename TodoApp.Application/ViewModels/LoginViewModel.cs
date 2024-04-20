using System.ComponentModel.DataAnnotations;

namespace TodoApp.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [DataType(DataType.EmailAddress)]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
