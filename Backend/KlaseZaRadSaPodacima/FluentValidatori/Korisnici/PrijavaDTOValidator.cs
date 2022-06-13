using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici
{
    public class PrijavaDTOValidator : AbstractValidator<PrijavaDTO>
    {
        public PrijavaDTOValidator(IPomocnikParser pomocnikValidatoraParser, KorisnickoImeILozinkaValidator korisnickoImeILozinkaValidator)
        {
            Include(korisnickoImeILozinkaValidator);
            Transform(prijava => prijava.ZapamtiMe, pomocnikValidatoraParser.ParsiranjeBoolIzStringa).NotNull()
                                                                                                     .WithMessage(Poruke.PotrebnoProsleditiSaUslovom("Zapamti me", "sa validnom vrednošću (true/false)!"));
        }


    }
}