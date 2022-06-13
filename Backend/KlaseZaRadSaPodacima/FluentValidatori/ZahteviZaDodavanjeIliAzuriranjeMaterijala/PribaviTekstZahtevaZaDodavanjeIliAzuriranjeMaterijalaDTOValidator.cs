using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTOValidator : AbstractValidator<PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO>
    {
        public PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTOValidator(PribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator pribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator)
        {
            Include(pribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator);
        }
    }
}