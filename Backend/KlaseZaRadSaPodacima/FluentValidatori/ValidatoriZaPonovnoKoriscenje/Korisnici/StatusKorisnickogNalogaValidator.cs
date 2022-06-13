using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class StatusKorisnickogNalogaValidator : AbstractValidator<IStatusKorisnickogNaloga>
    {
        public StatusKorisnickogNalogaValidator(IPomocnikParser pomocnikParser,
                                                IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                                IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika,
                                                EnumValidator enumValidator)
        {
            string poruka = null;
            RuleFor(statusNaloga => statusNaloga).Cascade(CascadeMode.Stop)
                                                .Must(statusNaloga => pomocnikValidiranjaZajednickimValidatorima.validirajEnumValidatorom(enumValidator,
                                                                                                                                          statusNaloga.PotrebnaValidacijaPraznihPolja,
                                                                                                                                          Poruke.PotrebnoProslediti("Validan status"),
                                                                                                                                          Poruke.EnumUValidnomOpsegu("Status"),
                                                                                                                                          statusNaloga.OcekivanaVrednostPostojanja,
                                                                                                                                          TipProverePostojanjaKorisnika.Status_Naloga,
                                                                                                                                          "Nijedan korisnik",
                                                                                                                                          podesavanjaValidatoraParametaraKorisnika,
                                                                                                                                          new OmotacEnumeracije(pomocnikParser.ParsiranjeStatusaKorisnickogNalogaIzString(statusNaloga.StatusNaloga), statusNaloga.StatusNaloga),
                                                                                                                                          out poruka))
                                                .WithMessage(statusNaloga => poruka)
                                                .WithName("StatusNaloga");
        }
    }
}