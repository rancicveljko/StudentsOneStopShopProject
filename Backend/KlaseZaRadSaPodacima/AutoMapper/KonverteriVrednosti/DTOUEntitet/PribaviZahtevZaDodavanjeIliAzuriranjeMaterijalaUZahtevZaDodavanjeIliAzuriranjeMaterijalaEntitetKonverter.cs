using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet
{
    public class PribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaUZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitetKonverter : ITypeConverter<IPribaviZahtevZaDodavanjeIliAzuriranjeMaterijala, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>
    {
        private readonly IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;

        public PribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaUZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitetKonverter(IPomocnikParser pomocnikParser,
                                                                                                                        IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum)
        {
            _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum = zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
            _pomocnikParser = pomocnikParser;
        }
        public ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet Convert(IPribaviZahtevZaDodavanjeIliAzuriranjeMaterijala izvor, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet destinacija, ResolutionContext context)
        {
            var zaUgnjezdenoUkljucivanje = new Dictionary<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>, List<Expression<Func<object, object>>>>()
                {
                    { zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal, new List<Expression<Func<object, object>>>() { materijal => (materijal as MaterijalEntitet).Nadoblast }}
                };

            var vremeSlanjaUTC = _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(izvor.VremeSlanja);
            return destinacija = _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.PribaviSaUslovom(zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Nadoblast.Putanja.Equals(izvor.Putanja)
                                                                                                                                                                               && zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Naziv.Equals(izvor.Naziv)
                                                                                                                                                                               && zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Ekstenzija.Equals(izvor.Ekstenzija)
                                                                                                                                                                               && zahtevZaDodavanjeIliAzuriranjeMaterijala.Autor.KorisnickoIme.Equals(izvor.KorisnickoIme)
                                                                                                                                                                               && zahtevZaDodavanjeIliAzuriranjeMaterijala.VremeSlanja.Equals(vremeSlanjaUTC));
        }
    }
}