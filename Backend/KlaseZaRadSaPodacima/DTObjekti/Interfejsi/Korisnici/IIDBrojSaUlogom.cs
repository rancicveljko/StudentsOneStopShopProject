using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici
{
    public interface IIDBrojSaUlogom : IUloga, IOcekivanaVrednostPostojanja
    {
        string IDBroj { get; set; }
    }
}