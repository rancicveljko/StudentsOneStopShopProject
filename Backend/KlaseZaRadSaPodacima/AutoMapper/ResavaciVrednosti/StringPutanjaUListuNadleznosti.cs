using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Filteri.Korisnici;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ResavaciVrednosti
{
    public class StringPutanjaUListuNadleznosti : IValueResolver<PribaviKorisnickeNalogeDTO, KorisnickiNalogFilter, IList<KorisnickiNalogOblastEntitet>>
    {
        private readonly IKorisnickiNalogOblastRepozitorijum _korisnickiNalogOblastRepozitorijum;

        public StringPutanjaUListuNadleznosti(IKorisnickiNalogOblastRepozitorijum korisnickiNalogOblastRepozitorijum)
        {
            _korisnickiNalogOblastRepozitorijum = korisnickiNalogOblastRepozitorijum;
        }
        public IList<KorisnickiNalogOblastEntitet> Resolve(PribaviKorisnickeNalogeDTO izvor, KorisnickiNalogFilter destinacija, IList<KorisnickiNalogOblastEntitet> clanDestinacije, ResolutionContext context)
        {
            clanDestinacije = (IList<KorisnickiNalogOblastEntitet>)_korisnickiNalogOblastRepozitorijum.PribaviSveSaUslovom(korisnickiNalogOblast => korisnickiNalogOblast.Oblast.Putanja == izvor.Putanja, new List<System.Linq.Expressions.Expression<System.Func<KorisnickiNalogOblastEntitet, object>>>() { korisnickiNalogOblast => korisnickiNalogOblast.Oblast });
            return clanDestinacije;
        }
    }
}