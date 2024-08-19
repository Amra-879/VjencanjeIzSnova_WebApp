using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Slike
{
    public string Url { get; set; } = null!;

    public int SlikaId { get; set; }

    public int UslugaId { get; set; }

    public virtual Usluga Usluga { get; set; } = null!;
}
