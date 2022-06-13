using System.Collections.Generic;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti
{
    public class OblastInfoZaStabloDTO : OblastInfoZaKorisnikeDTO
    {
        public ICollection<string> NaziviMaterijala { get; set; } = null;
        public string PotrebnoOdobrenje { get; set; }
    }
}