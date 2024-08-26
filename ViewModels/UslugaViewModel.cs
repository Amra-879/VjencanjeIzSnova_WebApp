using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VjencanjeIzSnova_WebApp.Models;

namespace VjencanjeIzSnova_WebApp.ViewModels
{
    public class UslugaViewModel
    {

        public int PartnerId { get; set; }
        [Required]
        public string Naziv { get; set; } = null!;
        [Required]
        public string? Opis { get; set; }
        [Required]
        public string? CjenovniRang { get; set; }
        [Required]
        public string InfoOKompaniji { get; set; }
        [Required]
        public string Detalji { get; set; }

        public virtual Partner? Partner { get; set; }

        public string KontaktMail { get; set; }

        public virtual ICollection<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();
        public virtual ICollection<Slike> Slika { get; set; }

        public int SlikaId { get; set; }
        public int UslugaId { get; set; }
        
        public string Url { get; set; }
        public virtual Usluga Usluga { get; set; }

        public int? KategorijaId { get; set; }

        public ICollection<Kategorije> KategorijeList { get; set; } = new List<Kategorije>();

        [NotMapped]
        public IFormFileCollection? Slike { get; set; }
    }
}
