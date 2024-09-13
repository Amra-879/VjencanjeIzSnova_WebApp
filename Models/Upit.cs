using System.ComponentModel.DataAnnotations;

namespace VjencanjeIzSnova_WebApp.Models
{
    public class Upit
    {
        public int UpitId { get; set; }

        // Foreign key - Klijent
        public int KlijentId { get; set; }
        public Klijent Klijent { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DatumVjenčanja { get; set; }

        public bool DatumVjenčanjaJeFleksibilan { get; set; }

        [Required]
        [MaxLength(50)]
        public string BrojGostiju { get; set; }

        [Phone]
        public string BrojTelefona { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Poruka { get; set; }
    }

}
