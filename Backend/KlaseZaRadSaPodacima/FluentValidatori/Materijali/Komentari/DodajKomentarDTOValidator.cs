using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Komentari
{
    public class DodajKomentarDTOValidator : AbstractValidator<DodajKomentarDTO>
    {
        public DodajKomentarDTOValidator(IPomocnikValidatoraPutanje pomocnikValidatoraPutanje,
                                           TekstValidator tekstValidator,
                                           PutanjaNazivIEkstenzijaValidator putanjaNazivIEkstenzijaValidator,
                                           VremeSlanjaValidator vremeSlanjaValidator)
        {
            Include(tekstValidator);
            RuleFor(komentarZaDodavanje => komentarZaDodavanje).Must(komenarZaDodavanje => pomocnikValidatoraPutanje.DopuniPutanju(komenarZaDodavanje,
                                                                                                                                   true,
                                                                                                                                   false,
                                                                                                                                   out string poruka))
                                                               .SetValidator(putanjaNazivIEkstenzijaValidator);
                                                            //   .SetValidator();
           // Include(vremeSlanjaValidator);
        }
    }
}