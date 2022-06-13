using System;
using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja
{
    public class PodesavanjaValidatoraParametaraAdministratorskihZahteva : IPodesavanjaValidatoraParametaraAdministratorskihZahteva
    {
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;
        private readonly IAdministratorskiZahtevRepozitorijum _administratorskiZahtevRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;

        public PodesavanjaValidatoraParametaraAdministratorskihZahteva(IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                                                       IAdministratorskiZahtevRepozitorijum administratorskiZahtevRepozitorijum,
                                                                       IPomocnikParser pomocnikParser)
        {
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
            _administratorskiZahtevRepozitorijum = administratorskiZahtevRepozitorijum;
            _pomocnikParser = pomocnikParser;
        }
        public Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja
        {
            get
            {
                return new Dictionary<Enum, PodesavanjaValidatoraParametaraStruct>()
                {
                    { TipProverePostojanjaAdministratorskihZahteva.Tip_Zahteva, new PodesavanjaValidatoraParametaraStruct(vrednost => _administratorskiZahtevRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.Tip == _pomocnikParser.ParsiranjeTipaAdminZahtevaIzStringa(vrednost)), "navedenim tipom", "tipa administratorskog zahteva") },
                    { TipProverePostojanjaAdministratorskihZahteva.Korisnicko_Ime_Autora, new PodesavanjaValidatoraParametaraStruct(vrednost => postojiZahtevSaKorisnickimImenom(true,vrednost), "navedenim  korisničkim imenom autora", "korisničkog imena autora") },
                    { TipProverePostojanjaAdministratorskihZahteva.Korisnicko_Ime_Subjekta, new PodesavanjaValidatoraParametaraStruct(vrednost => postojiZahtevSaKorisnickimImenom(false,vrednost), "navedenim korisničkim imenom subjekta", "korisničkog imena subjekta") },
                    { TipProverePostojanjaVremenaOdDo.Od_Vremena, new PodesavanjaValidatoraParametaraStruct(vrednost => _administratorskiZahtevRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.VremeSlanja > _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost)),"vremenom slanja većim od navedenog vremena","vremena slanja administratorskog zahteva")},
                    { TipProverePostojanjaVremenaOdDo.Do_Vremena, new PodesavanjaValidatoraParametaraStruct(vrednost => _administratorskiZahtevRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.VremeSlanja < _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost)),"vremenom slanja manjim od navedenog vremena","vremena slanja administratorskog zahteva")}
                };
            }
        }
        private bool postojiZahtevSaKorisnickimImenom(bool autor, string vrednost)
        {
            var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(vrednost);
            if (autor) return _administratorskiZahtevRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.AutorID.Equals(korisnickiNalog.KorisnikID));
            return _administratorskiZahtevRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.SubjekatID.Equals(korisnickiNalog.KorisnikID));
        }
    }
}
