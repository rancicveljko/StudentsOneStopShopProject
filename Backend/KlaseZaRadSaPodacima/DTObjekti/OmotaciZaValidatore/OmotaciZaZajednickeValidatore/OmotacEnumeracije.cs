using System;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore
{
    public class OmotacEnumeracije
    {
        public Enum ParsiranaVrednost { get; set; }
        public string StringVrednost { get; set; }

        public OmotacEnumeracije(Enum parsiranaVrednost, string stringVrednost)
        {
            ParsiranaVrednost = parsiranaVrednost;
            StringVrednost = stringVrednost;
        }
    }
}