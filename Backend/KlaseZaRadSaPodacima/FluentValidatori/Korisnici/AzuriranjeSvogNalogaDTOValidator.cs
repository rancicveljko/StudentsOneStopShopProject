using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici
{
    public class AzuriranjeSvogNalogaDTOValidator : AbstractValidator<AzuriranjeSvogNalogaDTO>
    {
        public AzuriranjeSvogNalogaDTOValidator(EmailValidator emailValidator,
                                                KorisnickoImeILozinkaValidator KorisnickoImeILozinkaValidator,
                                                NovaLozinkaValidator novaLozinkaValidator)
        {
            Include(emailValidator);
            Include(KorisnickoImeILozinkaValidator);
            Include(novaLozinkaValidator);
        }
    }
}