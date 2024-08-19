using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Rezervacija
{
    public int RezervacijeId { get; set; }

    public int? KlijentId { get; set; }

    public int? UslugaId { get; set; }

    public byte[] Datum { get; set; } = null!;

    public string? Status { get; set; }

    public virtual Klijent? Klijent { get; set; }

    public virtual Usluga? Usluga { get; set; }
}
