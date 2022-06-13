using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali
{
    public interface IPutanjaNazivIEkstenzijaMaterijala : IPutanja, IOcekivanaVrednostPostojanja, IPotrebnaValidacijaPraznihPolja
    {
        string Naziv { get; set; }
        string Ekstenzija { get; set; }
    }
}