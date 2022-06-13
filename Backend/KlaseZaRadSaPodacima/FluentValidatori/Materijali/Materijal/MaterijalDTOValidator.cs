using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Calabonga.PredicatesBuilder;
using FluentValidation;
using tusdotnet.Models.Configuration;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Materijal
{
    public class MaterijalDTOValidator : AbstractValidator<MaterijalDTO>
    {
        public BeforeCreateContext Context { get; set; }
        public MaterijalDTOValidator(PutanjaNazivIEkstenzijaValidator putanjaNazivIEkstenzijaValidator,
                                     TipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator tipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator,
                                     IPomocnikManuelniValidator pomocnikManuelniValidator,
                                     IPomocnikKolacic pomocnikKolacic,
                                     IPomocnikParser pomocnikParser,
                                     IMaterijalRepozitorijum materijalRepozitorijum,
                                     IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                     IPomocnikValidatoraPutanje pomocnikValidatoraPutanje)
        {
            string poruka = null;
            RuleFor(materijal => materijal).Cascade(CascadeMode.Stop)
                                           .Must(materijal => pomocnikValidatoraPutanje.DopuniPutanju(materijal, true, false, out poruka))
                                           .SetValidator(tipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator)
                                           //.Must(materijal => pomocnikManuelniValidator.manuelnoValidiraj<ITipZahtevaZaDodavanjeIliAzuriranjeMaterijala>(tipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator, materijal, out poruka))
                                           // .WithMessage(materijal => poruka)
                                           .Must(materijal => ProveriTipZahteva(materijal.TipZahteva))
                                           .WithMessage(materijal => Poruke.EnumUValidnomOpsegu("Tip zahteva"))
                                           .WithName("TipZahteva")
                                           .DependentRules(() =>
                                           {
                                               Include(putanjaNazivIEkstenzijaValidator);
                                           });
            RuleFor(materijal => materijal).Must(materijal => ProveriStatusMaterijala(materijal,
                                                                                      materijalRepozitorijum,
                                                                                      pomocnikKolacic,
                                                                                      korisnickiNalogRepozitorijum,
                                                                                      pomocnikParser));
        }
        private bool ProveriTipZahteva(string tipZahteva)
        {
            var tipZahtevaEnum = Enum.Parse<TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>(tipZahteva);
            return tipZahtevaEnum != TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Ili_Azuriranje_Sa_Greskom_Antivirusa
                   && tipZahtevaEnum != TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Ili_Azuriranje_Sa_Nepoznatim_Statusom_Skeniranja_Na_Viruse;
        }
        private bool ProveriStatusMaterijala(MaterijalDTO materijalZaObradu,
                                             IMaterijalRepozitorijum materijalRepozitorijum,
                                             IPomocnikKolacic pomocnikKolacic,
                                             IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum,
                                             IPomocnikParser pomocnikParser)
        {
            var tipZahteva = pomocnikParser.ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(materijalZaObradu.TipZahteva);
            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala)
            {
                var korisnickoIme = pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier);

                var korisnickiNalog = korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickoIme);

                var izraz = PredicateBuilder.False<MaterijalEntitet>()
                                            .Or<MaterijalEntitet>(materijal => materijal.Status == StatusMaterijala.Dostupan)
                                            .Or<MaterijalEntitet>(materijal => materijal.Status == StatusMaterijala.Dostupan_I_Ceka_Potvrdu_Azuriranja);

                if (korisnickiNalog.Uloga != Uloga.Osnovni_Korisnik) izraz = izraz.Or<MaterijalEntitet>(materijal => materijal.Status == StatusMaterijala.Sakriven);

                izraz = izraz.And<MaterijalEntitet>(materijal => materijal.Nadoblast.Putanja.Equals(materijalZaObradu.Putanja))
                             .And<MaterijalEntitet>(materijal => materijal.Naziv.Equals(materijalZaObradu.Naziv))
                             .And<MaterijalEntitet>(materijal => materijal.Ekstenzija.Equals(materijalZaObradu.Ekstenzija));

                var rezultatProvereStatusa = materijalRepozitorijum.PostojiEntitetSaUslovom(izraz.Compile(), new List<Expression<Func<MaterijalEntitet, object>>>() { materijal => materijal.Nadoblast });

                if (!rezultatProvereStatusa)
                {
                    if (Context == null) throw new Exception(Poruke.PotrebnoProslediti("Kontekst"));
                    Context.FailRequest(HttpStatusCode.Forbidden, Poruke.KorisnikPosedujeZabranu("ažuriranja materijala sa ovim statusom"));
                    return true;
                }

                return rezultatProvereStatusa;
            }
            return true;
        }
    }
}
