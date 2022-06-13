using System;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore
{
    public class OmotacVremena
    {
        public string UpakovanoVreme { get; set; } = null;

        public OmotacVremena(string upakovanoVreme)
        {
            UpakovanoVreme = upakovanoVreme;
        }
    }
}