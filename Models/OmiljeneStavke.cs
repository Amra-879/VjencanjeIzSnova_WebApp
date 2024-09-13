namespace VjencanjeIzSnova_WebApp.Models
{
    public class OmiljeneStavke
    {
       
          public int KlijentId { get; set; }
          public int UslugaId { get; set; }
          public Klijent klijent { get; set; }
          public Usluga usluga { get; set; }
        

    }

}
