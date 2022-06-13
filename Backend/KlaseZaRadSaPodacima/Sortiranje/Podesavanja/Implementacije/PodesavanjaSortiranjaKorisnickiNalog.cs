using System;
using System.Collections.Generic;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;

namespace Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Implementacije
{
    public class PodesavanjaSortiranjaKorisnickiNalog : IPodesavanjaSortiranjaKorisnickiNalog
    {
        public Dictionary<Enum, Func<IQueryable<KorisnickiNalogEntitet>, IQueryable<KorisnickiNalogEntitet>>> SkupPodesavanja => new Dictionary<Enum, Func<IQueryable<KorisnickiNalogEntitet>, IQueryable<KorisnickiNalogEntitet>>>()
        {
            {KorisnickiNalogSortiranje.Korisnicko_Ime_Opadajuce, korisnickiNalogSkup => korisnickiNalogSkup.OrderByDescending(korisnickiNalog => korisnickiNalog.KorisnickoIme)},
            {KorisnickiNalogSortiranje.Korisnicko_Ime_Rastuce, korisnickiNalogSkup => korisnickiNalogSkup.OrderBy(korisnickiNalog => korisnickiNalog.KorisnickoIme)},
            {KorisnickiNalogSortiranje.Uloga, korisnickiNalogSkup => korisnickiNalogSkup.OrderBy(korisnickiNalog => korisnickiNalog.Uloga)},
            {KorisnickiNalogSortiranje.Status_Naloga, korisnickiNalogSkup => korisnickiNalogSkup.OrderBy(korisnickiNalog => korisnickiNalog.StatusNaloga)}
        };

        public Func<IQueryable<KorisnickiNalogEntitet>, IQueryable<KorisnickiNalogEntitet>> podrazumevanoSortiranje => korisnickiNalogSkup => korisnickiNalogSkup.OrderByDescending(korisnickiNalog => korisnickiNalog.KorisnickoIme);
    }
}