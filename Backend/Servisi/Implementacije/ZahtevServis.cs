using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciServisa;
using Backend.KlaseZaRadSaPodacima.Filteri;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Filteri.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.Filteri.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;

namespace Backend.Servisi.Implementacije
{
    public class ZahtevServis : IZahtevServis
    {
        private readonly IMapper _mapper;
        private readonly IAdministratorskiZahtevRepozitorijum _administratorskiZahtevRepozitorijum;
        private readonly IPomocnikServisa _pomocnikServisa;
        private readonly IPomocnikParser _pomocnikParser;
        private readonly IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
        private readonly IMaterijalRepozitorijum _materijalRepozitorijum;
        private readonly IIzmenaRepozitorijum _izmenaRepozitorijum;
        private readonly IPodesavanjaSortiranjaAdministratorskihZahteva _podesavanjaSortiranjaAdministratorskihZahteva;

        public ZahtevServis(IMapper mapper,
                            IAdministratorskiZahtevRepozitorijum administratorskiZahtevRepozitorijum,
                            IPomocnikServisa pomocnikServisa,
                            IPomocnikParser pomocnikPareser,
                            IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                            IMaterijalRepozitorijum materijalRepozitorijum,
                            IIzmenaRepozitorijum izmenaRepozitorijum,
                            IPodesavanjaSortiranjaAdministratorskihZahteva podesavanjaSortiranjaAdministratorskihZahteva)
        {
            _mapper = mapper;
            _administratorskiZahtevRepozitorijum = administratorskiZahtevRepozitorijum;
            _pomocnikServisa = pomocnikServisa;
            _pomocnikParser = pomocnikPareser;
            _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum = zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum;
            _materijalRepozitorijum = materijalRepozitorijum;
            _izmenaRepozitorijum = izmenaRepozitorijum;
            _podesavanjaSortiranjaAdministratorskihZahteva = podesavanjaSortiranjaAdministratorskihZahteva;
        }

        public async Task<IActionResult> KreirajZahtevAdministratoru(ZahtevAdministratoruDTO zahtevAdministratoru)
        {
            try
            {
                var zahtev = _mapper.Map<ZahtevAdministratoruDTO, ZahtevAdministratoruEntitet>(zahtevAdministratoru);

                await _administratorskiZahtevRepozitorijum.Dodaj(zahtev);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> ObradiAdministratorskiZahtev(ObradaZahtevaAdministratoruDTO zahtevZaObradu)
        {
            try
            {
                var prihvacen = Boolean.Parse(zahtevZaObradu.Prihvacen);
                var administratorskiZahtev = _administratorskiZahtevRepozitorijum.PribaviSaUslovom(administratorskiZahtev => administratorskiZahtev.Autor.KorisnickoIme == zahtevZaObradu.KorisnickoImeAutora
                                                                                                                             && administratorskiZahtev.VremeSlanja == _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(zahtevZaObradu.VremeSlanja),
                                                                                                   new List<Expression<Func<ZahtevAdministratoruEntitet, object>>>()
                                                                                                   { administratorskiZahtev => administratorskiZahtev.Autor,
                                                                                                     administratorskiZahtev => administratorskiZahtev.Subjekat,
                                                                                                     administratorskiZahtev => administratorskiZahtev.Subjekat.Korisnik,
                                                                                                     administratorskiZahtev => administratorskiZahtev.Subjekat.Korisnik.OsnovniKorisnikPodaci
                                                                                                   });

                if (prihvacen)
                {

                    if (administratorskiZahtev.Tip == TipAdministratorskogZahteva.Blokiranje_Korisnickog_Naloga)
                    {
                        administratorskiZahtev.Subjekat.StatusNaloga = StatusKorisnickogNaloga.Blokiran;
                    }
                    else if (administratorskiZahtev.Tip == TipAdministratorskogZahteva.Deblokiranje_Korisnickog_Naloga)
                    {
                        administratorskiZahtev.Subjekat.StatusNaloga = StatusKorisnickogNaloga.Aktivan;
                    }
                    else
                    {
                        var proveraZabrana = administratorskiZahtev.Subjekat.Korisnik.OsnovniKorisnikPodaci.Privilegije.HasFlag(OsnovniKorisnikPrivilegije.Bez_Zabrana);

                        if (administratorskiZahtev.Tip == TipAdministratorskogZahteva.Ukidanje_Privilegija_Komentarisanja)
                        {
                            AzurirajPrivilegije(proveraZabrana, administratorskiZahtev.Subjekat.Korisnik.OsnovniKorisnikPodaci, OsnovniKorisnikPrivilegije.Zabrana_Komentarisanja);
                        }

                        if (administratorskiZahtev.Tip == TipAdministratorskogZahteva.Ukidanje_Privilegija_Ocenjivanja)
                        {
                            AzurirajPrivilegije(proveraZabrana, administratorskiZahtev.Subjekat.Korisnik.OsnovniKorisnikPodaci, OsnovniKorisnikPrivilegije.Zabrana_Ocenjivanja);
                        }
                        if (administratorskiZahtev.Tip == TipAdministratorskogZahteva.Ukidanje_Privilegija_Dodavanja_Materijala)
                        {
                            AzurirajPrivilegije(proveraZabrana, administratorskiZahtev.Subjekat.Korisnik.OsnovniKorisnikPodaci, OsnovniKorisnikPrivilegije.Zabrana_Dodavanja_Materijala);
                        }
                    }
                }
                await _administratorskiZahtevRepozitorijum.UkloniVise(_administratorskiZahtevRepozitorijum.PribaviSveSaUslovom(administratorskiZahtevi => administratorskiZahtevi.Subjekat.KorisnickoIme == administratorskiZahtev.Subjekat.KorisnickoIme && administratorskiZahtevi.Tip == administratorskiZahtev.Tip, new List<Expression<Func<ZahtevAdministratoruEntitet, object>>>() { administratorskiZahtevi => administratorskiZahtevi.Subjekat }));
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        private void AzurirajPrivilegije(bool proveraZabrana,
                                         OsnovniKorisnikPodaciEntitet osnovniKorisnik,
                                         OsnovniKorisnikPrivilegije privilegije)
        {
            if (proveraZabrana)
            {
                osnovniKorisnik.Privilegije = privilegije;
                return;
            }
            osnovniKorisnik.Privilegije &= privilegije;
        }

        public ActionResult<IEnumerable<ZahtevAdministratoruBezTekstaDTO>> PribaviSveAdministratorskeZahtevePoFilterima(PribaviSveAdministratorskeZahteveDTO filteriZaPribavljanjeZahteva)
        {
            try
            {
                var zahtevFilter = _mapper.Map<PribaviSveAdministratorskeZahteveDTO, ZahtevAdministratoruFilter>(filteriZaPribavljanjeZahteva);

                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(ZahtevAdministratoruEntitet), new string[] {"Autor", "Subjekat"}},
                };
                var zaUkljucivanje = new List<Expression<Func<ZahtevAdministratoruEntitet, object>>>()
                {
                    zahtevAdministratoru => zahtevAdministratoru.Autor,
                    zahtevAdministratoru => zahtevAdministratoru.Subjekat
                };
                var zahteviAdminstratoru = _pomocnikServisa.PribaviSveOdKolikoSaFilterima<ZahtevAdministratoruEntitet>(zahtevFilter,
                                                                                                                       _administratorskiZahtevRepozitorijum,
                                                                                                                       int.Parse(filteriZaPribavljanjeZahteva.OdIndeksa),
                                                                                                                       int.Parse(filteriZaPribavljanjeZahteva.Koliko),
                                                                                                                       propsZaPreskociti,
                                                                                                                       zaUkljucivanje,
                                                                                                                       null,
                                                                                                                       string.IsNullOrEmpty(filteriZaPribavljanjeZahteva.KriterijumSortiranja) ? null : Enum.Parse<AdministratorskiZahteviSortiranje>(filteriZaPribavljanjeZahteva.KriterijumSortiranja),
                                                                                                                       _podesavanjaSortiranjaAdministratorskihZahteva);

                IEnumerable<ZahtevAdministratoruBezTekstaDTO> zahteviAdministratoruIzlaz = _mapper.Map<IEnumerable<ZahtevAdministratoruEntitet>, IEnumerable<ZahtevAdministratoruBezTekstaDTO>>(zahteviAdminstratoru);
                return new OkObjectResult(zahteviAdministratoruIzlaz);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public ActionResult<TekstDTO> PribaviTekstAdministratorskogZahteva(PribaviTekstAdministratorskogZahtevaDTO zahtevZaPribavljanjeTeksta)
        {
            try
            {
                var vremeSlanjaUTC = _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(zahtevZaPribavljanjeTeksta.VremeSlanja);
                var administratorskiZahtev = _administratorskiZahtevRepozitorijum.PribaviSaUslovom(administratorskiZahtev => administratorskiZahtev.Autor.KorisnickoIme == zahtevZaPribavljanjeTeksta.KorisnickoImeAutora && administratorskiZahtev.VremeSlanja == vremeSlanjaUTC,
                                                                                                   new List<Expression<Func<ZahtevAdministratoruEntitet, object>>>() { administratorskiZahtev => administratorskiZahtev.Autor });

                var tekstZahteva = _mapper.Map<ITekstEntitet, TekstDTO>(administratorskiZahtev);

                return new OkObjectResult(tekstZahteva);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public ActionResult<IEnumerable<ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTO>> PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijala(PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTO filteriZaPribavljanje)
        {
            try
            {
                var zahtevZaDodavanjeIliAzuriranjeMaterijalaFilter = _mapper.Map<PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTO, ZahtevZaDodavanjeIliAzuriranjeMaterijalaFilter>(filteriZaPribavljanje);

                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet), new string[] {"Autor"}},
                    {typeof(MaterijalEntitet), new string[] {}},
                    {typeof(OblastEntitet), new string[] {"Nadoblast"}}
                };
                var zaUgnjezdenoUkljucivanje = new Dictionary<Expression<Func<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, object>>, List<Expression<Func<object, object>>>>()
                {
                    { zahtevZaDodavanjeIliAzuriranjeMaterijala => zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal, new List<Expression<Func<object, object>>>() { materijal => (materijal as MaterijalEntitet).Nadoblast }}
                };
                var pribavljeniZahtevi = _pomocnikServisa.PribaviSveOdKolikoSaFilterima(zahtevZaDodavanjeIliAzuriranjeMaterijalaFilter,
                                                                                        _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                                                                                        int.Parse(filteriZaPribavljanje.OdIndeksa),
                                                                                        int.Parse(filteriZaPribavljanje.Koliko),
                                                                                        propsZaPreskociti,
                                                                                        null,
                                                                                        zaUgnjezdenoUkljucivanje);
                var zahteviBezTeksta = _mapper.Map<IEnumerable<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>, IEnumerable<ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTO>>(pribavljeniZahtevi);
                return new OkObjectResult(zahteviBezTeksta);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public ActionResult<TekstDTO> PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijala(PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO zahtevZaPribavljanjeTeksta)
        {
            try
            {
                var zahtevZaDodavanjeIliAzuriranjeMaterijala = _mapper.Map<IPribaviZahtevZaDodavanjeIliAzuriranjeMaterijala, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>(zahtevZaPribavljanjeTeksta);

                var tekstZahtevaZaDodavanjeIliAzuriranjeMaterijala = _mapper.Map<ITekstEntitet, TekstDTO>(zahtevZaDodavanjeIliAzuriranjeMaterijala);
                return new OkObjectResult(tekstZahtevaZaDodavanjeIliAzuriranjeMaterijala);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> ObradiZahtevZaDodavanjeIliAzuriranjeMaterijala(ObradaZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO zahtevZaObradu)
        {
            try
            {
                var zahtevZaDodavanjeIliAzuriranjeMaterijala = _mapper.Map<IPribaviZahtevZaDodavanjeIliAzuriranjeMaterijala, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>(zahtevZaObradu);
                var prihvacen = bool.Parse(zahtevZaObradu.Prihvacen);

                if (prihvacen)
                {
                    zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Status = StatusMaterijala.Dostupan;
                    var izmenaZaDodavanje = _mapper.Map<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, IstorijaIzmenaEntitet>(zahtevZaDodavanjeIliAzuriranjeMaterijala);
                    if (zahtevZaDodavanjeIliAzuriranjeMaterijala.TipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala)
                    {
                        zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.IDNaFajlSistemu = zahtevZaDodavanjeIliAzuriranjeMaterijala.IdNaFajlSistemu;
                    }
                    await _izmenaRepozitorijum.Dodaj(izmenaZaDodavanje, false);
                }
                else
                {
                    if (zahtevZaDodavanjeIliAzuriranjeMaterijala.TipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala)
                    {
                        //TODO: Brisanje sa FS
                        await _materijalRepozitorijum.Ukloni(zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal);
                    }
                    else if (zahtevZaDodavanjeIliAzuriranjeMaterijala.TipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala)
                    {
                        zahtevZaDodavanjeIliAzuriranjeMaterijala.Materijal.Status = StatusMaterijala.Dostupan;
                    }
                }
                await _zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.Ukloni(zahtevZaDodavanjeIliAzuriranjeMaterijala);
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }
    }
}