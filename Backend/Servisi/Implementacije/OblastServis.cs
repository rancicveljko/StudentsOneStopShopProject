using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Filteri.Oblasti;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciServisa;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Servisi.Implementacije
{
    public class OblastServis : IOblastServis
    {
        private readonly IMapper _mapper;
        private readonly IOblastRepozitorijum _oblastRepozitorijum;
        private readonly IPomocnikServisa _pomocnikServisa;
        private readonly IPodesavanjaSortiranjaOblasti _podesavanjaSortiranjaOblasti;

        public OblastServis(IMapper mapper,
                            IOblastRepozitorijum oblastRepozitorijum,
                            IPomocnikServisa pomocnikServisa,
                            IPomocnikParser pomocnikParser,
                            IPodesavanjaSortiranjaOblasti podesavanjaSortiranjaOblasti)
        {
            _mapper = mapper;
            _oblastRepozitorijum = oblastRepozitorijum;
            _pomocnikServisa = pomocnikServisa;
            _podesavanjaSortiranjaOblasti = podesavanjaSortiranjaOblasti;
        }

        public async Task<IActionResult> AzurirajInfoOblasti(AzuriranjeOblastiDTO azuriranjeOblastiDTO)
        {
            try
            {
                var oblast = _oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja == azuriranjeOblastiDTO.Putanja);
                Task azuriranjePutanja = Task.CompletedTask;
                if (azuriranjeOblastiDTO.Naziv != null)
                    azuriranjePutanja = _oblastRepozitorijum.AzurirajPutanjuZaOblastiKojeSadrzePutanju(oblast.Putanja, oblast.Putanja.Replace(oblast.Naziv, azuriranjeOblastiDTO.Naziv), false);

                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(OblastEntitet),new string[] {"Nadoblast"}}
                };
                var oblastAzuriranje = _mapper.Map<AzuriranjeOblastiDTO, OblastAzuriranje>(azuriranjeOblastiDTO);
                await azuriranjePutanja;
                await _pomocnikServisa.AzurirajEntitet(oblastAzuriranje, oblast, _oblastRepozitorijum, propsZaPreskociti);

                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> KreirajOblast(KreiranjeOblastiDTO oblastZaKreiranje)
        {
            try
            {
                var novaOblast = _mapper.Map<KreiranjeOblastiDTO, OblastEntitet>(oblastZaKreiranje);
                await _oblastRepozitorijum.Dodaj(novaOblast);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> ObrisiOblast(PutanjaOblastiDTO oblastZaBrisanje)
        {
            try
            {
                await _oblastRepozitorijum.UkloniVise(await _oblastRepozitorijum.PribaviSveSaUslovomAsync(oblast => oblast.Putanja == oblastZaBrisanje.Putanja || oblast.Putanja.StartsWith(oblastZaBrisanje.Putanja)));
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (System.Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public ActionResult<OblastSadrzajDTO> PregledajSadrzaj(PutanjaOblastiDTO oblastZaPregledanje)
        {
            try
            {
                var oblast = _oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja == oblastZaPregledanje.Putanja, new List<Expression<Func<OblastEntitet, object>>>() { oblast => oblast.Podoblasti, oblast => oblast.Materijali });
                var sadrzajIzlaz = _mapper.Map<OblastEntitet, OblastSadrzajDTO>(oblast);

                return new OkObjectResult(sadrzajIzlaz);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> PremestiOblast(PremestanjeOblastiDTO oblastZaPremestanje)
        {
            try
            {
                var putanjaPocetnogFoldera = _oblastRepozitorijum.PribaviAdresuPocetnogFoldera();
                var oblast = _oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja == oblastZaPremestanje.Putanja, new List<Expression<Func<OblastEntitet, object>>>() { oblast => oblast.Nadoblast });

                if (string.IsNullOrEmpty(oblastZaPremestanje.PutanjaNoveNadoblasti)) oblastZaPremestanje.PutanjaNoveNadoblasti = putanjaPocetnogFoldera;
                else if (!oblastZaPremestanje.PutanjaNoveNadoblasti.StartsWith(putanjaPocetnogFoldera)) oblastZaPremestanje.PutanjaNoveNadoblasti = putanjaPocetnogFoldera + oblastZaPremestanje.PutanjaNoveNadoblasti;

                if (!_oblastRepozitorijum.PostojiEntitetSaUslovom(oblast => oblast.Putanja == oblastZaPremestanje.PutanjaNoveNadoblasti))
                {
                    var naziv = oblastZaPremestanje.PutanjaNoveNadoblasti.Split("/").Last();
                    await KreirajOblast(new KreiranjeOblastiDTO()
                    {
                        Naziv = naziv,
                        Putanja = oblastZaPremestanje.PutanjaNoveNadoblasti.Replace("/" + naziv, ""),
                        PotrebnoOdobrenje = oblast.Nadoblast.PotrebnoOdobrenje.ToString()
                    });
                }


                var azuriranjePutanja = _oblastRepozitorijum.AzurirajPutanjuZaOblastiKojeSadrzePutanju(oblastZaPremestanje.Putanja, oblastZaPremestanje.PutanjaNoveNadoblasti + "/" + oblast.Naziv, false);

                var oblastPremestanjeAzuriranje = _mapper.Map<PremestanjeOblastiDTO, PremestanjeOblastiAzuriranje>(oblastZaPremestanje);
                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(OblastEntitet),new string[] {"Nadoblast"}}
                };
                await azuriranjePutanja;
                await _pomocnikServisa.AzurirajEntitet(oblastPremestanjeAzuriranje, oblast, _oblastRepozitorijum, propsZaPreskociti);

                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public ActionResult<IEnumerable<OblastInfoIzlazniDTO>> PribaviInfoOblasti(PribaviInfoOblastiDTO filteriZaPribavljanje)
        {
            try
            {
                var oblastFilter = _mapper.Map<PribaviInfoOblastiDTO, OblastInfoFilter>(filteriZaPribavljanje);

                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(OblastEntitet), new string[] {"Nadoblast"} }
                };

                var zaUkljucivanje = new List<Expression<Func<OblastEntitet, object>>>()
                {
                    oblasti => oblasti.Podoblasti,
                    oblasti => oblasti.Materijali
                };


                var oblastiLista = _pomocnikServisa.PribaviSveOdKolikoSaFilterima<OblastEntitet>(oblastFilter,
                                                                                                 _oblastRepozitorijum,
                                                                                                 int.Parse(filteriZaPribavljanje.OdIndeksa),
                                                                                                 int.Parse(filteriZaPribavljanje.Koliko),
                                                                                                 propsZaPreskociti,
                                                                                                 zaUkljucivanje,
                                                                                                 null,
                                                                                                 string.IsNullOrEmpty(filteriZaPribavljanje.KriterijumSortiranja) ? null : Enum.Parse<SortiranjeOblasti>(filteriZaPribavljanje.KriterijumSortiranja),
                                                                                                 _podesavanjaSortiranjaOblasti);

                var oblastiIzlaz = _mapper.Map<IEnumerable<OblastEntitet>, IEnumerable<OblastInfoIzlazniDTO>>(oblastiLista);
                return new OkObjectResult(oblastiIzlaz);
            }
            catch (System.Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public ActionResult<IEnumerable<OblastPutanjaDTO>> PribaviSveOblasti()
        {
            try
            {
                var oblasti = _oblastRepozitorijum.PribaviSve(null,
                                                              null,
                                                              null,
                                                              _podesavanjaSortiranjaOblasti);

                if (oblasti == null)
                    return new BadRequestResult();

                var oblastiIzlaz = _mapper.Map<IEnumerable<OblastEntitet>, IEnumerable<OblastPutanjaDTO>>(oblasti);

                return new OkObjectResult(oblastiIzlaz);
            }
            catch (System.Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }
    }
}