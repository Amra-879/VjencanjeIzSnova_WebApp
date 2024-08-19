using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Partner
{
    public int PartnerId { get; set; }

    public string UserId { get; set; }

    public string Ime { get; set; } = null!;

    public string? Mobitel { get; set; }

    public int? KategorijaId { get; set; }

    public virtual Kategorije? Kategorija { get; set; }

    public virtual ICollection<Recenzija> Recenzije { get; set; } = new List<Recenzija>();

    [ForeignKey("UserId")]
    public Korisnik User { get; set; }

    public virtual ICollection<Usluga> Usluge { get; set; } = new List<Usluga>();
}
