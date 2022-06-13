using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali
{
    public class NazivIPutanjaValidator : AbstractValidator<INaziviPutanjaMaterijala>
    {
        public NazivIPutanjaValidator(IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                      StringValidator stringValidator,
                                      IPodesavanjaValidatoraParametaraMaterijala podesavanjaValidatoraParametaraMaterijala,
                                      IPomocnikManuelniValidator pomocnikManuelniValidator,
                                      PutanjaValidator putanjaValidator)
        {
            //string poruka = null;
            RuleFor(nazivIPutanja => nazivIPutanja).Cascade(CascadeMode.Stop)
                                                   .SetValidator(putanjaValidator)
                                                   //.Must(nazivIPitanja => pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator,nazivIPitanja,out poruka))
                                                  // .WithMessage(nazivIPutanja => poruka)
                                                   .WithName("Putanja")
                                                   .DependentRules(() =>
                                                   {
                                                       RuleFor(nazivIPutanja => nazivIPutanja);
                                                   });
                                                   
            /*RuleFor(naziv => naziv).Cascade(CascadeMode.Stop)
                                                   .Must(naziv => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                        Poruke.PotrebnoProsleditiSaUslovom("Naziv materijala", "neprazno"),
                                                                                                                                        Poruke.PotrebnoProslediti("Naziv materijala"),
                                                                                                                                        naziv.PotrebnaValidacijaPraznihPolja,
                                                                                                                                        naziv.OcekivanaVrednostPostojanja,
                                                                                                                                        Regex.sveDozvoljeno,
                                                                                                                                        naziv.OcekivanaVrednostPostojanja ? TipProverePostojanjaMaterijala.Naziv_Materijala : NeProveravajPostojanje.Ne_Proveravaj_Postojanje,
                                                                                                                                        "Materijal",
                                                                                                                                        podesavanjaValidatoraParametaraMaterijala,
                                                                                                                                        new OmotacStringa(naziv.NazivMaterijala),
                                                                                                                                        out poruka))
                                                   .WithMessage(naziv => poruka)
                                                   .WithName("NazivMaterijala");

            RuleFor(putanja => putanja).Cascade(CascadeMode.Stop)
                                                   .Must(putanja => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                          Poruke.PotrebnoProsleditiSaUslovom("Nadoblast putanja", "neprazno"),
                                                                                                                                          Poruke.PotrebnoProslediti("Nadoblast putanja"),
                                                                                                                                          putanja.PotrebnaValidacijaPraznihPolja,
                                                                                                                                          putanja.OcekivanaVrednostPostojanja,
                                                                                                                                          Regex.sveDozvoljeno,
                                                                                                                                          putanja.OcekivanaVrednostPostojanja ? TipProverePostojanjaMaterijala.Nadoblast_Putanja_Materijala : NeProveravajPostojanje.Ne_Proveravaj_Postojanje,
                                                                                                                                          "Nadoblast",
                                                                                                                                          podesavanjaValidatoraParametaraMaterijala,
                                                                                                                                          new OmotacStringa(putanja.NadoblastPutanjaMaterijala),
                                                                                                                                          out poruka))
                                                   .WithMessage(putanja => poruka)
                                                   .WithName("NadoblastMaterijalPutanja");*/
        }
    }
}