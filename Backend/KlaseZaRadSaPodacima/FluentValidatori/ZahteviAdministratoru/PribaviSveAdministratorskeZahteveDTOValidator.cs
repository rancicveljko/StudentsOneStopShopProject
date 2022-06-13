using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.Servisi.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori
{
    public class PribaviSveAdministratorskeZahteveDTOValidator : AbstractValidator<PribaviSveAdministratorskeZahteveDTO>
    {
        public PribaviSveAdministratorskeZahteveDTOValidator(AutorISubjekatAdministratorskogZahtevaValidator autorISubjekatValidator,
                                                             VremeOdDoValidator vremeOdDoValidator,
                                                             TipZahtevaValidator tipZahtevaValidator,
                                                             IPomocnikParser pomocnikParser,
                                                             IndeksiValidator indeksiValidator,
                                                             KriterijumSortiranjaValidator kriterijumSortiranjaValidator)
        {
            Include(indeksiValidator);
            Include(autorISubjekatValidator);
            Include(vremeOdDoValidator);
            Include(tipZahtevaValidator);
            Include(kriterijumSortiranjaValidator);
        }
    }
}