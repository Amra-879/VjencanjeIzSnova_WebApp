using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VjencanjeIzSnova_WebApp.Data;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Usluga
{
    [Key]
    public int UslugaId { get; set; }

    public int KategorijaId { get; set; }

    public string KontaktMail { get; set; } = null!;

    public string? CjenovniRang { get; set; }

    public string Detalji { get; set; } = null!;

    public string InfoOKompaniji { get; set; } = null!;

    public string Naziv { get; set; } = null!;

    public string? Opis { get; set; }

    public string Grad { get; set; }
    public string Adresa { get; set; }

    public string? InsragramLink { get; set; }

    public string? FacebookLink { get; set; }

    public string? WebsiteLink { get; set; }

    public int PartnerId { get; set; }

    public virtual Kategorije? Kategorija { get; set; } = null!;

    public virtual Partner? Partner { get; set; } = null!;

    public virtual ICollection<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();

    public virtual ICollection<Slike> Slike { get; set; } = new List<Slike>();

    public ICollection<OmiljeneStavke> FavoritedBy { get; set; } = new List<OmiljeneStavke>();

    public ICollection<Recenzija> Recenzija { get; set; } = new List<Recenzija>();

    public int getBrojRecenzija(int uslugaId)
    {
        using (var context = new VjencanjeIzSnovaDbContext())
        {
            return context.Recenzije.Count(r => r.UslugaId == uslugaId);
        }
    }


}
