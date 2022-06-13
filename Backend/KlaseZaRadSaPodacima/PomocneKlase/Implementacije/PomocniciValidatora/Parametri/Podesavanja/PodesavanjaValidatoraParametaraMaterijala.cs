using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja
{
    public class PodesavanjaValidatoraParametaraMaterijala : IPodesavanjaValidatoraParametaraMaterijala
    {
        private readonly IMaterijalRepozitorijum _materijalRepozitorijum;
        private readonly IKomentarRepozitorijum _komentarRepozitorijum;
        private readonly IOblastRepozitorijum _oblastRepozitorijum;
        private readonly IOcenaRepozitorijum _ocenaRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;
        private readonly IPomocnikKolacic _pomocnikKolacic;
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;

        public PodesavanjaValidatoraParametaraMaterijala(IMaterijalRepozitorijum materijalRepozitorijum,
                                                         IKomentarRepozitorijum komentarRepozitorijum,
                                                         IOblastRepozitorijum oblastRepozitorijum,
                                                         IOcenaRepozitorijum ocenaRepozitorijum,
                                                         IPomocnikParser pomocnikParser,
                                                         IPomocnikKolacic pomocnikKolacic,
                                                         IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum)
        {
            _materijalRepozitorijum = materijalRepozitorijum;
            _komentarRepozitorijum = komentarRepozitorijum;
            _oblastRepozitorijum = oblastRepozitorijum;
            _ocenaRepozitorijum = ocenaRepozitorijum;
            _pomocnikParser = pomocnikParser;
            _pomocnikKolacic = pomocnikKolacic;
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
        }
        public Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja
        {
            get
            {
                return new Dictionary<Enum, PodesavanjaValidatoraParametaraStruct>()
                {
                    {TipProverePostojanjaMaterijala.Naziv_Materijala, new PodesavanjaValidatoraParametaraStruct(vrednost=>_materijalRepozitorijum.PostojiEntitetSaUslovom(materijal=>materijal.Naziv.Equals(vrednost)), "navedenim nazivom", "naziva materijala")},
                    {TipProverePostojanjaMaterijala.Putanja_Nadoblasti, new PodesavanjaValidatoraParametaraStruct(vrednost=>_materijalRepozitorijum.PostojiEntitetSaUslovom(materijal => materijal.Nadoblast.Putanja.Equals(vrednost), new List<System.Linq.Expressions.Expression<Func<Entiteti.MaterijalEntitet, object>>>() {materijal => materijal.Nadoblast}),"navedenom putanjom", "putanje nadoblasti")},
                    {TipProverePostojanjaMaterijala.Vreme_Komentarisanja, new PodesavanjaValidatoraParametaraStruct(vrednost=>_komentarRepozitorijum.PostojiEntitetSaUslovom(komentar=>komentar.VremeKomentarisanja.ToString().Equals(vrednost)),"navedenim vremenom komentarisanja", "vremena komentarisanja")},
                    {TipProverePostojanjaMaterijala.Ekstenzija, new PodesavanjaValidatoraParametaraStruct(vrednost=> _materijalRepozitorijum.PostojiEntitetSaUslovom(materijal => materijal.Ekstenzija.Equals(vrednost)),"navedenom ekstenzijom", "ekstenzije materijala")},
                    {TipProverePostojanjaMaterijala.Naziv_Materijala_Ekstenzija_I_Putanja, new PodesavanjaValidatoraParametaraStruct(vrednost=>ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaMaterijala.Naziv_Materijala_Ekstenzija_I_Putanja, vrednost),"navedenim nazivom i ekstenzijom u navedenoj oblasti", "ekstenzije")},
                    {TipProverePostojanjaMaterijala.Naziv_I_Ekstenzija, new PodesavanjaValidatoraParametaraStruct(vrednost=>ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaMaterijala.Naziv_I_Ekstenzija, vrednost),"navedenim nazivom i ekstenzijom", "ekstenzije materijala")},
                    {TipProverePostojanjaMaterijala.Putanja_Nadoblasti_I_Ekstenzija, new PodesavanjaValidatoraParametaraStruct(vrednost=>ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaMaterijala.Putanja_Nadoblasti_I_Ekstenzija, vrednost),"navedenom ekstenzijom u navedenoj oblasti", "ekstenzije materijala")},
                    {TipProverePostojanjaMaterijala.Naziv_I_Putanja_Nadoblasti, new PodesavanjaValidatoraParametaraStruct(vrednost=>ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaMaterijala.Naziv_I_Putanja_Nadoblasti, vrednost),"navedenim nazivom u navedenoj oblasti", "naziva materijala")},
                };
            }
        }

       

        private bool ProveriPutanjuNazivIEkstenziju(TipProverePostojanjaMaterijala tipProverePostojanjaMaterijala, string vrednost)
        {
            var nizVrednosti = vrednost.Split("#");
            switch (tipProverePostojanjaMaterijala)
            {
                case TipProverePostojanjaMaterijala.Naziv_Materijala_Ekstenzija_I_Putanja:
                    return _materijalRepozitorijum.PostojiEntitetSaUslovom(materijal => materijal.Nadoblast.Putanja.Equals(nizVrednosti.First())
                                                                                        && materijal.Naziv.Equals(nizVrednosti[1])
                                                                                        && materijal.Ekstenzija.Equals(nizVrednosti.Last()),
                                                                           new List<System.Linq.Expressions.Expression<Func<Entiteti.MaterijalEntitet, object>>>() { materijal => materijal.Nadoblast });
                case TipProverePostojanjaMaterijala.Naziv_I_Ekstenzija:
                    return _materijalRepozitorijum.PostojiEntitetSaUslovom(materijal => materijal.Naziv.Equals(nizVrednosti.First())
                                                                                        && materijal.Ekstenzija.Equals(nizVrednosti.Last()));
                case TipProverePostojanjaMaterijala.Putanja_Nadoblasti_I_Ekstenzija:
                    return _materijalRepozitorijum.PostojiEntitetSaUslovom(materijal => materijal.Nadoblast.Putanja.Equals(nizVrednosti.First())
                                                                                        && materijal.Ekstenzija.Equals(nizVrednosti.Last()),
                                                                           new List<System.Linq.Expressions.Expression<Func<Entiteti.MaterijalEntitet, object>>>() { materijal => materijal.Nadoblast });
                case TipProverePostojanjaMaterijala.Naziv_I_Putanja_Nadoblasti:
                    return _materijalRepozitorijum.PostojiEntitetSaUslovom(materijal => materijal.Nadoblast.Putanja.Equals(nizVrednosti.First())
                                                                                        && materijal.Naziv.Equals(nizVrednosti.Last()),
                                                                           new List<System.Linq.Expressions.Expression<Func<Entiteti.MaterijalEntitet, object>>>() { materijal => materijal.Nadoblast });
                default: return false;
            }
        }
    }
}