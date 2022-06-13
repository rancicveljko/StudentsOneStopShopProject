using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici
{
    public class KorisnickoImeDTOValidator : AbstractValidator<KorisnickoImeDTO>
    {
        public KorisnickoImeDTOValidator(KorisnickoImeValidator korisnickoImeValidator)
        {
            Include(korisnickoImeValidator);
        }
    }
}