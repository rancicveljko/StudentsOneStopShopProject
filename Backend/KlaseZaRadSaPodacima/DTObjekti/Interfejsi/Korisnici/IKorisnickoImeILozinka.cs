using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IKorisnickoImeILozinka : IKorisnickoIme
    {
        string Lozinka { get; set; }
    }
}