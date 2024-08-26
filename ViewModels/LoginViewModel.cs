using System.ComponentModel.DataAnnotations;

namespace VjencanjeIzSnova_WebApp.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Unesite e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesite lozinku")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; } = false;

        public LoginViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
