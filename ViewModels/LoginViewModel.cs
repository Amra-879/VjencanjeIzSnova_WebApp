using System.ComponentModel.DataAnnotations;

namespace VjencanjeIzSnova_WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Unesite e-mail")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage ="Unesite lozinku")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name ="Zapamti me?")]
        public bool RememberMe { get; set; } = false;
    }
}
