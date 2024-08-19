using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Planer
{
    public int PlanerId { get; set; }

    public string UserId { get; set; }

    public int? BrTrenutnihKlijenata { get; set; }

    public string? ZoomMeetingLink { get; set; }

    [ForeignKey("UserId")]
    public Korisnik User { get; set; }

    public virtual ICollection<Klijent> Klijenti { get; set; } = new List<Klijent>();
}
