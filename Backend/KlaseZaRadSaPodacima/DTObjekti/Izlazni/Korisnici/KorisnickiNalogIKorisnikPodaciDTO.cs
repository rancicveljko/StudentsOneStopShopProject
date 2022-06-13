using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici
{
    public class KorisnickiNalogIKorisnikPodaciDTO
    {
        public Uloga Uloga { get; set; }
        public string KorisnickoIme { get; set; }
        public string Ime { get; set; } = null;
        public string Prezime { get; set; } = null;

    }
}