using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    public int PartnerId { get; set; }

    public virtual Kategorije Kategorija { get; set; } = null!;

    public virtual Partner Partner { get; set; } = null!;

    public virtual ICollection<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();

    public virtual ICollection<Slike> Slike { get; set; } = new List<Slike>();
}
