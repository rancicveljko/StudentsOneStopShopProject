using System;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki
{
    public interface IKriterijumSortiranja
    {
        string KriterijumSortiranja { get; set; }
        Type TipEnumeracije { get; }
    }
}