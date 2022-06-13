using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti
{
    public class OblastInfoZaKorisnikeDTO
    {
        public string Putanja { get; set; }
        public string Naziv { get; set; }
        public ICollection<string> NaziviPodoblasti { get; set; } = null;

    }
}