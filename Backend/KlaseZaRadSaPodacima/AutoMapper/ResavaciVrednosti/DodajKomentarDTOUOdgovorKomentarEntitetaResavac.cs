using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ResavaciVrednosti
{
    public class DodajKomentarDTOUOdgovorKomentarEntitetaResavac : IValueResolver<DodajKomentarDTO, KomentarEntitet, KomentarEntitet>
    {
        private readonly IKomentarRepozitorijum _komentarRepozitorijum;

        public DodajKomentarDTOUOdgovorKomentarEntitetaResavac(IKomentarRepozitorijum komentarRepozitorijum)
        {
            _komentarRepozitorijum = komentarRepozitorijum;
        }


        public KomentarEntitet Resolve(DodajKomentarDTO izvor, KomentarEntitet destinacija, KomentarEntitet clanDestinacije, ResolutionContext context)
        {
            
            var korisnickiNalog = context.Mapper.Map<string, KorisnickiNalogEntitet>(izvor.KorisnickoImeOdgovor);
            var materijal = destinacija.Materijal;
            var vremeKomentarisanja = context.Mapper.Map<string, DateTime>(izvor.VremeSlanjaOdgovor);
            
            return clanDestinacije = _komentarRepozitorijum.PribaviSaUslovom(komentar => komentar.AutorID.Equals(korisnickiNalog.KorisnikID)
                                                                                         && komentar.MaterijalID.Equals(materijal.ID)
                                                                                         && komentar.VremeKomentarisanja.Equals(vremeKomentarisanja));
        }
    }
}