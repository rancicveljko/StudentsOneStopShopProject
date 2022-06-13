using System;
using System.Collections.Generic;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.Servisi.Enumeracije;
using Calabonga.PredicatesBuilder;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja
{
    public class PodesavanjaValidatoraParametaraKorisnika : IPodesavanjaValidatoraParametaraKorisnika
    {
        private IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;
        private readonly IKorisnikRepozitorijum _korisnikRepozitorijum;
        private readonly IOsnovniKorisnikPodaciRepozitorijum _osnovniKorisnikPodaciRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;
        private readonly IPomocnikKriptovanje _pomocnikKriptovanje;

        public PodesavanjaValidatoraParametaraKorisnika(IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                                        IOsnovniKorisnikPodaciRepozitorijum osnovniKorisnikPodaciRepozitorijum,
                                                        IKorisnikRepozitorijum korisnikRepozitorijum,
                                                        IPomocnikParser pomocnikParser,
                                                        IPomocnikKriptovanje pomocnikKriptovanje)
        {
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
            _korisnikRepozitorijum = korisnikRepozitorijum;
            _osnovniKorisnikPodaciRepozitorijum = osnovniKorisnikPodaciRepozitorijum;
            _pomocnikParser = pomocnikParser;
            _pomocnikKriptovanje = pomocnikKriptovanje;
        }
        public Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja
        {
            get
            {
                return new Dictionary<Enum, PodesavanjaValidatoraParametaraStruct>()
                {
                    { TipProverePostojanjaKorisnika.Email, new PodesavanjaValidatoraParametaraStruct(vrednost => _korisnikRepozitorijum.PostojiEntitetSaUslovom(korisnik => korisnik.Email.Equals(vrednost)), "navedenom e-mail adresom", "e-mail adrese") },
                    { TipProverePostojanjaKorisnika.IDBroj, new PodesavanjaValidatoraParametaraStruct(vrednost => _osnovniKorisnikPodaciRepozitorijum.PostojiEntitetSaUslovom(osnovniKorisnik => osnovniKorisnik.IDBroj.Equals(vrednost)), "navedenim IDBrojem", "IDBroja") },
                    { TipProverePostojanjaKorisnika.KorisnickoIme, new PodesavanjaValidatoraParametaraStruct(vrednost => _korisnickiNalogRepozitorijum.PostojiEntitetSaUslovom(korisnickiNalog => korisnickiNalog.KorisnickoIme.Equals(vrednost)), "navedenim korisničkim imenom", "korisničkog imena") },
                    { TipProverePostojanjaKorisnika.Ime, new PodesavanjaValidatoraParametaraStruct(vrednost => _korisnikRepozitorijum.PostojiEntitetSaUslovom(korisnik => korisnik.Ime.Equals(vrednost)), "navedenim imenom", "imena") },
                    { TipProverePostojanjaKorisnika.Prezime, new PodesavanjaValidatoraParametaraStruct(vrednost => _korisnikRepozitorijum.PostojiEntitetSaUslovom(korisnik => korisnik.Prezime.Equals(vrednost)), "navedenim prezimenom", " prezimena") },
                    { TipProverePostojanjaKorisnika.Uloga, new PodesavanjaValidatoraParametaraStruct(vrednost => _korisnickiNalogRepozitorijum.PostojiEntitetSaUslovom(korisnickiNalog => korisnickiNalog.Uloga == _pomocnikParser.ParsiranjeUlogeIzStringa(vrednost)), "navedenom ulogom", "uloge") },
                    { TipProverePostojanjaKorisnika.Status_Naloga, new PodesavanjaValidatoraParametaraStruct(vrednost => _korisnickiNalogRepozitorijum.PostojiEntitetSaUslovom(korisnickiNalog => korisnickiNalog.StatusNaloga == _pomocnikParser.ParsiranjeStatusaKorisnickogNalogaIzString(vrednost)), "navedenim statusom", "statusa") },
                    { TipProverePostojanjaKorisnika.Lozinka, new PodesavanjaValidatoraParametaraStruct(vrednost => ValidirajLozinku(vrednost), "", "lozinke") },
                    { TipProverePostojanjaKorisnika.Nova_Lozinka, new PodesavanjaValidatoraParametaraStruct(vrednost => ValidirajLozinku(vrednost), "", "lozinke") },
                    { TipProverePostojanjaKorisnika.Privilegije, new PodesavanjaValidatoraParametaraStruct(vrednost => _osnovniKorisnikPodaciRepozitorijum.PostojiEntitetSaUslovom(osnovniKorisnikPodaci => osnovniKorisnikPodaci.Privilegije.HasFlag(_pomocnikParser.ParsiranjePrivilegijaOsnovnogKorisnikaIzStringa(vrednost))), "navedenim privilegijama", "privilegija") }
                };
            }
        }
        private bool ValidirajLozinku(string vrednost)
        {
            var razbijenaVrednost = vrednost.Split("?");
            if (razbijenaVrednost.Length != 2) return false;
            var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(razbijenaVrednost.Last(), null, null);
            if (korisnickiNalog == null) return false;
            return _pomocnikKriptovanje.VerifikujLozinku(razbijenaVrednost.First(), korisnickiNalog.Lozinka);
        }
    }
}