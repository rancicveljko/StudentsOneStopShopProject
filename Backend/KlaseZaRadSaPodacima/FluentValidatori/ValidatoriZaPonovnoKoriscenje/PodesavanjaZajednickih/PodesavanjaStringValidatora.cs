using System;
using System.Collections.Generic;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih
{
    public class PodesavanjaStringValidatora : IPodesavanjaZajednickihValidatora
    {
        public IPomocnikValidatoraParametara Pomocnik { get; set; } = null;
        public bool? PotrebnoValidiranjePrazogPolja { get; set; } = null;
        public string PorukaZaPraznoPolje { get; set; } = null;
        public string RegexFormata { get; set; } = Regex.sveDozvoljeno;
        public string PorukaZaNevalidanFormat { get; set; } = null;
        public bool? OcekivanaVrednostPostojanja { get; set; } = null;
        public Enum TipProverePostojanja { get; set; } = null;
        public string NazivUPorukamaProverePostojanja { get; set; } = null;
        public IPodesavanjaValidatoraParametara PodesavanjaValidatoraParametara { get; set; } = null;
        public PodesavanjaStringValidatora()
        { }
        public PodesavanjaStringValidatora(IPomocnikValidatoraParametara pomocnik,
                                           bool potrebnoValidiranjePrazogPolja,
                                           string porukaZaPraznoPolje,
                                           string regexFormata,
                                           string porukaZaNevalidanFormat,
                                           bool? ocekivanaVrednostPostojanja,
                                           IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                           string nazivUPorukamaProverePostojanja,
                                           Enum tipProverePostojanja)
        {
            this.Pomocnik = pomocnik;
            PotrebnoValidiranjePrazogPolja = potrebnoValidiranjePrazogPolja;
            PorukaZaPraznoPolje = porukaZaPraznoPolje;
            RegexFormata = regexFormata;
            PorukaZaNevalidanFormat = porukaZaNevalidanFormat;
            OcekivanaVrednostPostojanja = ocekivanaVrednostPostojanja;
            this.PodesavanjaValidatoraParametara = podesavanjaValidatoraParametara;
            this.NazivUPorukamaProverePostojanja = nazivUPorukamaProverePostojanja;
            TipProverePostojanja = tipProverePostojanja;
        }
    }
}