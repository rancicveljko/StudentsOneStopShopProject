using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Ocene
{
    public class DodajOcenuDTOValidator : AbstractValidator<DodajOcenuDTO>
    {
        public DodajOcenuDTOValidator(PutanjaNazivIEkstenzijaValidator putanjaNazivIEkstenzijaValidator,
                                      TipOceneValidator tipOceneValidator,
                                      IPomocnikValidatoraPutanje pomocnikValidatoraPutanje)
        {
            RuleFor(ocenaZaDodavanje => ocenaZaDodavanje).Must(ocenaZaDodavanje => pomocnikValidatoraPutanje.DopuniPutanju(ocenaZaDodavanje, true, false, out string poruka))
                                                         .SetValidator(putanjaNazivIEkstenzijaValidator);
            Include(tipOceneValidator);
        }
    }
}