using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IKorisnickoIme : IOcekivanaVrednostPostojanja, IPotrebnaValidacijaPraznihPolja
    {
        string KorisnickoIme { get; set; }

    }
}