
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class OcenaEntitet : AutorMaterijalKompozitniKljucEntitet
    {
        public OcenaEntitet()
        {
        }

        public OcenaEntitet(TipOcene tipOcene,
                            KorisnickiNalogEntitet autor,
                            MaterijalEntitet materijal)
        {
            Autor = autor;
            Materijal = materijal;
            TipOcene = tipOcene;
        }

        public TipOcene TipOcene { get; set; }
    }
}