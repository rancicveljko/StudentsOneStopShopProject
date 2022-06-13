using System;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali
{
    public class KomentarIzlazniDTO
    {
        public string Tekst { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime VremeKomentarisanja { get; set; }
        public Uloga UlogaAutora { get; set; }
    }
}