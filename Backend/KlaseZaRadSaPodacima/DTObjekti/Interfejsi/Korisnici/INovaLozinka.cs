using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface INovaLozinka : IPotrebnaValidacijaPraznihPolja 
    {
        string NovaLozinka { get; set; }
    }
}