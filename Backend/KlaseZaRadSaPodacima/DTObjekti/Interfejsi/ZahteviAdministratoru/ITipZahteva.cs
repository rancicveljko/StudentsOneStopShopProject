using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru
{
    public interface ITipZahteva : IPotrebnaValidacijaPraznihPolja, IOcekivanaVrednostPostojanja
    {
        string Tip { get; set; } 
    }
}