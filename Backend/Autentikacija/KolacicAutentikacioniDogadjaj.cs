using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Backend.Autentikacija
{
    public class KolacicAutentikacioniDogadjaj : CookieAuthenticationEvents
    {
        private readonly IKorisnickiNalogServis _korisnickiNalogServis;
        private readonly IConfiguration _konfiguracija;
        private bool izuzetak = false;

        public KolacicAutentikacioniDogadjaj(IKorisnickiNalogServis korisnickiNalogServis, IConfiguration konfiguracija)
        {
            _korisnickiNalogServis = korisnickiNalogServis;
            _konfiguracija = konfiguracija;
        }
        public override Task RedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
        {
            if (izuzetak)
            {
                var poruka = Encoding.GetEncoding("UTF-8").GetBytes(Poruke.ServerskaGreska("Neuspela konekcija sa bazom podataka! Izlogovani ste!").ToArray());
                context.Response.Body.WriteAsync(poruka, 0, poruka.Length);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            else context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var poslednjaPromena = context.Principal.Claims.FirstOrDefault(claim => claim.Type.Equals(_konfiguracija["KolacicConfig:Claims:PoslednjaPromena"]))?.Value;
            var korisnickoIme = context.Principal.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
            bool poslednjaPromenaBool;
            try
            {
                poslednjaPromenaBool = !_korisnickiNalogServis.ProveriPoslednjuPromenu(korisnickoIme, poslednjaPromena);
            }
            catch (Exception)
            {
                poslednjaPromenaBool = true;
                izuzetak = true;
            }
            if (string.IsNullOrEmpty(poslednjaPromena) || string.IsNullOrEmpty(korisnickoIme) || poslednjaPromenaBool)
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}