using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali
{
    public class UkupnaOcenaIKorisnickaOcenaDTO
    {
        public UkupnaOcenaIKorisnickaOcenaDTO(int ukupnaOcena,
                                              TipOcene? tipOcene)
        {
            UkupnaOcena = ukupnaOcena;
            TipOcene = tipOcene;
        }

        public int UkupnaOcena { get; set; }
        public TipOcene? TipOcene { get; set; }
    }
}