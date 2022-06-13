using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Oblasti
{
    public class PutanjaOblastiZaPregledSadrzajaDTOValidator : AbstractValidator<PutanjaOblastiZaPregledSadrzajaDTO>
    {
        public PutanjaOblastiZaPregledSadrzajaDTOValidator(IPomocnikValidatoraPutanje pomocnikValidatoraPutanje, PutanjaValidator putanjaValidator)
        {
            string poruka = null;
            RuleFor(oblastZaPregledSadrzaja => oblastZaPregledSadrzaja).Cascade(CascadeMode.Stop)
                                                           .Must(oblastZaPregledSadrzaja => pomocnikValidatoraPutanje.DopuniPutanju(oblastZaPregledSadrzaja, true, false, out poruka))
                                                           .WithMessage(oblastZaPregledSadrzaja => poruka)
                                                           .DependentRules(() =>
                                                            {
                                                                Include(putanjaValidator);
                                                            })
                                                            .WithName("Putanja");
        }
    }
}