using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTOValidator : AbstractValidator<PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTO>
    {
        public PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTOValidator(AutorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator autorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator,
                                                                               VremeOdDoValidator vremeOdDoValidator,
                                                                               IndeksiValidator indeksiValidator,
                                                                               TipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator tipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator,
                                                                               PutanjaNazivIEkstenzijaMaterijalaZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator putanjaNazivIEkstenzijaMaterijalaZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator)
        {
            Include(autorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator);
            Include(putanjaNazivIEkstenzijaMaterijalaZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator);
            Include(indeksiValidator);
            Include(vremeOdDoValidator);
            Include(tipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator);
        }
    }
}