using System;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih.Interfejsi
{
    public interface IPodesavanjaZajednickihValidatora
    {
        IPomocnikValidatoraParametara Pomocnik { get; set; }
        bool? PotrebnoValidiranjePrazogPolja { get; set; }
        string PorukaZaPraznoPolje { get; set; }
        bool? OcekivanaVrednostPostojanja { get; set; }
        Enum TipProverePostojanja { get; set; }
        string NazivUPorukamaProverePostojanja { get; set; }
        IPodesavanjaValidatoraParametara PodesavanjaValidatoraParametara { get; set; }
    }
}