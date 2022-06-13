using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Servisi.Interfejsi
{
    public interface IMaterijalServis
    {
        IActionResult PribaviMaterijal();
        IActionResult PribaviInfoMaterijala();
        Task<IActionResult> Oceni(DodajOcenuDTO ocenaZaDodavanje);
        Task<IActionResult> DodajKomentar(DodajKomentarDTO komentarZaDodavanje);
        Task<IActionResult> ObrisiKomentar(BrisanjeKomentaraDTO komentarZaBrisanje);
        Task<IActionResult> ObrisiSvojKomentar(BrisanjeSvogKomentaraDTO komentarZaBrisanje);
        IActionResult ObrisiMaterijal();
        IActionResult AzurirajMaterijal();
        IActionResult PremestiMaterijal();
        ActionResult<IEnumerable<KomentarIzlazniDTO>> PribaviKomentare(PribavljanjeKomentaraDTO pribavljanjeKomentara);
        Task<IActionResult> AzurirajKomentar(AzuriranjeKomentaraDTO azuriranjeKomentaraDTO);
        ActionResult<UkupnaOcenaIKorisnickaOcenaDTO> PribaviUkupnuOcenuIKorisnickuOcenu(PribaviUkupnuOcenuIKorisnickuOcenuDTO pribaviUkupnuOcenuDTO);
    }
}