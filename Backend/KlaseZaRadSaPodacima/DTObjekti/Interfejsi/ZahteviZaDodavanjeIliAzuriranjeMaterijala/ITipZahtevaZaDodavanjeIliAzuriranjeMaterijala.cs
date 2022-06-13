using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public interface ITipZahtevaZaDodavanjeIliAzuriranjeMaterijala : IOcekivanaVrednostPostojanja, IPotrebnaValidacijaPraznihPolja
    {
        string TipZahteva { get; set; }
    }
}