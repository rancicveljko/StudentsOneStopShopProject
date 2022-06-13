using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora
{
    public interface IPomocnikValidiranjaZajednickimValidatorima
    {
        bool validirajStringValidatorom(StringValidator stringValidator,
                                        string porukaZaNevalidanFormat,
                                        string porukaZaPraznoPolje,
                                        bool potrebnoValidiranjePraznogPolja,
                                        bool? ocekivanaVrednostPostojanja,
                                        string regexFormata,
                                        Enum tipProverePostojanja,
                                        string nazivUPorukamaProverePostojanja,
                                        IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                        OmotacStringa vrednost,
                                        out string poruka);
        bool validirajEnumValidatorom(EnumValidator enumValidator,
                                      bool potrebnoValidiranjePrazogPolja,
                                      string porukaZaPraznoPolje,
                                      string porukaZaEnumeracijuVanOpsega,
                                      bool? ocekivanaVrednostPostojanja,
                                      Enum tipProverePostojanja,
                                      string nazivUPorukamaProverePostojanja,
                                      IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                      OmotacEnumeracije vrednost,
                                      out string poruka);
        bool validirajIntegerValidatorom(IntegerValidator integerValidator,
                                         bool potrebnoValidiranjePrazogPolja,
                                         string porukaZaPraznoPolje,
                                         bool? ocekivanaVrednostPostojanja,
                                         Enum tipProverePostojanja,
                                         string nazivUPorukamaProverePostojanja,
                                         IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                         string porukaZaNevalidanFormat,
                                         string porukaZaManjeManjeOdDozvoljenog,
                                         string porukaZaVeceOdDozvoljenog,
                                         OmotacIntegera vrednost,
                                         out string poruka,
                                         int od = int.MinValue,
                                         int @do = int.MaxValue);
        bool validirajVremeValidatorom(VremeValidator vremeValidator,
                                       bool potrebnoValidiranjePrazogPolja,
                                       string porukaZaPraznoPolje,
                                       bool? ocekivanaVrednostPostojanja,
                                       Enum tipProverePostojanja,
                                       string nazivUPorukamaProverePostojanja,
                                       IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                       string porukaZaVeceOdDozvoljenog,
                                       string porukaZaNevalidanFormat,
                                       string porukaZaManjeManjeOdDozvoljenog,
                                       OmotacVremena vrednost,
                                       out string poruka,
                                       DateTime? od = null,
                                       DateTime? @do = null);
    }
}