using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Ocene
{
    public interface ITipOcene : IPotrebnaValidacijaPraznihPolja
    {
        string TipOcene { get; set; }
        bool OcekivanaVrednostPostojanjaOcene { get; }
    }
}