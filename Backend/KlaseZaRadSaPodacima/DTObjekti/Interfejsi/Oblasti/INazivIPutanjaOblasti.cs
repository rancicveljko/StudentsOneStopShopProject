using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti
{
    public interface INazivIPutanjaOblasti : IPutanja, IOcekivanaVrednostPostojanja, IPotrebnaValidacijaPraznihPolja
    {
        string Naziv { get; set; }

    }
}