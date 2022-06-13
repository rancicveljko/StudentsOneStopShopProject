using System;
using System.Collections.Generic;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonvertoriVrednosti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUEntitet
{
    public class KreiranjeKorisnikaDTOProfil : Profile
    {
        public KreiranjeKorisnikaDTOProfil()
        {


            CreateMap<KreiranjeKorisnikaDTO, OsnovniKorisnikPodaciEntitet>().ForMember(destinacija => destinacija.Privilegije, map => map.MapFrom(izvor => OsnovniKorisnikPrivilegije.Bez_Zabrana));

            CreateMap<KreiranjeKorisnikaDTO, KorisnikEntitet>().ForPath(destinacija => destinacija.OsnovniKorisnikPodaci,
                                                                        map => { map.Condition(izvor => Enum.Parse<Uloga>(izvor.Source.Uloga) == Uloga.Osnovni_Korisnik); map.MapFrom(izvor => izvor); });

            CreateMap<KreiranjeKorisnikaDTO, KorisnickiNalogEntitet>().ForMember(destinacija => destinacija.KorisnickoIme,
                                                                                 map => map.MapFrom(izvor => izvor.Email))
                                                                    .ForMember(destinacija => destinacija.Lozinka,
                                                                               map => map.MapFrom<LozinkaUKriptovanuLozinkuKonvertor>())
                                                                    .ForMember(destinacija => destinacija.StatusNaloga,
                                                                               map => map.MapFrom(izvor => StatusKorisnickogNaloga.Aktivan))
                                                                    .ForMember(destinacija => destinacija.PoslednjaPromena,
                                                                               map => map.MapFrom(izvor => DateTime.UtcNow))
                                                                    .ForMember(destinacija => destinacija.Korisnik,
                                                                               map => map.MapFrom(izvor => izvor))
                                                                    .ForMember(destinacija => destinacija.NadlezanZaOblasti,
                                                                               map => { map.PreCondition(izvor => Enum.Parse<Uloga>(izvor.Uloga) == Uloga.Napredni_Korisnik); map.MapFrom<ListaStringPutanjaUListuNadleznostiKorisnickogNalogaResavac>(); });

        }
    }
}