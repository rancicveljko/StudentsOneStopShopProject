using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IImeIPrezime : IPotrebnaValidacijaPraznihPolja, IOcekivanaVrednostPostojanja
    {
        string Ime { get; set; }
        string Prezime { get; set; }
    }
}