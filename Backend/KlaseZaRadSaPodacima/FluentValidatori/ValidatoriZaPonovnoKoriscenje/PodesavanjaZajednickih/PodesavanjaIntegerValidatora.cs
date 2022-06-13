using System;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih
{
    public class PodesavanjaIntegerValidatora : IPodesavanjaZajednickihValidatora
    {
        public PodesavanjaIntegerValidatora()
        {
        }
        public PodesavanjaIntegerValidatora(IPomocnikValidatoraParametara pomocnik,
                                            bool potrebnoValidiranjePrazogPolja,
                                            string porukaZaPraznoPolje,
                                            bool? ocekivanaVrednostPostojanja,
                                            Enum tipProverePostojanja,
                                            string nazivUPorukamaProverePostojanja,
                                            IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                            int od,
                                            int @do,
                                            string porukaZaNevalidanFormat,
                                            string porukaZaManjeManjeOdDozvoljenog,
                                            string porukaZaVeceOdDozvoljenog)
        {
            this.Pomocnik = pomocnik;
            PotrebnoValidiranjePrazogPolja = potrebnoValidiranjePrazogPolja;
            PorukaZaPraznoPolje = porukaZaPraznoPolje;
            OcekivanaVrednostPostojanja = ocekivanaVrednostPostojanja;
            TipProverePostojanja = tipProverePostojanja;
            NazivUPorukamaProverePostojanja = nazivUPorukamaProverePostojanja;
            PodesavanjaValidatoraParametara = podesavanjaValidatoraParametara;
            Od = od;
            Do = @do;
            PorukaZaNevalidanFormat = porukaZaNevalidanFormat;
            PorukaZaManjeManjeOdDozvoljenog = porukaZaManjeManjeOdDozvoljenog;
            PorukaZaVeceOdDozvoljenog = porukaZaVeceOdDozvoljenog;
        }

        public IPomocnikValidatoraParametara Pomocnik { get; set; } = null;
        public bool? PotrebnoValidiranjePrazogPolja { get; set; } = null;
        public string PorukaZaPraznoPolje { get; set; } = null;
        public bool? OcekivanaVrednostPostojanja { get; set; } = null;
        public Enum TipProverePostojanja { get; set; } = null;
        public string NazivUPorukamaProverePostojanja { get; set; } = null;
        public IPodesavanjaValidatoraParametara PodesavanjaValidatoraParametara { get; set; } = null;
        public int? Od { get; set; } = null;
        public int? Do { get; set; } = null;
        public string PorukaZaNevalidanFormat { get; set; } = null;
        public string PorukaZaManjeManjeOdDozvoljenog { get; set; } = null;
        public string PorukaZaVeceOdDozvoljenog { get; set; } = null;

    }
}