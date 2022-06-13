using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici
{
    public class AzuriranjeNalogaDTOValidator : AbstractValidator<AzuriranjeNalogaDTO>
    {
        public AzuriranjeNalogaDTOValidator(ImeIPrezimeValidator imeIPrezimeValidator,
                                            EmailValidator emailValidator,
                                            ValidatoriZaPonovnoKoriscenje.Korisnici.KorisnickoImeValidator korisnickoImeValidator,
                                            IDBrojValidatorSaProveromUloge IDBrojValidatorSaProveromUloge,
                                            UlogaValidator ulogaValidator,
                                            StatusKorisnickogNalogaValidator statusKorisnickoNalogaValidator,
                                            PrivilegijeOsnovnogKorisnikaValidator privilegijeOsnovnogKorisnikaValidator,
                                            PostojeceKorisnickoImeValidator postojeceKorisnickoImeValidator,
                                            ListaPutanjaValidator listaPutanjaValidator)
        {
            Include(imeIPrezimeValidator);
            Include(emailValidator);
            Include(korisnickoImeValidator);
            Include(IDBrojValidatorSaProveromUloge);
            Include(ulogaValidator);
            Include(statusKorisnickoNalogaValidator);
            Include(privilegijeOsnovnogKorisnikaValidator);
            Include(postojeceKorisnickoImeValidator);
            Include(listaPutanjaValidator);
        }
    }
}