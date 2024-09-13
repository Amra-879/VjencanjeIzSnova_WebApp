using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Klijent
{
    public int KlijentId { get; set; }

    public string UserId { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string? Grad { get; set; }

    public DateOnly DatumVjenčanja { get; set; }

    public virtual ICollection<Košarica> Košarica { get; set; } = new List<Košarica>();

    public virtual ICollection<Transakcija> Plaćanja { get; set; } = new List<Transakcija>();

    public virtual ICollection<Recenzija> Recenzije { get; set; } = new List<Recenzija>();

    public virtual ICollection<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();

    public ICollection<OmiljeneStavke> Omiljeno { get; set; } = new List<OmiljeneStavke>();


    [ForeignKey("UserId")]
    public Korisnik User { get; set; }


    public virtual ICollection<Planer> Planeri { get; set; } = new List<Planer>();
}
