using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IEmail : IOcekivanaVrednostPostojanja, IPotrebnaValidacijaPraznihPolja
    {
        string Email { get; set; }
    }
}