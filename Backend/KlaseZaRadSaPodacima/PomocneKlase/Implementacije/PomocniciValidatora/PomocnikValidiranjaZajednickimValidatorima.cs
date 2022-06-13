using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora
{
    public class PomocnikValidiranjaZajednickimValidatorima : IPomocnikValidiranjaZajednickimValidatorima
    {
        private readonly IPomocnikValidatoraParametara _pomocnikValidatoraParametara;
        private readonly IPomocnikManuelniValidator _pomocnikManuelniValidator;

        public PomocnikValidiranjaZajednickimValidatorima(IPomocnikValidatoraParametara pomocnikValidatoraParametara,
                                                          IPomocnikManuelniValidator pomocnikManuelniValidator)
        {
            _pomocnikValidatoraParametara = pomocnikValidatoraParametara;
            _pomocnikManuelniValidator = pomocnikManuelniValidator;
        }

        public bool validirajEnumValidatorom(EnumValidator enumValidator,
                                             bool potrebnoValidiranjePrazogPolja,
                                             string porukaZaPraznoPolje,
                                             string porukaZaEnumeracijuVanOpsega,
                                             bool? ocekivanaVrednostPostojanja,
                                             Enum tipProverePostojanja,
                                             string nazivUPorukamaProverePostojanja,
                                             IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                             OmotacEnumeracije vrednost,
                                             out string poruka)
        {
            enumValidator.Podesavanja = new PodesavanjaEnumValidatora(_pomocnikValidatoraParametara,
                                                                      potrebnoValidiranjePrazogPolja,
                                                                      porukaZaPraznoPolje,
                                                                      ocekivanaVrednostPostojanja,
                                                                      tipProverePostojanja,
                                                                      nazivUPorukamaProverePostojanja,
                                                                      podesavanjaValidatoraParametara,
                                                                      porukaZaEnumeracijuVanOpsega);
            return _pomocnikManuelniValidator.manuelnoValidiraj(enumValidator, vrednost, out poruka);
        }

        public bool validirajIntegerValidatorom(IntegerValidator integerValidator,
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
                                                int @do = int.MaxValue)
        {
            integerValidator.Podesavanja = new PodesavanjaIntegerValidatora(_pomocnikValidatoraParametara,
                                                                            potrebnoValidiranjePrazogPolja,
                                                                            porukaZaPraznoPolje,
                                                                            ocekivanaVrednostPostojanja,
                                                                            tipProverePostojanja,
                                                                            nazivUPorukamaProverePostojanja,
                                                                            podesavanjaValidatoraParametara,
                                                                            od,
                                                                            @do,
                                                                            porukaZaNevalidanFormat,
                                                                            porukaZaManjeManjeOdDozvoljenog,
                                                                            porukaZaVeceOdDozvoljenog);

            return _pomocnikManuelniValidator.manuelnoValidiraj(integerValidator, vrednost, out poruka);
        }

        public bool validirajStringValidatorom(StringValidator stringValidator,
                                               string porukaZaNevalidanFormat,
                                               string porukaZaPraznoPolje,
                                               bool potrebnoValidiranjePraznogPolja,
                                               bool? ocekivanaVrednostPostojanja,
                                               string regexFormata,
                                               Enum tipProverePostojanja,
                                               string nazivUPorukamaProverePostojanja,
                                               IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                               OmotacStringa vrednost,
                                               out string poruka)
        {
            stringValidator.Podesavanja = new PodesavanjaStringValidatora(_pomocnikValidatoraParametara,
                                                                          potrebnoValidiranjePraznogPolja,
                                                                          porukaZaPraznoPolje,
                                                                          regexFormata,
                                                                          porukaZaNevalidanFormat,
                                                                          ocekivanaVrednostPostojanja,
                                                                          podesavanjaValidatoraParametara,
                                                                          nazivUPorukamaProverePostojanja,
                                                                          tipProverePostojanja);

            return _pomocnikManuelniValidator.manuelnoValidiraj(stringValidator, vrednost, out poruka);
        }

        public bool validirajVremeValidatorom(VremeValidator vremeValidator,
                                              bool potrebnoValidiranjePrazogPolja,
                                              string porukaZaPraznoPolje,
                                              bool? ocekivanaVrednostPostojanja,
                                              Enum tipProverePostojanja,
                                              string nazivUPorukamaProverePostojanja,
                                              IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                              string porukaZaVeceOdDozvoljenog,
                                              string porukaZaNevalidanFormat,
                                              string porukaZaManjeOdDozvoljenog,
                                              OmotacVremena vrednost,
                                              out string poruka,
                                              DateTime? od = null,
                                              DateTime? @do = null)
        {
            if (od == null) od = DateTime.MinValue.ToUniversalTime();
            if (@do == null) @do = DateTime.MaxValue.ToUniversalTime();
            vremeValidator.Podesavanja = new PodesavanjaVremeValidatora(_pomocnikValidatoraParametara,
                                                                        potrebnoValidiranjePrazogPolja,
                                                                        porukaZaPraznoPolje,
                                                                        ocekivanaVrednostPostojanja,
                                                                        tipProverePostojanja,
                                                                        nazivUPorukamaProverePostojanja,
                                                                        podesavanjaValidatoraParametara,
                                                                        (DateTime)od,
                                                                        (DateTime)@do,
                                                                        porukaZaNevalidanFormat,
                                                                        porukaZaManjeOdDozvoljenog,
                                                                        porukaZaVeceOdDozvoljenog);

            return _pomocnikManuelniValidator.manuelnoValidiraj(vremeValidator, vrednost, out poruka);
        }
    }
}