using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Oblasti
{
    public class PremestanjeOblastiDTOValidator : AbstractValidator<PremestanjeOblastiDTO>
    {
        public PremestanjeOblastiDTOValidator(PutanjaValidator putanjaValidator,
                                              IPomocnikManuelniValidator pomocnikManuelniValidator,
                                              IPomocnikValidatoraPutanje pomocnikValidatoraPutanje,
                                              IOblastRepozitorijum oblastRepozitorijum)
        {
            string poruka = null;
            RuleFor(azuriranjeOblasti => azuriranjeOblasti).Cascade(CascadeMode.Stop)
                                                           .Must(premestanjeOblasti => pomocnikValidatoraPutanje.DopuniPutanju(premestanjeOblasti, false, true, out poruka))
                                                           .WithMessage(premestanjeOblasti => poruka)
                                                           .DependentRules(() =>
                                                            {
                                                                Include(putanjaValidator);
                                                            })
                                                            .WithName("Putanja");
            RuleFor(premestanjeOblasti => premestanjeOblasti.PutanjaNoveNadoblasti).Must(putanja => System.Text.RegularExpressions.Regex.IsMatch(putanja, Regex.putanja))
                                                                                   .When(putanja => !string.IsNullOrEmpty(putanja.PutanjaNoveNadoblasti) && putanja.PutanjaNoveNadoblasti != oblastRepozitorijum.PribaviAdresuPocetnogFoldera());
        }
    }
}