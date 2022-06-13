using System;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora
{
    public class PomocnikManuelniValidator : IPomocnikManuelniValidator
    {
        public bool manuelnoValidiraj<TValidacije>(IValidator<TValidacije> validator,
                                                   TValidacije zaValidiranje,
                                                   out string poruka)
        {

            var statusValidacije = validator.Validate(zaValidiranje);
            var greske = statusValidacije.Errors.Select(error => error.ErrorMessage).ToList();
            // var greskeString = string.Join("", greske);
            poruka = greske.FirstOrDefault();
            return statusValidacije.IsValid;
        }
    }
}