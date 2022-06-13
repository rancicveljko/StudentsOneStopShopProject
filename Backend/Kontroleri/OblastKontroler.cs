using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Oblasti")]
    public class OblastKontroler : Controller
    {
        private readonly IOblastServis _oblastServis;

        public OblastKontroler(IOblastServis oblastServis)
        {
            _oblastServis = oblastServis;
        }

        [HttpDelete]
        [Route("Obrisi")]
        [Authorize]
        public async Task<IActionResult> ObrisiOblast(PutanjaOblastiDTO oblastZaBrisanje)
        {
            return await _oblastServis.ObrisiOblast(oblastZaBrisanje);
        }

        [HttpPost]
        [Route("Kreiraj")]
        [Authorize]
        public async Task<IActionResult> KreirajOblast(KreiranjeOblastiDTO oblastDto)
        {
            return await _oblastServis.KreirajOblast(oblastDto);
        }

        [HttpGet]
        [Route("PribaviInfoOblasti")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OblastInfoIzlazniDTO>>> PribaviOblasti([FromBody] PribaviInfoOblastiDTO oblastiUlaz)
        {
            return await Task.FromResult(_oblastServis.PribaviInfoOblasti(oblastiUlaz));
        }

        [HttpPut]
        [Route("Premesti")]
        [Authorize]
        public async Task<IActionResult> PremestiOblast([FromBody] PremestanjeOblastiDTO premestanjeOblasti)
        {
            return await _oblastServis.PremestiOblast(premestanjeOblasti);
        }
        [HttpPost]
        [Route("PregledajSadrzaj")]
        [Authorize]
        public async Task<ActionResult<OblastSadrzajDTO>> PregledajSadrzajOblasti([FromBody] PutanjaOblastiZaPregledSadrzajaDTO pregledSadrzajaOblasti)
        {
            return await Task.FromResult(_oblastServis.PregledajSadrzaj(pregledSadrzajaOblasti));
        }

        [HttpPut]
        [Route("Azuriraj")]
        [Authorize]
        public async Task<IActionResult> AzurirajOblast([FromBody] AzuriranjeOblastiDTO azuriranjeOblastiDTO)
        {
            return await _oblastServis.AzurirajInfoOblasti(azuriranjeOblastiDTO);
        }

        [HttpGet]
        [Route("PribaviSve")]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<OblastPutanjaDTO>>> PribaviSve()
        {
            return await Task.FromResult(_oblastServis.PribaviSveOblasti());
        }
    }
}