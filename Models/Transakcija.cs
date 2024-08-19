using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Transakcija
{
    public int PaymentId { get; set; }

    public int? KlijentId { get; set; }

    public double Iznos { get; set; }

    public DateTime PlacanjeDatum { get; set; }

    public string? TransakcijaId { get; set; }

    public virtual Klijent? Klijent { get; set; }
}
