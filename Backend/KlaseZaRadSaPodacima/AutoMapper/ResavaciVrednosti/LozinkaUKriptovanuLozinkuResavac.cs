using System;
using System.Collections.Generic;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonvertoriVrednosti
{
    public class LozinkaUKriptovanuLozinkuKonvertor : IValueResolver<KreiranjeKorisnikaDTO, KorisnickiNalogEntitet, string>
    {
        private readonly IPomocnikKriptovanje _pomocnikKriptovanje;

        public LozinkaUKriptovanuLozinkuKonvertor(IPomocnikKriptovanje pomocnikKriptovanje)
        {
            _pomocnikKriptovanje = pomocnikKriptovanje;
        }

        public string Resolve(KreiranjeKorisnikaDTO izvor, KorisnickiNalogEntitet destinacija, string clanDestinacije, ResolutionContext context)
        {
            return _pomocnikKriptovanje.KriptujLozinku($"{izvor.Ime}.{izvor.Prezime}{DateTime.Now.Year.ToString()}");
        }
    }
}