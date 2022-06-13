using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti
{
    public interface IPotrebnoOdobrenje: IOcekivanaVrednostPostojanja, IPotrebnaValidacijaPraznihPolja
    {
        string PotrebnoOdobrenje { get; set; }
    }
}