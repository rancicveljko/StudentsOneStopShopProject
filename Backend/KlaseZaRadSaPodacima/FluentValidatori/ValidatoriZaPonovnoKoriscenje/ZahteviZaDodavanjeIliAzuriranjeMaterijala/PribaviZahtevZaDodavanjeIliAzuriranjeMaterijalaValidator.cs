using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class PribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator : AbstractValidator<IPribaviZahtevZaDodavanjeIliAzuriranjeMaterijala>
    {
        public PribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaValidator(VremeSlanjaValidator vremeSlanjaValidator,
                                                                        AutorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator autorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator,
                                                                        PutanjaNazivIEkstenzijaMaterijalaZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator putanjaNazivIEkstenzijaMaterijalaZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator)
        {
            Include(vremeSlanjaValidator);
            Include(autorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator);
            Include(putanjaNazivIEkstenzijaMaterijalaZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator);
        }
    }
}