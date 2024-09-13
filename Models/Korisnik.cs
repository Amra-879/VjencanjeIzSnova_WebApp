using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_WebApp.Models;

public partial class Korisnik : IdentityUser
{

    public string UserType { get; set; } = null!;

    public string? ProfilnaSlikaUrl { get; set; }

    public virtual Klijent? Klijent { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Planer? Planer { get; set; }


}
