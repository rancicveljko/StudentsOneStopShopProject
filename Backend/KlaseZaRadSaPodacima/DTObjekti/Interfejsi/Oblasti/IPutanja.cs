using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti
{
    public interface IPutanja
    {
        string Putanja { get; set; }
        bool OcekivanaVrednostPostojanjaPutanje { get; }
        bool PotrebnaValidacijaPraznihPoljaPutanje { get; }
    }
}