using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Kategorije
{
    public int KategorijaId { get; set; }

    public string Naziv { get; set; } = null!;

    public string? Opis { get; set; }

    public virtual ICollection<Partner> Partneri { get; set; } = new List<Partner>();

    public virtual ICollection<Usluga> Usluge { get; set; } = new List<Usluga>();
}
