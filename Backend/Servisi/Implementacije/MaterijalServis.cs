using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Filteri.Materijali;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciServisa;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.ProsirenjaMetoda;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Servisi.Implementacije
{
    public class MaterijalServis : IMaterijalServis
    {
        private readonly IPomocnikKolacic _pomocnikKolacic;
        private readonly IMapper _mapper;
        private readonly IPomocnikParser _pomocnikParser;
        private readonly IMaterijalRepozitorijum _materijalRepozitorijum;
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;
        private readonly IPomocnikServisa _pomocnikServisa;
        private readonly IOcenaRepozitorijum _ocenaRepozitorijum;
        private readonly IKomentarRepozitorijum _komentarRepozitorijum;

        public MaterijalServis(IPomocnikKolacic pomocnikKolacic,
                               IMapper mapper,
                               IPomocnikParser pomocnikParser,
                               IMaterijalRepozitorijum materijalRepozitorijum,
                               IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                               IPomocnikServisa pomocnikServisa,
                               IOcenaRepozitorijum ocenaRepozitorijum,
                               IKomentarRepozitorijum komentarRepozitorijum)
        {
            _pomocnikKolacic = pomocnikKolacic;
            _mapper = mapper;
            _pomocnikParser = pomocnikParser;
            _materijalRepozitorijum = materijalRepozitorijum;
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
            _pomocnikServisa = pomocnikServisa;
            _ocenaRepozitorijum = ocenaRepozitorijum;
            _komentarRepozitorijum = komentarRepozitorijum;
        }

        public IActionResult AzurirajMaterijal()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> AzurirajKomentar(AzuriranjeKomentaraDTO komentarZaAzuriranje)
        {
            try
            {
                var komentarEntitet = _mapper.Map<IPribaviKomentar, KomentarEntitet>(komentarZaAzuriranje);
                komentarEntitet.Tekst = komentarZaAzuriranje.Tekst;

                await _komentarRepozitorijum.Azuriraj(komentarEntitet);
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public IActionResult AzurirajSadrzajMaterijala()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> DodajKomentar(DodajKomentarDTO dodavanjeKomentara)
        {
            try
            {
                var komentar = _mapper.Map<DodajKomentarDTO, KomentarEntitet>(dodavanjeKomentara);
                await _komentarRepozitorijum.Dodaj(komentar);
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public IActionResult DodajMaterijal()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> ObrisiKomentar(BrisanjeKomentaraDTO komentarZaBrisanje)
        {
            try
            {
                var komentarEntitet = _mapper.Map<IPribaviKomentar, KomentarEntitet>(komentarZaBrisanje);

                await _komentarRepozitorijum.UkloniVise(komentarEntitet.Odgovori, false);
                await _komentarRepozitorijum.Ukloni(komentarEntitet);
                return new OkResult();
            }
            catch (System.Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public IActionResult ObrisiMaterijal()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> ObrisiSvojKomentar(BrisanjeSvogKomentaraDTO komentarZaBrisanje)
        {
            try
            {
                var brisanjeKomentaraDTO = _mapper.Map<IPribaviKomentar, BrisanjeKomentaraDTO>(komentarZaBrisanje);

                return await ObrisiKomentar(brisanjeKomentaraDTO);
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> Oceni(DodajOcenuDTO ocenaZaDodavanje)
        {
            try
            {
                var tipOcene = Enum.Parse<TipOcene>(ocenaZaDodavanje.TipOcene);
                var ocenaEntitet = _mapper.Map<DodajOcenuDTO, OcenaEntitet>(ocenaZaDodavanje);

                if (!ocenaZaDodavanje.DodajOcenu && ocenaEntitet.TipOcene == tipOcene)
                {
                    ocenaEntitet.Materijal.UkupnaOcena -= (int)ocenaEntitet.TipOcene;
                    await _ocenaRepozitorijum.Ukloni(ocenaEntitet);
                }
                else
                {
                    ocenaEntitet.Materijal.UkupnaOcena += (int)tipOcene;
                    if (ocenaZaDodavanje.DodajOcenu) await _ocenaRepozitorijum.Dodaj(ocenaEntitet);
                    else
                    {
                        ocenaEntitet.Materijal.UkupnaOcena += (int)tipOcene;
                        ocenaEntitet.TipOcene = tipOcene;
                        await _ocenaRepozitorijum.Azuriraj(ocenaEntitet);
                    }
                }
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public IActionResult PremestiMaterijal()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult PribaviInfoMaterijala()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult<IEnumerable<KomentarIzlazniDTO>> PribaviKomentare(PribavljanjeKomentaraDTO pribavljanjeKomentaraFilteri)
        {
            try
            {
                var komentariFilter = _mapper.Map<PribavljanjeKomentaraDTO, KomentariFilter>(pribavljanjeKomentaraFilteri);

                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(KomentarEntitet),new string[] {"Autor", "OdgovorNa", "Materijal"}}
                };

                var komentari = _pomocnikServisa.PribaviSveOdKolikoSaFilterima<KomentarEntitet>(komentariFilter,
                                                                                                _komentarRepozitorijum,
                                                                                                int.Parse(pribavljanjeKomentaraFilteri.OdIndeksa),
                                                                                                int.Parse(pribavljanjeKomentaraFilteri.Koliko), propsZaPreskociti, new List<Expression<Func<KomentarEntitet, object>>>() { komentar => komentar.Materijal, komentar => komentar.Autor });
                var komentariIzlaz = _mapper.Map<IEnumerable<KomentarEntitet>, IEnumerable<KomentarIzlazniDTO>>(komentari);
                return new OkObjectResult(komentariIzlaz);
            }
            catch (System.Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public IActionResult PribaviMaterijal()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult<UkupnaOcenaIKorisnickaOcenaDTO> PribaviUkupnuOcenuIKorisnickuOcenu(PribaviUkupnuOcenuIKorisnickuOcenuDTO pribaviUkupnuOcenuDTO)
        {
            try
            {
                var materijal = _mapper.Map<IPutanjaNazivIEkstenzijaMaterijala, MaterijalEntitet>(pribaviUkupnuOcenuDTO);


                var ukupnaOcenaIzlaz = _mapper.Map<MaterijalEntitet, UkupnaOcenaIKorisnickaOcenaDTO>(materijal);

                return new OkObjectResult(ukupnaOcenaIzlaz);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }
    }
}