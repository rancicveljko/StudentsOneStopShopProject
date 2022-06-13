using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki
{
    public interface IListaPutanjaOblasti : IPotrebnaValidacijaPraznihPolja, IUloga
    {
        List<string> PutanjeOblasti { get; set; }
    }
}