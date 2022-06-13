using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru
{
    public interface IAutorAdministratorskogZahteva : IPotrebnaValidacijaPraznihPolja, IOcekivanaVrednostPostojanja
    {
        string KorisnickoImeAutora { get; set; }
    }
}