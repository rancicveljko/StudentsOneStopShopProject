using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori
{
    public class PribaviTekstAdminstratorskogZahtevaDTOValidator : AbstractValidator<PribaviTekstAdministratorskogZahtevaDTO>
    {
        public PribaviTekstAdminstratorskogZahtevaDTOValidator(VremeSlanjaValidator vremeSlanjaValidator, AutorAdministratorskogZahtevaValidator autorValidator)
        {
            Include(vremeSlanjaValidator);
            Include(autorValidator);
        }
    }
}