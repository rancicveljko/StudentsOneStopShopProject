using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici
{
    public class KreiranjeKorisnikaDTOValidator : AbstractValidator<KreiranjeKorisnikaDTO>
    {
        public KreiranjeKorisnikaDTOValidator(UlogaValidator ulogaValidator,
                                              EmailValidator emailValidator,
                                              IDBrojValidatorSaProveromUloge IDBrojValidatorSaProveromUloge,
                                              ImeIPrezimeValidator imeIPrezimeValidator,
                                              ListaPutanjaValidator listaPutanjaOblastiValidator)
        {
            Include(imeIPrezimeValidator);
            Include(emailValidator);
            Include(ulogaValidator);
            Include(IDBrojValidatorSaProveromUloge);
            Include(listaPutanjaOblastiValidator);
        }
    }
}