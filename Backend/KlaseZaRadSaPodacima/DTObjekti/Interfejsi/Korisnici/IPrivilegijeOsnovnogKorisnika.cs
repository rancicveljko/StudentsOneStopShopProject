using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IPrivilegijeOsnovnogKorisnika : IUloga
    {
        string Privilegije { get; set; }
    }
}