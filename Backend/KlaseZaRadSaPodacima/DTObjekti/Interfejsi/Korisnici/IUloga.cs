using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IUloga : IPotrebnaValidacijaPraznihPolja, IOcekivanaVrednostPostojanja
    {
        string Uloga { get; set; }
    }
}