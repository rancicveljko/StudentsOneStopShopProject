using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class ZahtevAdministratoruEntitet : IEntitet, ITekstEntitet
    {
        public string Tekst { get; set; }
        public TipAdministratorskogZahteva Tip { get; set; }
        public DateTime VremeSlanja { get; set; }
        public int AutorID { get; set; }
        public KorisnickiNalogEntitet Autor { get; set; }
        public int SubjekatID { get; set; }
        public KorisnickiNalogEntitet Subjekat { get; set; }
    }
}