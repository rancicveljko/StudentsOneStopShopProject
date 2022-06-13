using System.Linq;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using FluentValidation;
using FluentValidation.Results;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class PostojeceKorisnickoImeValidator : AbstractValidator<IPostojeceKorisnickoIme>
    {
        public PostojeceKorisnickoImeValidator(KorisnickoImeValidator korisnickoImeValidator)
        {
            ValidationResult rezultatValidacije = null;
            RuleFor(postojeceKorisnickoIme => postojeceKorisnickoIme).Must(postojeceKorisnickoIme => (rezultatValidacije = korisnickoImeValidator.Validate(new OmotacKorisnika(postojeceKorisnickoIme.PostojeceKorisnickoIme, true, true))).IsValid)
                                                                     .WithMessage(postojeceKorisnickoIme => rezultatValidacije.Errors.Select(greska => greska.ErrorMessage).FirstOrDefault())
                                                                     .WithName(postojeceKorisnickoIme => postojeceKorisnickoIme.NazivUPorukamaValidatora);
        }
    }
}