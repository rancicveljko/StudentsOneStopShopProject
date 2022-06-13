using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Ocene
{
    public class PribaviUkupnuOcenuIKorisnickuOcenuDTOValidator : AbstractValidator<PribaviUkupnuOcenuIKorisnickuOcenuDTO>
    {
        public PribaviUkupnuOcenuIKorisnickuOcenuDTOValidator(IPomocnikValidatoraPutanje pomocnikValidatoraPutanje, PutanjaNazivIEkstenzijaValidator putanjaNazivIEkstenzijaValidator)
        {
            RuleFor(ukupnaOcena => ukupnaOcena).Must(ukupnaOcena => pomocnikValidatoraPutanje.DopuniPutanju(ukupnaOcena, true, false, out string poruka))
                                               .SetValidator(putanjaNazivIEkstenzijaValidator);
        }
    }
}