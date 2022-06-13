using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Servisi.Interfejsi
{
    public interface IKorisnickiNalogServis
    {
        Task<IActionResult> KreirajNalog(KreiranjeKorisnikaDTO korisnik);
        Task<IActionResult> Prijavljivanje(PrijavaDTO akrditivi);
        Task<IActionResult> Odjavljivanje();
        Task<IActionResult> ObrisiNalog(KorisnickoImeDTO korisnickiNalogZaBrisanje);
        Task<IActionResult> ResetujLozinku(KorisnickoImeDTO nalogZaResetovanje);
        Task<IActionResult> AzurirajSvojNalog(AzuriranjeSvogNalogaDTO podaciZaAzuriranje);
        bool ProveriPoslednjuPromenu(string korisnickoIme, string poslednjaPromena);
        ActionResult<IEnumerable<KorisnickiNalogDTO>> PribaviSveKorisnickeNalogePoFilterima(PribaviKorisnickeNalogeDTO filteriZaPribavljanje);
        Task<IActionResult> AzurirajNalog(AzuriranjeNalogaDTO podaciZaAzuriranje);
        ActionResult<KorisnikPodaciDTO> PribaviPodatkeOKorisniku(KorisnickoImeDTO korisnickoIme);
        IActionResult ProveriStatusPrijave();
    }
}