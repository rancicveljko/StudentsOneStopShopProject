using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru
{
    public interface IAutorISubjekatAdministratorskogZahteva : IAutorAdministratorskogZahteva
    {
        string KorisnickoImeSubjekta { get; set; }
    }
}