using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Filteri.Korisnici;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciServisa;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Backend.Servisi.Implementacije
{
    public class KorisnickiNalogServis : IKorisnickiNalogServis
    {
        private readonly IConfiguration _konfiguracija;
        private readonly IPomocnikKriptovanje _pomocnikKriptovanje;
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;
        private readonly IMapper _mapper;
        private readonly IPomocnikServisa _pomocnikServisa;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAdministratorskiZahtevRepozitorijum _administratorskiZahtevRepozitorijum;
        private readonly IPodesavanjaSortiranjaKorisnickiNalog _podesavanjaSortiranjaKorisnickiNalog;
        private readonly IPomocnikKolacic _pomocnikKolacic;
        private readonly IKorisnickiNalogOblastRepozitorijum _korisnickiNalogOblastRepozitorijum;

        public KorisnickiNalogServis(IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                     IMapper mapper,
                                     IPomocnikServisa pomocnikServisa,
                                     IPomocnikKolacic pomocnikKolacic,
                                     IKorisnickiNalogOblastRepozitorijum korisnickiNalogOblastRepozitorijum,
                                     IPomocnikKriptovanje pomocnikKriptovanje,
                                     IHttpContextAccessor httpContextAccessor,
                                     IConfiguration konfiguracija,
                                     IAdministratorskiZahtevRepozitorijum administratorskiZahtevRepozitorijum,
                                     IPodesavanjaSortiranjaKorisnickiNalog podesavanjaSortiranjaKorisnickiNalog)
        {
            _konfiguracija = konfiguracija;
            _pomocnikKriptovanje = pomocnikKriptovanje;
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
            _mapper = mapper;
            _pomocnikServisa = pomocnikServisa;
            _pomocnikKolacic = pomocnikKolacic;
            _korisnickiNalogOblastRepozitorijum = korisnickiNalogOblastRepozitorijum;
            _httpContextAccessor = httpContextAccessor;
            _administratorskiZahtevRepozitorijum = administratorskiZahtevRepozitorijum;
            _podesavanjaSortiranjaKorisnickiNalog = podesavanjaSortiranjaKorisnickiNalog;
        }
        private async Task<IActionResult> PonovoPrijavi(string korisnickoIme, string lozinka)
        {
            await Odjavljivanje();
            var akreditivi = new PrijavaDTO();
            akreditivi.KorisnickoIme = korisnickoIme;
            akreditivi.Lozinka = lozinka;
            akreditivi.ZapamtiMe = _pomocnikKolacic.IzvadiClaimIzKolacica(_konfiguracija["KolacicConfig:Claims:ZapamtiMe"]);
            return await Prijavljivanje(akreditivi);
        }

        public async Task<IActionResult> AzurirajSvojNalog(AzuriranjeSvogNalogaDTO podaciZaAzuriranje)
        {
            try
            {
                var korisnickoIme = _pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier);
                var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickoIme, new List<Expression<Func<KorisnickiNalogEntitet, object>>>() { korisnickiNalog => korisnickiNalog.Korisnik });
                var lozinka = podaciZaAzuriranje.Lozinka;

                bool ponovoPrijavi = false;
                if (podaciZaAzuriranje.NovaLozinka != null)
                {
                    lozinka = podaciZaAzuriranje.NovaLozinka;
                    podaciZaAzuriranje.NovaLozinka = _pomocnikKriptovanje.KriptujLozinku(podaciZaAzuriranje.NovaLozinka);
                    ponovoPrijavi = true;
                }
                if (podaciZaAzuriranje.KorisnickoIme != null)
                {
                    korisnickoIme = podaciZaAzuriranje.KorisnickoIme;
                    ponovoPrijavi = true;
                }

                var KorisnikAzuriranje = _mapper.Map<AzuriranjeSvogNalogaDTO, KorisnikSvojNalogAzuriranje>(podaciZaAzuriranje);
                var propsZaPreskociti = new Dictionary<Type, string[]>
                {
                    { typeof(KorisnickiNalogEntitet), new string[] {} },
                    { typeof(KorisnikEntitet), new string[] { "KorisnickiNalog", "OsnovniKorisnikPodaci" } }
                };

                if (ponovoPrijavi) korisnickiNalog.PoslednjaPromena = DateTime.UtcNow;
                await _pomocnikServisa.AzurirajEntitet<KorisnickiNalogEntitet, KorisnikSvojNalogAzuriranje>(KorisnikAzuriranje, korisnickiNalog, _korisnickiNalogRepozitorijum, propsZaPreskociti);
                if (ponovoPrijavi) return await PonovoPrijavi(korisnickoIme, lozinka);
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> KreirajNalog(KreiranjeKorisnikaDTO korisnikZaKreiranje)
        {
            try
            {
                var korisnickiNalog = _mapper.Map<KreiranjeKorisnikaDTO, KorisnickiNalogEntitet>(korisnikZaKreiranje);

                await _korisnickiNalogRepozitorijum.Dodaj(korisnickiNalog);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(e);
            }
        }

        public async Task<IActionResult> ObrisiNalog(KorisnickoImeDTO korisnickiNalogZaBrisanje)
        {
            try
            {
                Task brisanjeNadleznosti = Task.CompletedTask;
                var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickiNalogZaBrisanje.KorisnickoIme, new List<Expression<Func<KorisnickiNalogEntitet, object>>>() { korisnickiNalog => korisnickiNalog.NadlezanZaOblasti });
                if (korisnickiNalog.Uloga == Uloga.Napredni_Korisnik)
                {
                    brisanjeNadleznosti = _korisnickiNalogOblastRepozitorijum.UkloniVise(korisnickiNalog.NadlezanZaOblasti, false);
                }
                var brisanjeAdministratorskihZahteva = _administratorskiZahtevRepozitorijum.UkloniVise(_administratorskiZahtevRepozitorijum.PribaviSveSaUslovom(administratorskiZahtev => administratorskiZahtev.AutorID.Equals(korisnickiNalog.KorisnikID)
                                                                                                                                                                                          || administratorskiZahtev.SubjekatID.Equals(korisnickiNalog.KorisnikID)),
                                                                                                       false);
                Task.WaitAll(brisanjeNadleznosti, brisanjeAdministratorskihZahteva);
                await _korisnickiNalogRepozitorijum.Ukloni(korisnickiNalog);
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> ResetujLozinku(KorisnickoImeDTO nalogZaResetovanje)
        {
            try
            {
                await _korisnickiNalogRepozitorijum.ResetujLozinku(nalogZaResetovanje.KorisnickoIme);
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> Odjavljivanje()
        {
            try
            {
                var odjava = _httpContextAccessor.HttpContext.SignOutAsync();
                await odjava;
                return _pomocnikServisa.ProveraIzvrsenostiZadatka(odjava, StatusCodes.Status200OK, "Uspešno odjavljivanje!");
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public async Task<IActionResult> Prijavljivanje(PrijavaDTO akreditivi)
        {
            try
            {
                var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(akreditivi.KorisnickoIme, new List<Expression<Func<KorisnickiNalogEntitet, object>>>());
                if (korisnickiNalog.StatusNaloga == StatusKorisnickogNaloga.Aktivan)
                {
                    var vremePrijavljivanja = DateTime.UtcNow;
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, akreditivi.KorisnickoIme),
                    new Claim(ClaimTypes.Role, korisnickiNalog.Uloga.ToString()),
                    new Claim(_konfiguracija["KolacicConfig:Claims:PoslednjaPromena"], korisnickiNalog.PoslednjaPromena.ToString()),
                    new Claim(_konfiguracija["KolacicConfig:Claims:VremePrijavljivanja"], vremePrijavljivanja.ToString()),
                    new Claim(_konfiguracija["KolacicConfig:Claims:ZapamtiMe"], akreditivi.ZapamtiMe.ToString())
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                    var podesavanjaAutentikacije = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(_konfiguracija.GetValue<int>("KolacicConfig:VremeTrajanja")),
                        IssuedUtc = vremePrijavljivanja,
                        IsPersistent = Boolean.Parse(akreditivi.ZapamtiMe),
                    };
                    var prijava = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                                               new ClaimsPrincipal(claimsIdentity),
                                                                               podesavanjaAutentikacije);
                    await prijava;
                    return _pomocnikServisa.ProveraIzvrsenostiZadatka(prijava, StatusCodes.Status200OK, korisnickiNalog.Uloga.ToString());
                }
                return new UnauthorizedResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public bool ProveriPoslednjuPromenu(string korisnickoIme, string poslednjaPromena)
        {
            try
            {
                return _korisnickiNalogRepozitorijum.ProveriPoslednjuPromenu(korisnickoIme, poslednjaPromena);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public ActionResult<IEnumerable<KorisnickiNalogDTO>> PribaviSveKorisnickeNalogePoFilterima(PribaviKorisnickeNalogeDTO filteriZaPribavljanje)
        {
            try
            {
                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(KorisnickiNalogEntitet), new string[]{}},
                    {typeof(KorisnikEntitet),new string[] {"KorisnickiNalog"}},
                    {typeof(OsnovniKorisnikPodaciEntitet), new string[] {"Korisnik"}}
                };
                var korisnickiNalogFilter = _mapper.Map<PribaviKorisnickeNalogeDTO, KorisnickiNalogFilter>(filteriZaPribavljanje);

                var zaUkljucivanje = new List<Expression<Func<KorisnickiNalogEntitet, object>>>()
                {
                    korisnickiNalog => korisnickiNalog.Korisnik,
                };

                if ((korisnickiNalogFilter.Uloga == null
                     || korisnickiNalogFilter.Uloga == Uloga.Osnovni_Korisnik) && (korisnickiNalogFilter.Privilegije != null || korisnickiNalogFilter.IDBroj != null))
                {
                    zaUkljucivanje.Add(korisnickiNalog => korisnickiNalog.Korisnik.OsnovniKorisnikPodaci);
                }
                if ((korisnickiNalogFilter.Uloga == null
                     || korisnickiNalogFilter.Uloga == Uloga.Napredni_Korisnik) && korisnickiNalogFilter.SadrziNadlezanZaOblasti != null)
                {
                    zaUkljucivanje.Add(korisnickiNalog => korisnickiNalog.NadlezanZaOblasti);
                }
                var korisnickiNalozi = _pomocnikServisa.PribaviSveOdKolikoSaFilterima<KorisnickiNalogEntitet>(korisnickiNalogFilter,
                                                                                                              _korisnickiNalogRepozitorijum,
                                                                                                              int.Parse(filteriZaPribavljanje.OdIndeksa),
                                                                                                              int.Parse(filteriZaPribavljanje.Koliko),
                                                                                                              propsZaPreskociti,
                                                                                                              zaUkljucivanje,
                                                                                                              null,
                                                                                                              string.IsNullOrEmpty(filteriZaPribavljanje.KriterijumSortiranja) ? null : Enum.Parse<KorisnickiNalogSortiranje>(filteriZaPribavljanje.KriterijumSortiranja),
                                                                                                              _podesavanjaSortiranjaKorisnickiNalog);

                var korisnickiNaloziDTO = _mapper.Map<IEnumerable<KorisnickiNalogEntitet>, IEnumerable<KorisnickiNalogDTO>>(korisnickiNalozi);
                return new OkObjectResult(korisnickiNaloziDTO);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }

        }

        public async Task<IActionResult> AzurirajNalog(AzuriranjeNalogaDTO podaciZaAzuriranje)
        {
            try
            {
                var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviSaUslovom(korisnickiNalog => korisnickiNalog.KorisnickoIme == podaciZaAzuriranje.PostojeceKorisnickoIme,
                                                                                     new List<Expression<Func<KorisnickiNalogEntitet, object>>>() { korisnickiNalog => korisnickiNalog.NadlezanZaOblasti, korisnickiNalog => korisnickiNalog.Korisnik, korisnickiNalog => korisnickiNalog.Korisnik.OsnovniKorisnikPodaci });
                var korisnikAzuriranje = _mapper.Map<AzuriranjeNalogaDTO, KorisnikAzuriranje>(podaciZaAzuriranje);

                var propsZaPreskociti = new Dictionary<Type, string[]>()
                {
                    {typeof(KorisnickiNalogEntitet), new string[] {} },
                    {typeof(KorisnikEntitet),new string[] {"KorisnickiNalog"}},
                    {typeof(OsnovniKorisnikPodaciEntitet),new string[] {"KorisnickiNalog", "Korisnik"}}
                };
                if (podaciZaAzuriranje.Uloga != null
                    || podaciZaAzuriranje.StatusNaloga != null
                    || podaciZaAzuriranje.KorisnickoIme != null) korisnickiNalog.PoslednjaPromena = DateTime.UtcNow;
                await _pomocnikServisa.AzurirajEntitet<KorisnickiNalogEntitet, KorisnikAzuriranje>(korisnikAzuriranje,
                                                                                                   korisnickiNalog,
                                                                                                   _korisnickiNalogRepozitorijum,
                                                                                                   propsZaPreskociti);
                return new OkResult();
            }
            catch (Exception izuzetak)
            {
                return _pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public ActionResult<KorisnikPodaciDTO> PribaviPodatkeOKorisniku(KorisnickoImeDTO korisnickoIme)
        {
            try
            {
                var listeZaUkljucivanje = new Dictionary<Expression<Func<KorisnickiNalogEntitet, object>>, List<Expression<Func<object, object>>>>()
                {
                    {korisnickiNalog => korisnickiNalog.NadlezanZaOblasti, new List<Expression<Func<object, object>>>(){ nadlezanZaOblasti => (nadlezanZaOblasti as KorisnickiNalogOblastEntitet).Oblast}}
                };
                var zaUkljucivanje = new List<Expression<Func<KorisnickiNalogEntitet, object>>>() { korisnickiNalog => korisnickiNalog.Korisnik, korisnickiNalog => korisnickiNalog.Korisnik.OsnovniKorisnikPodaci, korisnickiNalog => korisnickiNalog.NadlezanZaOblasti };
                var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickoIme.KorisnickoIme, zaUkljucivanje, listeZaUkljucivanje);
                return _mapper.Map<KorisnickiNalogEntitet, KorisnikPodaciDTO>(korisnickiNalog);
            }
            catch (Exception izuzetak)
            {
                return (ActionResult)_pomocnikServisa.RukovalacGreskamaBazePodataka(izuzetak);
            }
        }

        public IActionResult ProveriStatusPrijave()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ? new OkObjectResult(_pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.Role)) : new UnauthorizedResult();
        }
    }
}