using System;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih
{
    public class PodesavanjaEnumValidatora : IPodesavanjaZajednickihValidatora
    {
        public IPomocnikValidatoraParametara Pomocnik { get; set; } = null;
        public bool? PotrebnoValidiranjePrazogPolja { get; set; } = null;
        public string PorukaZaPraznoPolje { get; set; } = null;
        public bool? OcekivanaVrednostPostojanja { get; set; } = null;
        public Enum TipProverePostojanja { get; set; } = null;
        public string NazivUPorukamaProverePostojanja { get; set; } = null;
        public IPodesavanjaValidatoraParametara PodesavanjaValidatoraParametara { get; set; } = null;
        public string PorukaZaEnumeracijuVanOpsega { get; set; } = null;
        public PodesavanjaEnumValidatora()
        {

        }
        public PodesavanjaEnumValidatora(IPomocnikValidatoraParametara pomocnik,
                                         bool potrebnoValidiranjePrazogPolja,
                                         string porukaZaPraznoPolje,
                                         bool? ocekivanaVrednostPostojanja,
                                         Enum tipProverePostojanja,
                                         string nazivUPorukamaProverePostojanja,
                                         IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                         string porukaZaEnumeracijuVanOpsega)
        {
            this.Pomocnik = pomocnik;
            PotrebnoValidiranjePrazogPolja = potrebnoValidiranjePrazogPolja;
            PorukaZaPraznoPolje = porukaZaPraznoPolje;
            OcekivanaVrednostPostojanja = ocekivanaVrednostPostojanja;
            TipProverePostojanja = potrebnoValidiranjePrazogPolja ? NeProveravajPostojanje.Ne_Proveravaj_Postojanje : tipProverePostojanja;
            this.NazivUPorukamaProverePostojanja = nazivUPorukamaProverePostojanja;
            this.PodesavanjaValidatoraParametara = podesavanjaValidatoraParametara;
            PorukaZaEnumeracijuVanOpsega = porukaZaEnumeracijuVanOpsega;
        }
    }
}