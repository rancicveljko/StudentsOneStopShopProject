using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Servisi.Interfejsi
{
    public interface IZahtevServis
    {
        Task<IActionResult> ObradiAdministratorskiZahtev(ObradaZahtevaAdministratoruDTO zahtevZaObradu);
        Task<IActionResult> ObradiZahtevZaDodavanjeIliAzuriranjeMaterijala(ObradaZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO zahtevZaObradu);
        ActionResult<IEnumerable<ZahtevAdministratoruBezTekstaDTO>> PribaviSveAdministratorskeZahtevePoFilterima(PribaviSveAdministratorskeZahteveDTO filteriZaPribavljanje);
        ActionResult<IEnumerable<ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTO>> PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijala(PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTO filteriZaPribavljanje);
        Task<IActionResult> KreirajZahtevAdministratoru(ZahtevAdministratoruDTO zahtevAdministratoru);
        ActionResult<TekstDTO> PribaviTekstAdministratorskogZahteva(PribaviTekstAdministratorskogZahtevaDTO zahtevZaPribavljanjeTeksta);
        ActionResult<TekstDTO> PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijala(PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO zahtevZaPribavljanjeTeksta);
    }
}