using System;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki
{
    public interface IVremeOdDo
    {
        string OdVreme { get; set; }
        string DoVreme { get; set; }
        string NazivUPorukamaPostojanjaVremeOdDo { get; }
        Type PodesavanjaValidatoraParametaraVremeOdDo { get; }
    }
}