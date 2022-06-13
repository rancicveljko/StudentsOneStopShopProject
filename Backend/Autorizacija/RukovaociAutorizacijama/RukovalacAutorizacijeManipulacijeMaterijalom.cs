using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Autorizacija.UsloviAutorizacije;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Backend.Autorizacija.RukovaociAutorizacijama
{
    public class RukovalacAutorizacijeManipulacijeMaterijalom : AuthorizationHandler<UslovManipulacijeMaterijalom>
    {
        private readonly IPomocnikKolacic _pomocnikKolacic;
        // private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;

        public RukovalacAutorizacijeManipulacijeMaterijalom(IPomocnikKolacic pomocnikKolacic
                                                            /*IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum*/)
        {
            _pomocnikKolacic = pomocnikKolacic;
            // _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UslovManipulacijeMaterijalom requirement)
        {
            /*   var korisnickoIme = _pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier);
               if (context.User.IsInRole(Uloga.Administrator.ToString())) context.Succeed(requirement);
               else if (context.User.IsInRole(Uloga.Napredni_Korisnik.ToString()))
               {
                   var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickoIme, new List<Expression<Func<KlaseZaRadSaPodacima.Entiteti.KorisnickiNalogEntitet, object>>>() {korisnickiNalog => korisnickiNalog.NadlezanZaOblasti });
               }
               else if (context.User.IsInRole(Uloga.Osnovni_Korisnik.ToString()))
               {

               }
               else context.Fail();*/
            return Task.CompletedTask;
        }
    }
}