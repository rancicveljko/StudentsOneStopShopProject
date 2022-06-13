using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici
{
    public class KorisnickiNalogDTO
    {
        public Uloga Uloga { get; set; }
        public string KorisnickoIme { get; set; }
        public StatusKorisnickogNaloga StatusNaloga { get; set; }
    }
}