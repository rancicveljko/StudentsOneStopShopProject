using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora
{
    public interface IPomocnikValidatoraPutanje
    {
        bool DopuniPutanju(IPutanja putanja, bool dodavanjeNaPraznuPutanju, bool proveriPutanjuKorena, out string poruka);
    }
}