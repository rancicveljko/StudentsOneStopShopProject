using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki
{
    public interface IVremeSlanja : IPotrebnaValidacijaPraznihPolja
    {
        string VremeSlanja { get; set; }
        bool VremeSlanjaDodaja { get; }
        Enum TipProverePostojanja { get; }
        string NaizvUPorukamaPostojanjaVremeSlanja { get; }
    }
}