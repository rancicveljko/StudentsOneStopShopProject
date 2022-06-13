using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using tusdotnet.Models.Configuration;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Materijal
{
    public class TekstIVremeSlanjaZahtevaValidator : AbstractValidator<MaterijalDTO>
    {
        public BeforeCreateContext Context { get; set; } = null;
        public TekstIVremeSlanjaZahtevaValidator(TekstValidator tekstValidator,
                                                 VremeSlanjaValidator vremeSlanjaValidator,
                                                 IPomocnikManuelniValidator pomocnikManuelniValidator,
                                                 IPomocnikParser pomocnikParser,
                                                 IPomocnikKolacic pomocnikKolacic,
                                                 IOblastRepozitorijum oblastRepozitorijum,
                                                 IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                                 IConfiguration konfiguracija)
        {
            //string poruka = null;
            RuleFor(materijal => materijal).Cascade(CascadeMode.Stop)
                                           .SetValidator(tekstValidator)
                                           //.Must(materijal => pomocnikManuelniValidator.manuelnoValidiraj(tekstValidator, materijal, out poruka))
                                           //.WithMessage(materijal => poruka)
                                           .WithName(konfiguracija["TusConfig:TusObavezniMetadata:TekstZahteva"])
                                           .DependentRules(() =>
                                           {
                                               Include(vremeSlanjaValidator);
                                           })
                                           .When(materijal => PotrebnaValidacijaTekstaIVremenaSlanjaZahteva(materijal,
                                                                                                            pomocnikKolacic,
                                                                                                            korisnickiNalogRepozitorijum,
                                                                                                            oblastRepozitorijum,
                                                                                                            pomocnikParser));
        }
        private bool PotrebnaValidacijaTekstaIVremenaSlanjaZahteva(MaterijalDTO materijal,
                                                                   IPomocnikKolacic pomocnikKolacic,
                                                                   IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                                                   IOblastRepozitorijum oblastRepozitorijum,
                                                                   IPomocnikParser pomocnikParser)
        {
            var korisnickoIme = pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier);

            var zaUgnjezdenoUkljucivanje = new Dictionary<Expression<Func<KorisnickiNalogEntitet, object>>, List<Expression<Func<object, object>>>>()
                              {
                                   {korisnickiNalog => korisnickiNalog.NadlezanZaOblasti, new List<Expression<Func<object, object>>>() {korisnikOblast => (korisnikOblast as KorisnickiNalogOblastEntitet).Oblast}}
                              };
            var zaUkljucivanje = new List<Expression<Func<KorisnickiNalogEntitet, object>>>() { korisnickiNalog => korisnickiNalog.Korisnik, korisnickiNalog => korisnickiNalog.Korisnik.OsnovniKorisnikPodaci };

            var korisnickiNalog = korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickoIme, zaUkljucivanje, zaUgnjezdenoUkljucivanje);

            var tipZahteva = pomocnikParser.ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(materijal.TipZahteva);

            if (tipZahteva == null) return false;

            if (korisnickiNalog.Uloga == Uloga.Administrator) return false;

            if (korisnickiNalog.Uloga == Uloga.Napredni_Korisnik)
            {
                bool nadlezanZaOblast = korisnickiNalog.NadlezanZaOblasti.SelectMany(korisnickiNalogOblast => korisnickiNalogOblast.Oblast.Putanja)
                                                                         .Any(putanjaOblasti => putanjaOblasti.Equals(materijal.Putanja));
                if (!nadlezanZaOblast)
                {
                    materijal.PotrebnoSlanjeZahteva = ProveriPotrebuOdobrenja(materijal.Putanja, oblastRepozitorijum);
                    if (materijal.PotrebnoSlanjeZahteva) materijal.status = OdrediStatusMaterijala(tipZahteva);
                    return true;
                }
                return false;
            }

            if (korisnickiNalog.Uloga == Uloga.Osnovni_Korisnik)
            {
                if (korisnickiNalog.Korisnik.OsnovniKorisnikPodaci.Privilegije.HasFlag(OsnovniKorisnikPrivilegije.Zabrana_Dodavanja_Materijala))
                {
                    if (Context == null) throw new Exception(Poruke.PotrebnoProslediti("Kontekst"));
                    Context.FailRequest(HttpStatusCode.Forbidden, Poruke.KorisnikPosedujeZabranu("dodavanja materijala"));
                    return false;
                }
                materijal.PotrebnoSlanjeZahteva = ProveriPotrebuOdobrenja(materijal.Putanja, oblastRepozitorijum);
                if (materijal.PotrebnoSlanjeZahteva) materijal.status = OdrediStatusMaterijala(tipZahteva);
            }
            Context.FailRequest(HttpStatusCode.Unauthorized, Poruke.poterebnoSePrijaviti);
            return false;
        }
        private bool ProveriPotrebuOdobrenja(string putanja,
                                             IOblastRepozitorijum oblastRepozitorijum)
        {
            var oblast = oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja.Equals(putanja));
            return oblast.PotrebnoOdobrenje;
        }
        private StatusMaterijala OdrediStatusMaterijala(TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? tipZahteva)
        {
            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala) return StatusMaterijala.Ceka_Potvrdu_Dodavanja;
            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala) return StatusMaterijala.Dostupan_I_Ceka_Potvrdu_Azuriranja;
            return StatusMaterijala.Dostupan;
        }
    }
}

