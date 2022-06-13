using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using System;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public abstract class AutorMaterijalKompozitniKljucEntitet : IEntitet
    {
        public int AutorID { get; set; }
        public KorisnickiNalogEntitet Autor { get; set; }
        public Guid MaterijalID { get; set; }
        public MaterijalEntitet Materijal { get; set; }
    }
}