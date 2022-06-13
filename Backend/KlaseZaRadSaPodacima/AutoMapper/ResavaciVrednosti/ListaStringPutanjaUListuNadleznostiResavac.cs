using System;
using System.Collections.Generic;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ResavaciVrednosti
{
    public class ListaStringPutanjaUListuNadleznostiResavac : IValueResolver<AzuriranjeNalogaDTO, KorisnikAzuriranje, IList<KorisnickiNalogOblastEntitet>>
    {
        private IOblastRepozitorijum _oblastRepozitorijum;
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;

        public ListaStringPutanjaUListuNadleznostiResavac(IOblastRepozitorijum oblastRepozitorijum, IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum)
        {
            _oblastRepozitorijum = oblastRepozitorijum;
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
        }
        public IList<KorisnickiNalogOblastEntitet> Resolve(AzuriranjeNalogaDTO izvor, KorisnikAzuriranje destinacija, IList<KorisnickiNalogOblastEntitet> clanDestinacije, ResolutionContext context)
        {
            var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(izvor.PostojeceKorisnickoIme);
           
            if (korisnickiNalog.Uloga != Uloga.Napredni_Korisnik) return clanDestinacije;
            
            clanDestinacije = new List<KorisnickiNalogOblastEntitet>();
            foreach (var putanja in izvor.PutanjeOblasti)
            {
                var korisnickiNalogOblast = new KorisnickiNalogOblastEntitet();
                korisnickiNalogOblast.Nadlezni = korisnickiNalog;
                korisnickiNalogOblast.Oblast = _oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja == putanja);
                clanDestinacije.Add(korisnickiNalogOblast);
            }

            return (IList<KorisnickiNalogOblastEntitet>)clanDestinacije;
        }
    }
}