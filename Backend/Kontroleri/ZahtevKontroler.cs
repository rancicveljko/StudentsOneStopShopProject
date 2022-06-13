using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Zahtevi")]
    public class ZahtevKontroler : Controller
    {
        private readonly IZahtevServis _zahtevServis;

        public ZahtevKontroler(IZahtevServis zahtevServis)
        {
            _zahtevServis = zahtevServis;

        }
        [HttpPost]
        [Route("PosaljiZahtevAdministratoru")]
        [Authorize]
        public async Task<IActionResult> KreirajAdministratorskiZahtev([FromBody] ZahtevAdministratoruDTO zahtevZaKreiranje)
        {
            return await _zahtevServis.KreirajZahtevAdministratoru(zahtevZaKreiranje);
        }

        [HttpPost]
        [Route("PribaviSveAdministratorskeZahteve")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ZahtevAdministratoruBezTekstaDTO>>> PribaviSveAdministratorskeZahteve([FromBody] PribaviSveAdministratorskeZahteveDTO zahteviZaPribavljanje)
        {
            return await Task.FromResult(_zahtevServis.PribaviSveAdministratorskeZahtevePoFilterima(zahteviZaPribavljanje));
        }

        [HttpPost]
        [Route("PribaviTekstAdministratorskogZahteva")]
        [Authorize]
        public async Task<ActionResult<TekstDTO>> PribaviTekstAdministratorskogZahteva([FromBody] PribaviTekstAdministratorskogZahtevaDTO tekstZahtevaDto)
        {
            return await Task.FromResult(_zahtevServis.PribaviTekstAdministratorskogZahteva(tekstZahtevaDto));
        }

        [HttpPut]
        [Route("ObradiAdministratorskiZahtev")]
        [Authorize]
        public async Task<IActionResult> ObradiAdministratorskiZahtev([FromBody] ObradaZahtevaAdministratoruDTO obradaZahtevaAdministratoru)
        {
            return await _zahtevServis.ObradiAdministratorskiZahtev(obradaZahtevaAdministratoru);
        }
        [HttpPost]
        [Route("PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijala")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTO>>> PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijala([FromBody] PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTO zahteviZaPribavljanje)
        {
            return await Task.FromResult(_zahtevServis.PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijala(zahteviZaPribavljanje));
        }
        [HttpPost]
        [Route("PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijala")]
        [Authorize]
        public async Task<ActionResult<TekstDTO>> PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijala([FromBody] PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO zahtevZaPribavljanjeTeksta)
        {
            return await Task.FromResult(_zahtevServis.PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijala(zahtevZaPribavljanjeTeksta));
        }
        [HttpPost]
        [Route("ObradiZahtevZaDodavanjeIliAzuriranjeMaterijala")]
        [Authorize]
        public async Task<IActionResult> ObradiZahtevZaDodavanjeIliAzuriranjeMaterijala([FromBody] ObradaZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO zahtevZaObradu)
        {
            return await _zahtevServis.ObradiZahtevZaDodavanjeIliAzuriranjeMaterijala(zahtevZaObradu);
        }
    }
}