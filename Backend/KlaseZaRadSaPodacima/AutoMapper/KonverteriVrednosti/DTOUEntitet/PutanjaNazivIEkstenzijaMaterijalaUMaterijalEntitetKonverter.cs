using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet
{
    public class PutanjaNazivIEkstenzijaMaterijalaUMaterijalEntitetKonverter : ITypeConverter<IPutanjaNazivIEkstenzijaMaterijala, MaterijalEntitet>
    {
        private readonly IMaterijalRepozitorijum _materijalRepozitorijum;

        public PutanjaNazivIEkstenzijaMaterijalaUMaterijalEntitetKonverter(IMaterijalRepozitorijum materijalRepozitorijum)
        {
            _materijalRepozitorijum = materijalRepozitorijum;
        }
        public MaterijalEntitet Convert(IPutanjaNazivIEkstenzijaMaterijala izvor, MaterijalEntitet destinacija, ResolutionContext context)
        {
            return destinacija = _materijalRepozitorijum.PribaviSaUslovom(materijal => materijal.Nadoblast.Putanja.Equals(izvor.Putanja)
                                                                                       && materijal.Naziv.Equals(izvor.Naziv)
                                                                                       && materijal.Ekstenzija.Equals(izvor.Ekstenzija), new List<Expression<Func<MaterijalEntitet, object>>>() { materijal => materijal.Nadoblast });
        }
    }
}