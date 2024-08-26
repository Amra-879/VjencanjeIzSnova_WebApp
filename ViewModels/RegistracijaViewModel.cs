using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace VjencanjeIzSnova_WebApp.ViewModels
{
    public class RegistracijaViewModel
    {

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email adresa")]
        public string Email { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite lozinku")]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Tip korisnika")]
        public string UserType { get; set; } = "Klijent";

        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; } 

        [Required]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; } 

        [Required]
        [Display(Name = "Grad")]
        public string Grad { get; set; } 
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum vjenčanja")]
        public DateOnly DatumVjencanja { get; set; }

        public RegistracijaViewModel()
        {

        }

        public RegistracijaViewModel(string UserId, string Email, string Password, string ConfirmPassword, string UserType, string Ime, string Prezime, string Grad, DateOnly DatumVjencanja) 
        {
            this.Email = Email;
            this.Password = Password;
            this.ConfirmPassword = ConfirmPassword;
            this.UserType = UserType;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Grad = Grad;
            this.DatumVjencanja = DatumVjencanja;

        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
    }


