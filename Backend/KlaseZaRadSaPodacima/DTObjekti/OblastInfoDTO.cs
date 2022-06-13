using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti
{
    public class OblastInfoDTO
    {
        public string Putanja { get; set; }
        public string Naziv { get; set; }
        public string PotrebnoOdobrenje { get; set; }
        public ICollection<string> NaziviPodoblasti { get; set; } = null;
        public ICollection<string> NaziviMaterijala { get; set; } = null;
    }
}