using System;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class IstorijaIzmenaEntitet : AutorMaterijalKompozitniKljucEntitet
    {
        public IstorijaIzmenaEntitet()
        {
        }
        public IstorijaIzmenaEntitet(DateTime vremeIzmene,
                                     TipIzmene tipIzmene,
                                     KorisnickiNalogEntitet autor,
                                     MaterijalEntitet materijal)
        {
            VremeIzmene = vremeIzmene;
            TipIzmene = tipIzmene;
            Autor = autor;
            Materijal = materijal;
        }

        public DateTime VremeIzmene { get; set; }
        public TipIzmene TipIzmene { get; set; }
    }
}