using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet
{
    public class DodajOcenuDTOUOcenaEntitetKonverter : ITypeConverter<DodajOcenuDTO, OcenaEntitet>
    {
        private readonly IOcenaRepozitorijum _ocenaRepozitorijum;

        public DodajOcenuDTOUOcenaEntitetKonverter(IOcenaRepozitorijum ocenaRepozitorijum)
        {
            _ocenaRepozitorijum = ocenaRepozitorijum;
        }
        public OcenaEntitet Convert(DodajOcenuDTO izvor, OcenaEntitet destinacija, ResolutionContext context)
        {
            var korisnickiNalog = context.Mapper.Map<DodajOcenuDTO, KorisnickiNalogEntitet>(izvor);
            var materijal = context.Mapper.Map<DodajOcenuDTO, MaterijalEntitet>(izvor);
            var tipOcene = Enum.Parse<TipOcene>(izvor.TipOcene);

            var ocena = _ocenaRepozitorijum.PribaviSaUslovom(ocena => ocena.AutorID.Equals(korisnickiNalog.KorisnikID) && ocena.Materijal.ID.Equals(materijal.ID), new List<Expression<Func<OcenaEntitet, object>>>() { ocena => ocena.Materijal });
            if (ocena == null)
            {
                izvor.DodajOcenu = true;
                ocena = new OcenaEntitet(tipOcene,
                                         korisnickiNalog,
                                         materijal);
            }
            return ocena;
        }
    }
}