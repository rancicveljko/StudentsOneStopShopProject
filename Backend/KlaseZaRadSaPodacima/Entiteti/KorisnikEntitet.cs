
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class KorisnikEntitet : IEntitet
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public KorisnickiNalogEntitet KorisnickiNalog { get; set; }
        public OsnovniKorisnikPodaciEntitet OsnovniKorisnikPodaci { get; set; }
    }
}