using System;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class KorisnickiNalogOblastEntitet : IEntitet
    {
        public int NadlezniID { get; set; }
        public KorisnickiNalogEntitet Nadlezni { get; set; }
        public Guid OblastID { get; set; }
        public OblastEntitet Oblast { get; set; }
    }
}