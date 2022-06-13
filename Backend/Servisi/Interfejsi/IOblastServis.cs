using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Servisi.Interfejsi
{
    public interface IOblastServis
    {
        Task<IActionResult> KreirajOblast(KreiranjeOblastiDTO oblastZaKreiranje);
        Task<IActionResult> ObrisiOblast(PutanjaOblastiDTO oblastZaBrisanje);
        Task<IActionResult> AzurirajInfoOblasti(AzuriranjeOblastiDTO azuriranjeOblastiDTO);
        ActionResult<OblastSadrzajDTO> PregledajSadrzaj(PutanjaOblastiDTO oblastZaPregledanje);
        ActionResult<IEnumerable<OblastInfoIzlazniDTO>> PribaviInfoOblasti(PribaviInfoOblastiDTO oblastiUlaz);
        Task<IActionResult> PremestiOblast(PremestanjeOblastiDTO premestanjeOblasti);
        ActionResult<IEnumerable<OblastPutanjaDTO>> PribaviSveOblasti();
    }
}