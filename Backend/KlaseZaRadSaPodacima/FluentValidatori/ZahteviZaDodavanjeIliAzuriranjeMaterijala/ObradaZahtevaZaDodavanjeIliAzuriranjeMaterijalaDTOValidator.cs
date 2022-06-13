using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class ObradaZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTOValidator : AbstractValidator<ObradaZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO>
    {
        public ObradaZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTOValidator(IPomocnikParser pomocnikParser, PribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator pribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator)
        {
            Include(pribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator);
            Transform(zahtevZaObradu => zahtevZaObradu.Prihvacen, pomocnikParser.ParsiranjeBoolIzStringa).Cascade(CascadeMode.Stop)
                                                                                                         .NotNull()
                                                                                                         .WithMessage(zahtevZaObradu => Poruke.PotrebnoProslediti("Validan status prihvatanja (true/false)"));
        }
    }
}