using System;
using System.Collections.Generic;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonvertoriVrednosti
{
    public class ListaStringPutanjaUListuNadleznostiKorisnickogNalogaResavac : IValueResolver<IListaPutanjaOblasti, KorisnickiNalogEntitet, IList<KorisnickiNalogOblastEntitet>>
    {
        private readonly IOblastRepozitorijum _oblastRepozitorijum;

        public ListaStringPutanjaUListuNadleznostiKorisnickogNalogaResavac(IOblastRepozitorijum oblastRepozitorijum)
        {
            _oblastRepozitorijum = oblastRepozitorijum;
        }

        public IList<KorisnickiNalogOblastEntitet> Resolve(IListaPutanjaOblasti izvor, KorisnickiNalogEntitet destinacija, IList<KorisnickiNalogOblastEntitet> destMember, ResolutionContext context)
        {
            destMember = new List<KorisnickiNalogOblastEntitet>();
            foreach (var putanja in izvor.PutanjeOblasti)
            {
                var a = new KorisnickiNalogOblastEntitet();
                a.Nadlezni = destinacija;
                a.Oblast = _oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja == putanja, null);
                destMember.Add(a);
            }
            return destMember;
        }
    }
}