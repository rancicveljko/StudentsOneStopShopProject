using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IStatusKorisnickogNaloga : IPotrebnaValidacijaPraznihPolja, IOcekivanaVrednostPostojanja
    {
        string StatusNaloga { get; set; }
    }
}