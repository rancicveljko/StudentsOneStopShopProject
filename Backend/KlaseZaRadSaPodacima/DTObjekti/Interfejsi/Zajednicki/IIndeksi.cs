using System;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki
{
    public interface IIndeksi
    {
        string OdIndeksa { get; set; }
        string Koliko { get; set; }
        Type Repozitorijum { get; }
        string parametarPorukeValidacijeIndeksa { get; }
    }
}