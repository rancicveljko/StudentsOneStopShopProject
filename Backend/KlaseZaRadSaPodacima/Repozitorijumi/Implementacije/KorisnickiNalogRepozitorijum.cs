using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.DTObjekti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class KorisnickiNalogRepozitorijum : OsnovniRepozitorijum<KorisnickiNalogEntitet>, IKorisnickiNalogRepozitorijum
    {
        private readonly IMapper _mapper;
        private readonly IPomocnikKriptovanje _pomocnikKriptovanje;

        public KorisnickiNalogRepozitorijum(BazaDbContext dbcontext,
                                            IMapper mapper,
                                            IPomocnikKriptovanje pomocnikKriptovanje) : base(dbcontext)
        {
            _mapper = mapper;
            _pomocnikKriptovanje = pomocnikKriptovanje;
        }

        public KorisnickiNalogEntitet PribaviPoKorisnickomImenu(string korisnickoIme,
                                                                List<Expression<Func<KorisnickiNalogEntitet, object>>> zaUkljucivanje = null,
                                                                Dictionary<Expression<Func<KorisnickiNalogEntitet, object>>, List<Expression<Func<object, object>>>> izraziZaKolekcije = null,
                                                                Enum kriterijumSortiranja = null,
                                                                IPodesavanjaSortiranja<KorisnickiNalogEntitet> podesavanjeSortiranja = null)
        {
            return PribaviSetSaUkljucenimISortiranjem(zaUkljucivanje,
                                                      izraziZaKolekcije,
                                                      kriterijumSortiranja,
                                                      podesavanjeSortiranja).Where(korisnickiNalog => korisnickiNalog.KorisnickoIme == korisnickoIme)
                                                                            .SingleOrDefault<KorisnickiNalogEntitet>();
        }

        public bool ProveriPoslednjuPromenu(string korisnickoIme, string poslednjaPromena)
        {
            var korisnik = PribaviPoKorisnickomImenu(korisnickoIme);
            return korisnik == null ? false : korisnik.PoslednjaPromena.ToString().Equals(poslednjaPromena);
        }

        public async Task ResetujLozinku(string korisnickoIme)
        {
            var korisnickiNalog = PribaviPoKorisnickomImenu(korisnickoIme, new List<Expression<Func<KorisnickiNalogEntitet, object>>>() { korisnickiNalog => korisnickiNalog.Korisnik });
            korisnickiNalog.Lozinka = _pomocnikKriptovanje.KriptujLozinku($"{korisnickiNalog.Korisnik.Ime}.{korisnickiNalog.Korisnik.Prezime}{DateTime.Now.Year}");
            korisnickiNalog.PoslednjaPromena = DateTime.UtcNow;
            await Azuriraj(korisnickiNalog);
        }

        public override async Task Ukloni(KorisnickiNalogEntitet entitet, bool sacuvaj = true)
        {
            entitet.StatusNaloga = StatusKorisnickogNaloga.Obrisan;
            entitet.PoslednjaPromena = DateTime.UtcNow;
            _context.Set<KorisnickiNalogEntitet>().Update(entitet);
            if (sacuvaj) await _context.SaveChangesAsync();
        }
    }
}