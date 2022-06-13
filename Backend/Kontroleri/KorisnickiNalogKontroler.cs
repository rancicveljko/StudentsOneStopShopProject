using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciKontrolera;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Korisnici")]
    [ApiController]
    public class KorisnickiNalogKontroler : Controller
    {
        private readonly IKorisnickiNalogServis _korisnickiNalogServis;
        private readonly IPomocnikKontrolera _pomocnik;
        private readonly IKorisnickiNalogRepozitorijum _korisnikRepozitorijum;
        private readonly IPomocnikParser _pomocnikParser;

        public KorisnickiNalogKontroler(IKorisnickiNalogServis korisnickiNalogServis,
                                        IPomocnikKontrolera pomocnik,
                                        IKorisnickiNalogRepozitorijum korisnikRepozitorijum,
                                        IPomocnikParser pomocnikParser)
        {
            _korisnickiNalogServis = korisnickiNalogServis;
            _pomocnik = pomocnik;
            _korisnikRepozitorijum = korisnikRepozitorijum;
            _pomocnikParser = pomocnikParser;
        }

        [HttpPost]
        [Route("Kreiraj")]
        [Authorize]
        public async Task<IActionResult> Kreiraj([FromBody] KreiranjeKorisnikaDTO korisnikZaKreiranje)
        {

            return await _korisnickiNalogServis.KreirajNalog(korisnikZaKreiranje);
        }
        [HttpPost]
        [Route("Prijava")]
        public async Task<IActionResult> Prijava([FromBody] PrijavaDTO akreditivi)
        {
            return await _korisnickiNalogServis.Prijavljivanje(akreditivi);
        }
        [HttpGet]
        [Route("Odjava")]
        [Authorize]
        public async Task<IActionResult> Odjava()
        {
            return await _korisnickiNalogServis.Odjavljivanje();
        }
        [HttpDelete]
        [Route("Obrisi")]
        [Authorize]
        public async Task<IActionResult> Obrisi([FromBody] KorisnickoImeDTO KorisnickoIme)
        {
            return await _korisnickiNalogServis.ObrisiNalog(KorisnickoIme);
        }
        [HttpPost]
        [Route("PribaviSveKorisnickeNaloge")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<KorisnickiNalogDTO>>> PribaviSveKorisnickeNaloge([FromBody] PribaviKorisnickeNalogeDTO filteriZaPribavljanje)
        {
            return await Task.FromResult(_korisnickiNalogServis.PribaviSveKorisnickeNalogePoFilterima(filteriZaPribavljanje));
        }
        
        [HttpPost]
        [Route("PribaviPodatkeOKorisniku")]
        [Authorize]
        public async Task<ActionResult<KorisnikPodaciDTO>> PribaviPodatkeOKorisniku([FromBody] KorisnickoImeDTO korisnickoIme)
        {
            return await Task.FromResult(_korisnickiNalogServis.PribaviPodatkeOKorisniku(korisnickoIme));
        }
        [HttpPatch]
        [Route("AzurirajSvojNalog")]
        [Authorize]
        public async Task<IActionResult> AzurirajSvojNalog([FromBody] AzuriranjeSvogNalogaDTO podaciZaAzuriranje)
        {
            return await _korisnickiNalogServis.AzurirajSvojNalog(podaciZaAzuriranje);
        }
        [HttpPut]
        [Route("AzurirajNalog")]
        [Authorize]
        public async Task<IActionResult> AzurirajNalog([FromBody] AzuriranjeNalogaDTO podaciZaAzuriranje)
        {
            return await _korisnickiNalogServis.AzurirajNalog(podaciZaAzuriranje);
        }
        [HttpPatch]
        [Route("ResetujLozinku")]
        [Authorize]
        public async Task<IActionResult> ResetujLozinku([FromBody] KorisnickoImeDTO nalogZaResetovanje)
        {
            return await _korisnickiNalogServis.ResetujLozinku(nalogZaResetovanje);
        }
        [HttpGet]
        [Route("ProveriStatusPrijave")]
        public IActionResult ProveriStatusPrijave()
        {
            return _korisnickiNalogServis.ProveriStatusPrijave();
        }
    }
}