using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Oblasti
{
    public class PutanjaOblastiDTOValidator : AbstractValidator<PutanjaOblastiDTO>
    {
        public PutanjaOblastiDTOValidator(PutanjaValidator putanjaValidator, IPomocnikValidatoraPutanje pomocnikValidatoraPutanje)
        {
            string poruka = null;
            RuleFor(putanjaOblasti => putanjaOblasti).Cascade(CascadeMode.Stop)
                                                           .Must(putanjaOblasti => pomocnikValidatoraPutanje.DopuniPutanju(putanjaOblasti, false, true, out poruka))
                                                           .WithMessage(putanjaOblasti => poruka)
                                                           .DependentRules(() =>
                                                            {
                                                                Include(putanjaValidator);
                                                            })
                                                            .WithName("Putanja");
        }
    }
}