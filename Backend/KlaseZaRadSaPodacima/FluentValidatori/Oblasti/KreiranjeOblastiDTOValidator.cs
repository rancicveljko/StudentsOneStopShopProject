using System;
using System.Linq;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using FluentValidation;
using FluentValidation.Results;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Oblasti
{
    public class KreiranjeOblastiDTOValidator : AbstractValidator<KreiranjeOblastiDTO>
    {
        public KreiranjeOblastiDTOValidator(IPomocnikParser pomocnikParser,
                                            IPomocnikManuelniValidator pomocnikManuelniValidator,
                                            IPomocnikValidatoraPutanje pomocnikValidatoraPutanje,
                                            NazivIPutanjaOblastiValidator nazivIPutanjaNadoblastiValidator)
        {
            string poruka = null;
            RuleFor(kreiranjeOblasti => kreiranjeOblasti).Must(kreiranjeOlasti => pomocnikValidatoraPutanje.DopuniPutanju(kreiranjeOlasti, true, false, out poruka))
                                                         .Must(kreiranjeOblasti => pomocnikManuelniValidator.manuelnoValidiraj<OmotacNazivaIPutanjeOblasti>(nazivIPutanjaNadoblastiValidator, new OmotacNazivaIPutanjeOblasti(kreiranjeOblasti.OcekivanaVrednostPostojanjaPutanje, kreiranjeOblasti.OcekivanaVrednostPostojanja, kreiranjeOblasti.PotrebnaValidacijaPraznihPoljaPutanje, kreiranjeOblasti.PotrebnaValidacijaPraznihPolja, kreiranjeOblasti.Naziv, kreiranjeOblasti.Putanja, null), out poruka))
                                                         .WithMessage(kreiranjeOblasti => poruka)
                                                         .WithName("PutanjaNadoblasti & Naziv");
            /* RuleFor(kreiranjeOblasti => kreiranjeOblasti).Cascade(CascadeMode.Stop)
                                                          .Must(kreiranjaOblasti => pomocnikValidatoraPutanje.DopuniPutanju(kreiranjaOblasti, true, false, out poruka))
                                                          .Must(kreiranjeOblasti => kreiranjeOblasti.Putanja != oblastRepozitorijum.PribaviAdresuPocetnogFoldera() ? pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, new OmotacPutanje(kreiranjeOblasti.Putanja, true, true), out poruka) : true)
                                                          .WithMessage(kreiranjeOblasti => poruka)
                                                          .WithName("PutanjaNadoblasti")
                                                          .DependentRules(() =>
                                                              {
                                                                  RuleFor(kreiranjeOblasti => kreiranjeOblasti).Cascade(CascadeMode.Stop)
                                                                                                               .Must(kreiranjeOblasti => !string.IsNullOrEmpty(kreiranjeOblasti.Naziv))
                                                                                                               .WithMessage(kreiranjeOblasti => Poruke.PotrebnoProslediti("Naziv"))
                                                                                                               .Must(kreiranjeOblasti => System.Text.RegularExpressions.Regex.IsMatch(kreiranjeOblasti.Naziv, Regex.slovaIBrojevi))
                                                                                                               .WithMessage(kreiranjeOblasti => Poruke.Sadrzi("Naziv", "samo slova i cifre"))
                                                                                                               .Must(kreiranjeOblasti => pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, new OmotacPutanje(kreiranjeOblasti.Putanja + "/" + kreiranjeOblasti.Naziv, true, false), out poruka))
                                                                                                               .WithMessage(kreiranjeOblasti => Poruke.VecPostoji("Oblast", "sa prosleđenim nazivom u prosleđenoj nadoblasti"))
                                                                                                               .WithName("Naziv");
                                                              });*/

            Transform(odobrenje => odobrenje.PotrebnoOdobrenje, pomocnikParser.ParsiranjeBoolIzStringa).NotNull()
                                                                                                     .WithMessage(Poruke.PotrebnoProsleditiSaUslovom("Potrebno odobrenje", "sa validnom vrednošću (true/false)!"));
        }
    }
}