using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Recenzija
{
    public int RecenzijaId { get; set; }

    public int? KlijentId { get; set; }

    public int? UslugaId { get; set; }

    public double? Ocjena { get; set; }

    public string? Komentar { get; set; }

    public byte[] Datum { get; set; } = null!;

    public virtual Klijent? Klijent { get; set; }

    public virtual Partner? Usluga { get; set; }
}
