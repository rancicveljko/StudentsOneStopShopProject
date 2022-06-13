using System;
using System.Collections.Generic;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;

namespace Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Implementacije
{
    public class PodesavanjaSortiranjaAdministratorskihZahteva : IPodesavanjaSortiranjaAdministratorskihZahteva
    {
        public Func<IQueryable<ZahtevAdministratoruEntitet>, IQueryable<ZahtevAdministratoruEntitet>> podrazumevanoSortiranje => administratorskiZahteviSkup => administratorskiZahteviSkup.OrderByDescending(administratorskiZahtev => administratorskiZahtev.Autor.KorisnickoIme);

        public Dictionary<Enum, Func<IQueryable<ZahtevAdministratoruEntitet>, IQueryable<ZahtevAdministratoruEntitet>>> SkupPodesavanja => new Dictionary<Enum, Func<IQueryable<ZahtevAdministratoruEntitet>, IQueryable<ZahtevAdministratoruEntitet>>>()
        {
            {AdministratorskiZahteviSortiranje.Korisnicko_Ime_Autora_Opadajuce, administratorskiZahteviSkup => administratorskiZahteviSkup.OrderByDescending(administratorskiZahtev => administratorskiZahtev.Autor.KorisnickoIme)},
            {AdministratorskiZahteviSortiranje.Korisnicko_Ime_Autora_Rastuce, administratorskiZahteviSkup => administratorskiZahteviSkup.OrderBy(administratorskiZahtev => administratorskiZahtev.Autor.KorisnickoIme)},
            {AdministratorskiZahteviSortiranje.Datum_Opadajuce, administratorskiZahteviSkup => administratorskiZahteviSkup.OrderByDescending(administratorskiZahtev => administratorskiZahtev.VremeSlanja)},
            {AdministratorskiZahteviSortiranje.Datum_Rastuce, administratorskiZahteviSkup => administratorskiZahteviSkup.OrderBy(administratorskiZahtev => administratorskiZahtev.VremeSlanja)},
            {AdministratorskiZahteviSortiranje.Korisnicko_Ime_Subjekta_Rastuce, administratorskiZahteviSkup => administratorskiZahteviSkup.OrderBy(administratorskiZahtev => administratorskiZahtev.Subjekat.KorisnickoIme)},
            {AdministratorskiZahteviSortiranje.Korisnicko_Ime_Subjekta_Opadajuce, administratorskiZahteviSkup => administratorskiZahteviSkup.OrderByDescending(administratorskiZahtev => administratorskiZahtev.Subjekat.KorisnickoIme)},
            {AdministratorskiZahteviSortiranje.Tip_Zahteva, administratorskiZahteviSkup => administratorskiZahteviSkup.OrderBy(administratorskiZahtev => administratorskiZahtev.Tip)},
        };
    }
}