using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Košarica
{
    public int KošaricaId { get; set; }

    public int? ClientId { get; set; }

    public string NazivArtikla { get; set; } = null!;

    public double Cijena { get; set; }

    public virtual Klijent? Client { get; set; }
}
