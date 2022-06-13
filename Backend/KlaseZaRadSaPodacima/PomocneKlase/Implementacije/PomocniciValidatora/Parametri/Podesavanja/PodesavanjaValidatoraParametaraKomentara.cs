using System;
using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja
{
    public class PodesavanjaValidatoraParametaraKomentara : IPodesavanjaValidatoraParametaraKomentara
    {
        private readonly IKomentarRepozitorijum _komentarRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;

        public PodesavanjaValidatoraParametaraKomentara(IKomentarRepozitorijum komentarRepozitorijum,
                                                        IPomocnikParser pomocnikParser)
        {
            _komentarRepozitorijum = komentarRepozitorijum;
            _pomocnikParser = pomocnikParser;
        }
        public Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja => new Dictionary<Enum, PodesavanjaValidatoraParametaraStruct>()
        {
            {TipProverePostojanjaKomentara.Korisnicko_Ime_Autora, new PodesavanjaValidatoraParametaraStruct(vrednost => _komentarRepozitorijum.PostojiEntitetSaUslovom(komentar => komentar.Autor.KorisnickoIme.Equals(vrednost)),"sa navedenim korisničkim imenom autora","korisničkog imena autora")},
            {TipProverePostojanjaKomentara.Korisnicko_Ime_Autora_Iz_Kolacica, new PodesavanjaValidatoraParametaraStruct(vrednost => _komentarRepozitorijum.PostojiEntitetSaUslovom(komentar => komentar.Autor.KorisnickoIme.Equals(vrednost)),"čiji ste Vi autor","korisničkog imena autora")},
            {TipProverePostojanjaVremenaOdDo.Od_Vremena, new PodesavanjaValidatoraParametaraStruct(vrednost => _komentarRepozitorijum.PostojiEntitetSaUslovom(komentar => komentar.VremeKomentarisanja > _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost)),"vremenom komentarisanja većim od navedenog vremena","vremena komentarisanja")},
            {TipProverePostojanjaVremenaOdDo.Do_Vremena, new PodesavanjaValidatoraParametaraStruct(vrednost => _komentarRepozitorijum.PostojiEntitetSaUslovom(komentar => komentar.VremeKomentarisanja < _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost)),"vremenom komentarisanja manjim od navedenog vremena","vremena komentarisanja")}
        };
    }
}