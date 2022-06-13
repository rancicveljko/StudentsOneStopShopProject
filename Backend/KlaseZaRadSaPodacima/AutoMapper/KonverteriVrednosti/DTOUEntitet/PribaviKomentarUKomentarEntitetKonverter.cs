using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet
{
    public class PribaviKomentarUKomentarEntitetKonverter : ITypeConverter<IPribaviKomentar, KomentarEntitet>
    {
        private readonly IPomocnikParser _pomocnikParser;
        private readonly IKomentarRepozitorijum _komentarRepozitorijum;
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;
        private readonly IPomocnikKolacic _pomocnikKolacic;

        public PribaviKomentarUKomentarEntitetKonverter(IPomocnikParser pomocnikParser,
                                                        IKomentarRepozitorijum komentarRepozitorijum,
                                                        IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                                        IPomocnikKolacic pomocnikKolacic)
        {
            _pomocnikParser = pomocnikParser;
            _komentarRepozitorijum = komentarRepozitorijum;
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
            _pomocnikKolacic = pomocnikKolacic;
        }
        public KomentarEntitet Convert(IPribaviKomentar izvor, KomentarEntitet destinacija, ResolutionContext context)
        {
            KorisnickiNalogEntitet korisnickiNalog;
            if (izvor.KorisnickoIme != null) korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(izvor.KorisnickoIme);
            else korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(_pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier));
            var materijalEntiet = context.Mapper.Map<IPutanjaNazivIEkstenzijaMaterijala, MaterijalEntitet>(izvor);
            var vremeSlanjaUTC = _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(izvor.VremeSlanja);

            return destinacija = _komentarRepozitorijum.PribaviSaUslovom(komentar => komentar.AutorID.Equals(korisnickiNalog.KorisnikID)
                                                                                     && komentar.MaterijalID.Equals(materijalEntiet.ID)
                                                                                     && komentar.VremeKomentarisanja.Equals(vremeSlanjaUTC),
                                                                                     new List<Expression<Func<KomentarEntitet, object>>>() { komentar => komentar.Odgovori });

        }
    }
}