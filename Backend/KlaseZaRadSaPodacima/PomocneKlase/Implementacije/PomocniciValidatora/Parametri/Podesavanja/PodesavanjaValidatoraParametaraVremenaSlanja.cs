using System;
using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja
{
    public class PodesavanjaValidatoraParametaraVremenaSlanja : IPodesavanjaValidatoraParametaraVremenaSlanja
    {
        private readonly IAdministratorskiZahtevRepozitorijum _administratorskiZahtevRepozitorijum;
        private readonly IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;
        private readonly IKomentarRepozitorijum _komentarRepozitorijum;

        public PodesavanjaValidatoraParametaraVremenaSlanja(IAdministratorskiZahtevRepozitorijum administratorskiZahtevRepozitorijum,
                                                            IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                                                            IPomocnikParser pomocnikParser,
                                                            IKomentarRepozitorijum komentarRepozitorijum)
        {
            _administratorskiZahtevRepozitorijum = administratorskiZahtevRepozitorijum;
            _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum = zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
            _pomocnikParser = pomocnikParser;
            _komentarRepozitorijum = komentarRepozitorijum;
        }
        public Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja => new Dictionary<Enum, PodesavanjaValidatoraParametaraStruct>()
        {
            { TipProverePostojanjaAdministratorskihZahteva.Vreme_Slanja, new PodesavanjaValidatoraParametaraStruct(vrednost => _administratorskiZahtevRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.VremeSlanja.Equals(_pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost))), "navedenim vremenom slanja", "vremena slanja administratorskog zahteva") },
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Vreme_Slanja,new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.VremeSlanja.Equals(_pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost))),"navedenim vremenom slanja","vremena slanja zahteva za dodavanje ili ažuriranje materijala")},
            { TipProverePostojanjaKomentara.Vreme_Slanja,new PodesavanjaValidatoraParametaraStruct(vrednost => _komentarRepozitorijum.PostojiEntitetSaUslovom(komentar => komentar.VremeKomentarisanja.Equals(_pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost))),"navedenim vremenom komentarisanja", "vremena komentarisanja")}
        };
    }
}