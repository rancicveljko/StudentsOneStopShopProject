using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali
{
    public interface IPutanjaMaterijala : IPutanja
    {
        string Naziv { get; set; }
        string Ekstenzija { get; set; }
    }
}