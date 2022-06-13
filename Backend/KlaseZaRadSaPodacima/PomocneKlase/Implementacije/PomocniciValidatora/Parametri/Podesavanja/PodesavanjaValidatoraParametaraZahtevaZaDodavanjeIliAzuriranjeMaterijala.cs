using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja
{
    public class PodesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala : IPodesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala
    {
        private readonly IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;

        private readonly Dictionary<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>, List<Expression<Func<object, object>>>> zaUgnjezdenoUkljucivanje = new Dictionary<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>, List<Expression<Func<object, object>>>>()
            {
                { zahtev => zahtev.Materijal, new List<Expression<Func<object, object>>>() {materijal => (materijal as MaterijalEntitet).Nadoblast} }
            };
        private readonly List<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>> zaUkljucivanje = new List<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>>() { zahtev => zahtev.Materijal };

        public PodesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala(IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum, IPomocnikParser pomocnikParser)
        {
            _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum = zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
            _pomocnikParser = pomocnikParser;
        }
        public Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja => new Dictionary<Enum, PodesavanjaValidatoraParametaraStruct>()
        {
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Tip_Zahteva,new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.TipZahteva == _pomocnikParser.ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(vrednost)),"navedenim tipom zahteva","tipa zahteva za dodavanje ili ažuriranje materijala")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Korisnicko_Ime_Autora,new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Autor.KorisnickoIme.Equals(vrednost), new List<Expression<Func<Entiteti.ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>>() { zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Autor }),"navedenim korisničkim imenom autora","korisničkog imena autora")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_Materijala,new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Nadoblast.Putanja.Equals(vrednost), null, zaUgnjezdenoUkljucivanje),"navedenom putanjom nadoblasti materijala","putanje nadoblasti materijala")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Naziv_Materijala,new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Naziv.Equals(vrednost), zaUkljucivanje),"navedenim nazivom materijala","naziva materijala")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Ekstenzija_Materijala,new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Ekstenzija.Equals(vrednost), zaUkljucivanje),"navedenom ekstenzijom materijala","ekstenzije materijala")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_I_Naziv_Materijala,new PodesavanjaValidatoraParametaraStruct(vrednost => ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_I_Naziv_Materijala,vrednost,zaUkljucivanje,zaUgnjezdenoUkljucivanje),"navedenim nazivom materijala u navedenoj nadoblasti","naziva materijala")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_I_Ekstenzija_Materijala,new PodesavanjaValidatoraParametaraStruct(vrednost => ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_I_Ekstenzija_Materijala,vrednost,zaUkljucivanje,zaUgnjezdenoUkljucivanje),"navedenom ekstenzijom materijala u navedenoj nadoblasti","ekstenzije materijala")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_Naziv_I_Ekstenzija_Materijala,new PodesavanjaValidatoraParametaraStruct(vrednost => ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_Naziv_I_Ekstenzija_Materijala,vrednost,zaUkljucivanje,zaUgnjezdenoUkljucivanje),"navedenom ekstenzijom i nazivom materijala, u navedenoj nadoblasti","ekstenzije materijala")},
            { TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Naziv_I_Ekstenzija_Materijala,new PodesavanjaValidatoraParametaraStruct(vrednost => ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Naziv_I_Ekstenzija_Materijala,vrednost,zaUkljucivanje,zaUgnjezdenoUkljucivanje),"navedenom ekstenzijom i navedenim nazivom materijala","ekstenzije materijala")},
            { TipProverePostojanjaVremenaOdDo.Od_Vremena, new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.VremeSlanja > _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost)),"vremenom slanja većim od navedenog vremena","vremena slanja zahteva za dodavanje ili ažuriranje materijala")},
            { TipProverePostojanjaVremenaOdDo.Do_Vremena, new PodesavanjaValidatoraParametaraStruct(vrednost => _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(administratorskiZahtev => administratorskiZahtev.VremeSlanja < _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vrednost)),"vremenom slanja manjim od navedenog vremena","vremena slanja zahteva za dodavanje ili ažuriranje materijala")}
        };

        private bool ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala tipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala,
                                                    string vrednost,
                                                    List<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>> zaUkljucivanje,
                                                    Dictionary<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>, List<Expression<Func<object, object>>>> zaUgnjezdenoUkljucivanje)
        {
            var nizVrednosti = vrednost.Split("#");


            switch (tipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala)
            {
                case TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_Naziv_I_Ekstenzija_Materijala:
                    return _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtev => zahtev.Materijal.Nadoblast.Putanja.Equals(nizVrednosti.First())
                                                                                                                    && zahtev.Materijal.Naziv.Equals(nizVrednosti[1])
                                                                                                                    && zahtev.Materijal.Ekstenzija.Equals(nizVrednosti.Last()),
                                                                                                          null,
                                                                                                          zaUgnjezdenoUkljucivanje
                                                                                                          );
                case TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Naziv_I_Ekstenzija_Materijala:
                    return _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtev => zahtev.Materijal.Naziv.Equals(nizVrednosti.First())
                                                                                                                    && zahtev.Materijal.Ekstenzija.Equals(nizVrednosti.Last()),
                                                                                                          zaUkljucivanje);
                case TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_I_Ekstenzija_Materijala:
                    return _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtev => zahtev.Materijal.Nadoblast.Putanja.Equals(nizVrednosti.First())
                                                                                                                    && zahtev.Materijal.Ekstenzija.Equals(nizVrednosti.Last()),
                                                                                                          null,
                                                                                                          zaUgnjezdenoUkljucivanje);
                case TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Putanja_Nadoblasti_I_Naziv_Materijala:
                    return _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PostojiEntitetSaUslovom(zahtev => zahtev.Materijal.Nadoblast.Putanja.Equals(nizVrednosti.First())
                                                                                                                    && zahtev.Materijal.Naziv.Equals(nizVrednosti.Last()),
                                                                                                          null,
                                                                                                          zaUgnjezdenoUkljucivanje);
                default: return false;
            }
        }
    }
}