using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Materijal")]
    public class MaterijalKontroler : Controller
    {
        private readonly IMaterijalServis _materijalServis;

        public MaterijalKontroler(IMaterijalServis materijalServis)
        {
            _materijalServis = materijalServis;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> DownloadFile()
        {
            Console.WriteLine("Ulezo");

            var bytes = await System.IO.File.ReadAllBytesAsync(@"C:\Users\Alexa\Desktop\file-sample_1MB.docx");
            Console.WriteLine(bytes.Length);
            return File(bytes, "application/msword", "jepseSomi");
        }
        [HttpPost]
        [Route("Oceni")]
        [Authorize]
        public async Task<IActionResult> Oceni(DodajOcenuDTO ocenjivanje)
        {
            return await _materijalServis.Oceni(ocenjivanje);
        }

        [HttpPost]
        [Route("DodajKomentar")]
        [Authorize]
        public async Task<IActionResult> DodajKomentar(DodajKomentarDTO komentarZaDodavanje)
        {
            return await _materijalServis.DodajKomentar(komentarZaDodavanje);
        }

        [HttpDelete]
        [Route("ObrisiKomentar")]
        [Authorize]
        public async Task<IActionResult> ObrisiKomentar(BrisanjeKomentaraDTO komentarZaBrisanje)
        {
            return await _materijalServis.ObrisiKomentar(komentarZaBrisanje);
        }
        [HttpDelete]
        [Route("ObrisiSvojKomentar")]
        [Authorize]
        public async Task<IActionResult> ObrisiSvojKomentar(BrisanjeSvogKomentaraDTO komentarZaBrisanje)
        {
            return await _materijalServis.ObrisiSvojKomentar(komentarZaBrisanje);
        }

        [HttpPost]
        [Route("PribaviKomentare")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<KomentarIzlazniDTO>>> PribaviKomentare(PribavljanjeKomentaraDTO pribavljanjeKomentaraFilter)
        {
            return await Task.FromResult(_materijalServis.PribaviKomentare(pribavljanjeKomentaraFilter));
        }

        [HttpPut]
        [Route("AzurirajKomentar")]
        [Authorize]
        public async Task<IActionResult> AzurirajKomentar(AzuriranjeKomentaraDTO azuriranjeKomentaraDTO)
        {
            return await _materijalServis.AzurirajKomentar(azuriranjeKomentaraDTO);
        }
        [HttpPost]
        [Route("PribaviUkupnuOcenuIKorisnickuOcenu")]
        [Authorize]
        public async Task<ActionResult<UkupnaOcenaIKorisnickaOcenaDTO>> PribaviUkupnuOcenuIKorisnickuOcenu(PribaviUkupnuOcenuIKorisnickuOcenuDTO pribaviUkupnuOcenuDTO)
        {
            return await Task.FromResult(_materijalServis.PribaviUkupnuOcenuIKorisnickuOcenu(pribaviUkupnuOcenuDTO));
        }
    }
}