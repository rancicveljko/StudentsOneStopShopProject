
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Microsoft.Extensions.Configuration;
using tusdotnet.Models;
using tusdotnet.Models.Configuration;
using tusdotnet.Stores;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using tusdotnet.Models.Expiration;
using nClam;
using tusdotnet.Interfaces;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Materijal;
using FluentValidation.Results;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.TusKonfiguracije
{
    public class TusKonfiguracija : DefaultTusConfiguration
    {
        public TusKonfiguracija(IConfiguration konfiguracija,
                                IServiceScopeFactory servisScopeFabrika)
        {
            MaterijalDTO materijalZaObradu = null;
            TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? tipZahteva = null;

            UrlPath = konfiguracija["TusConfig:TusUrlPath"];
            Store = new TusDiskStore(konfiguracija["TusConfig:TusDiskStore"], true);
            Expiration = new SlidingExpiration(TimeSpan.FromMinutes(konfiguracija.GetValue<int>("TusConfig:TusExpirationTime")));
            Events = new Events
            {
                OnAuthorizeAsync = async context =>
                {
                    if (!context.HttpContext.User.Identity.IsAuthenticated) context.FailRequest(HttpStatusCode.Unauthorized, Poruke.poterebnoSePrijaviti);
                    await Task.CompletedTask;
                },
                OnBeforeCreateAsync = context =>
                {
                    try
                    {
                        var tusMetadata = konfiguracija.GetSection("TusConfig:TusObavezniMetadata").Get<Dictionary<string, string>>();

                        using (var scope = servisScopeFabrika.CreateScope())
                        {
                            var korisnickiNalogRepozitorijum = scope.ServiceProvider.GetService<IKorisnickiNalogRepozitorijum>();
                            var oblastRepozitorijum = scope.ServiceProvider.GetService<IOblastRepozitorijum>();
                            var materijalValidator = scope.ServiceProvider.GetService<MaterijalDTOValidator>();
                            var pomocnikParser = scope.ServiceProvider.GetService<IPomocnikParser>();
                            var mapper = scope.ServiceProvider.GetService<IMapper>();
                            var tekstZahtevaValidator = scope.ServiceProvider.GetService<TekstIVremeSlanjaZahtevaValidator>();

                            materijalZaObradu = new MaterijalDTO(konfiguracija, context.Metadata);

                            materijalValidator.Context = context;
                            ValidationResult rezultatValidacije = materijalValidator.Validate(materijalZaObradu);

                            if (!ObradiRezultatValidacije(context, rezultatValidacije)) return Task.CompletedTask;

                            tekstZahtevaValidator.Context = context;
                            rezultatValidacije = tekstZahtevaValidator.Validate(materijalZaObradu);

                            if (!ObradiRezultatValidacije(context, rezultatValidacije)) return Task.CompletedTask;

                            tipZahteva = pomocnikParser.ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(materijalZaObradu.TipZahteva);

                            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala)
                            {
                                materijalZaObradu = mapper.Map<MaterijalDTO, DodavanjeMaterijalaDTO>(materijalZaObradu);

                                var dodavanjeMaterijalaValidator = scope.ServiceProvider.GetService<DodavanjeMaterijalaDTOValidator>();

                                (materijalZaObradu as DodavanjeMaterijalaDTO).SetKratakOpis(konfiguracija, context.Metadata);

                                rezultatValidacije = dodavanjeMaterijalaValidator.Validate(materijalZaObradu as DodavanjeMaterijalaDTO);
                                if (!ObradiRezultatValidacije(context, rezultatValidacije)) return Task.CompletedTask;
                            }
                            else if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala)
                            {
                                materijalZaObradu = mapper.Map<MaterijalDTO, AzuriranjeMaterijalaDTO>(materijalZaObradu);
                                var azuriranjeMaterijalaValidator = scope.ServiceProvider.GetService<AzuriranjeMaterijalaDTOValidator>();

                                (materijalZaObradu as AzuriranjeMaterijalaDTO).SetNovaEkstenzija(konfiguracija, context.Metadata);

                                rezultatValidacije = azuriranjeMaterijalaValidator.Validate(materijalZaObradu as AzuriranjeMaterijalaDTO);

                                if (!ObradiRezultatValidacije(context, rezultatValidacije)) return Task.CompletedTask;
                            }
                            return Task.CompletedTask;
                        }
                    }
                    catch (Exception izuzetak)
                    {
                        Console.WriteLine(izuzetak);
                        if (izuzetak.Equals(Poruke.PotrebnoProslediti("Kontekst"))) context.FailRequest(HttpStatusCode.InternalServerError, Poruke.softverskaGreska);
                        else context.FailRequest(HttpStatusCode.InternalServerError, Poruke.serverskaGreska);
                        return Task.CompletedTask;
                    }
                },
                OnCreateCompleteAsync = async context =>
                {
                    var statusParsiranja = Guid.TryParse(context.FileId, out Guid idNaFajlSistemu);
                    if (statusParsiranja) materijalZaObradu.IDNaFajlSistemu = idNaFajlSistemu;
                    else await (Store as TusDiskStore).DeleteFileAsync(context.FileId, context.CancellationToken);
                },
                OnFileCompleteAsync = async context =>
                {
                    ITusFile fajl = await context.GetFileAsync();
                    using (var fajlStream = await fajl.GetContentAsync(context.CancellationToken))
                    {
                        using (var scope = servisScopeFabrika.CreateScope())
                        {
                            var materijalRepozitorijum = scope.ServiceProvider.GetService<IMaterijalRepozitorijum>();
                            var zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum = scope.ServiceProvider.GetService<IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum>();
                            var mapper = scope.ServiceProvider.GetService<IMapper>();
                            var izmenaRepozitorijum = scope.ServiceProvider.GetService<IIzmenaRepozitorijum>();

                            try
                            {
                                var clam = new ClamClient(konfiguracija["ClamAVServer:URL"],
                                                          konfiguracija.GetValue<int>("ClamAVServer:Port"));

                                var rezultatSkeniranja = await clam.SendAndScanFileAsync(fajlStream);
                                switch (rezultatSkeniranja.Result)
                                {
                                    case ClamScanResults.Clean:
                                        await ObradiMaterijal(mapper,
                                                              materijalZaObradu,
                                                              (TipZahtevaZaDodavanjeIliAzuriranjeMaterijala)tipZahteva,
                                                              zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                                                              materijalRepozitorijum,
                                                              izmenaRepozitorijum);
                                        break;
                                    case ClamScanResults.VirusDetected:
                                        {
                                            var pomocnikKolacic = scope.ServiceProvider.GetService<IPomocnikKolacic>();
                                            var korisnickiNalogRepozitorijum = scope.ServiceProvider.GetService<IKorisnickiNalogRepozitorijum>();

                                            fajlStream.Close();
                                            var brisanjeFajla = (Store as TusDiskStore).DeleteFileAsync(context.FileId, context.CancellationToken);

                                            var korisnickoIme = pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier);
                                            var korisnickiNalog = korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickoIme);

                                            korisnickiNalog.StatusNaloga = StatusKorisnickogNaloga.Blokiran;

                                            var azuriranjeNaloga = korisnickiNalogRepozitorijum.Azuriraj(korisnickiNalog);

                                            Task.WaitAll(brisanjeFajla, azuriranjeNaloga);
                                        }
                                        break;
                                    case ClamScanResults.Unknown:
                                        await ObradiMaterijal(mapper,
                                                              materijalZaObradu,
                                                              (TipZahtevaZaDodavanjeIliAzuriranjeMaterijala)tipZahteva,
                                                              zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                                                              materijalRepozitorijum,
                                                              izmenaRepozitorijum,
                                                              StatusMaterijala.Dodat_Ili_Azuriran_Sa_Nepoznatim_Statusom_Skeniranja_Na_Viruse,
                                                              TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Ili_Azuriranje_Sa_Nepoznatim_Statusom_Skeniranja_Na_Viruse);
                                        break;
                                    case ClamScanResults.Error:
                                        await ObradiMaterijal(mapper,
                                                              materijalZaObradu,
                                                              (TipZahtevaZaDodavanjeIliAzuriranjeMaterijala)tipZahteva,
                                                              zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                                                              materijalRepozitorijum,
                                                              izmenaRepozitorijum,
                                                              StatusMaterijala.Dodat_Ili_Azuriran_Sa_Greskom_Antivirusa,
                                                              TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Ili_Azuriranje_Sa_Greskom_Antivirusa);
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                await ObradiMaterijal(mapper,
                                                      materijalZaObradu,
                                                      (TipZahtevaZaDodavanjeIliAzuriranjeMaterijala)tipZahteva,
                                                      zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                                                      materijalRepozitorijum,
                                                      izmenaRepozitorijum,
                                                      StatusMaterijala.Dodat_Ili_Azuriran_Sa_Greskom_Antivirusa,
                                                      TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Ili_Azuriranje_Sa_Greskom_Antivirusa);
                            }
                        }
                    }
                    await Task.CompletedTask;
                },
                OnBeforeDeleteAsync = async context =>
                {
                    context.FailRequest(HttpStatusCode.BadRequest);
                    await Task.CompletedTask;
                }
            };
        }
        private bool ObradiRezultatValidacije(BeforeCreateContext context,
                                              ValidationResult rezultatValidacije)
        {
            var greske = $"{rezultatValidacije.Errors.Select(greska => greska.PropertyName).FirstOrDefault()}:[{rezultatValidacije.Errors.Select(greska => greska.ErrorMessage).FirstOrDefault()}]";

            if (!rezultatValidacije.IsValid)
            {
                context.FailRequest(HttpStatusCode.BadRequest, greske);
                return false;
            }
            return true;
        }
        private async Task ObradiMaterijal(IMapper mapper,
                                           MaterijalDTO materijalZaObradu,
                                           TipZahtevaZaDodavanjeIliAzuriranjeMaterijala tipZahteva,
                                           IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum,
                                           IMaterijalRepozitorijum materijalRepozitorijum,
                                           IIzmenaRepozitorijum izmenaRepozitorijum,
                                           StatusMaterijala? statusMaterijala = null,
                                           TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? noviTipZahteva = null)
        {
            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala)
            {
                if (materijalZaObradu.PotrebnoSlanjeZahteva)
                {
                    var zahtevZaDodavanjeIliAzuriranjeMaterijala = mapper.Map<MaterijalDTO, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>(materijalZaObradu as DodavanjeMaterijalaDTO);
                    await zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.Dodaj(ModifikujZahtev(zahtevZaDodavanjeIliAzuriranjeMaterijala,
                                                                                                      statusMaterijala,
                                                                                                      tipZahteva));
                }
                else
                {
                    var izmenaEntitet = mapper.Map<MaterijalDTO, IstorijaIzmenaEntitet>(materijalZaObradu);
                    await izmenaRepozitorijum.Dodaj(ModifikujIzmenu(izmenaEntitet,
                                                                    statusMaterijala));
                }
            }
            else if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala)
            {
                if (materijalZaObradu.PotrebnoSlanjeZahteva)
                {
                    var zahtevZaDodavanjeIliAzuriranjeMaterijala = mapper.Map<MaterijalDTO, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>(materijalZaObradu as AzuriranjeMaterijalaDTO);
                    await zahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum.Dodaj(ModifikujZahtev(zahtevZaDodavanjeIliAzuriranjeMaterijala,
                                                                                                      statusMaterijala,
                                                                                                      tipZahteva));
                }
                else
                {
                    var izmenaEntitet = mapper.Map<MaterijalDTO, IstorijaIzmenaEntitet>(materijalZaObradu);

                    await izmenaRepozitorijum.Dodaj(ModifikujIzmenu(izmenaEntitet,
                                                                    statusMaterijala));
                }
            }
        }
        private ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet ModifikujZahtev(ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet zahtevZaObradu,
                                                                                StatusMaterijala? statusMaterijala,
                                                                                TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? noviTipZahteva)
        {
            if (statusMaterijala != null) zahtevZaObradu.Materijal.Status = (StatusMaterijala)statusMaterijala;
            if (noviTipZahteva != null) zahtevZaObradu.TipZahteva = ((TipZahtevaZaDodavanjeIliAzuriranjeMaterijala)noviTipZahteva);
            return zahtevZaObradu;
        }
        private IstorijaIzmenaEntitet ModifikujIzmenu(IstorijaIzmenaEntitet izmenaZaObradu,
                                                      StatusMaterijala? statusMaterijala)
        {
            if (statusMaterijala != null) izmenaZaObradu.Materijal.Status = (StatusMaterijala)statusMaterijala;
            return izmenaZaObradu;
        }
    }
}