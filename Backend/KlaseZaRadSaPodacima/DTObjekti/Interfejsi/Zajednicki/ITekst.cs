using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki
{
    public interface ITekst : IPotrebnaValidacijaPraznihPolja
    {
        string Tekst { get; set; }
        int MaxDuzina { get; }
        string NazivUPorukamaPostojanjaValidatoraTeksta { get; }
    }
}