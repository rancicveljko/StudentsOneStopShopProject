using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ZahteviAdministratoru
{
    public class ObradaZahtevaAdministratoruDTOValidator : AbstractValidator<ObradaZahtevaAdministratoruDTO>
    {
        public ObradaZahtevaAdministratoruDTOValidator(VremeSlanjaValidator vremeSlanjaValidator,
                                                       AutorAdministratorskogZahtevaValidator autorValidator,
                                                       IPomocnikParser pomocnik)
        {
            Include(vremeSlanjaValidator);
            Include(autorValidator);

            Transform(zahtev => zahtev.Prihvacen, pomocnik.ParsiranjeBoolIzStringa).Cascade(CascadeMode.Stop)
                                                                                   .NotNull()
                                                                                   .WithMessage(Poruke.PotrebnoProslediti("Validan status prihvatanja (true/false)"));
        }
    }
}