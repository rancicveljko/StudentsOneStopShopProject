using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici
{
    public class PribaviKorisnickeNalogeDTOValidator : AbstractValidator<PribaviKorisnickeNalogeDTO>
    {
        public PribaviKorisnickeNalogeDTOValidator(ValidatoriZaPonovnoKoriscenje.Korisnici.KorisnickoImeValidator korisnickoImeValidator,
                                                   StatusKorisnickogNalogaValidator statusKorisnickogNalogaValidator,
                                                   UlogaValidator ulogaValidator,
                                                   IndeksiValidator indeksiValidator,
                                                   ImeIPrezimeValidator imeIPrezimeValidator,
                                                   IDBrojValidatorSaProveromUloge IDBrojValidatorSaProveromUloge,
                                                   EmailValidator emailValidator,
                                                   PrivilegijeOsnovnogKorisnikaValidator privilegijeOsnovnogKorisnikaValidator,
                                                   PutanjaValidator putanjaValidator,
                                                   KriterijumSortiranjaValidator kriterijumSortiranjaValidator)
        {
            Include(korisnickoImeValidator);
            Include(statusKorisnickogNalogaValidator);
            Include(ulogaValidator);
            Include(indeksiValidator);
            Include(emailValidator);
            Include(privilegijeOsnovnogKorisnikaValidator);
            Include(IDBrojValidatorSaProveromUloge);
            Include(imeIPrezimeValidator);
            Include(putanjaValidator);
            Include(kriterijumSortiranjaValidator);
        }


    }
}