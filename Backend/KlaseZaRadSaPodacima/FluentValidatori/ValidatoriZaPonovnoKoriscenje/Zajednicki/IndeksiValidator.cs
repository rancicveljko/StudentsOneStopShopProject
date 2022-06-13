using System;
using System.Linq;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Indeksi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class IndeksiValidator : AbstractValidator<IIndeksi>
    {
        public IndeksiValidator(IServiceProvider serviceProvider, IPomocnikParser pomocnikParser)
        {
            string filteriPoruka = null;
            RuleFor(indeksi => indeksi).Cascade(CascadeMode.Stop)
                                       .Must(indeksi => proveraValidnostiIndeksa(indeksi, serviceProvider, pomocnikParser, out filteriPoruka))
                                       .WithMessage(indeks => filteriPoruka)
                                       .WithName("Od indeksa & koliko");
        }
        private bool proveraValidnostiIndeksa(IIndeksi indeksi, IServiceProvider serviceProvider, IPomocnikParser pomocnikParser, out string filteriPoruka)
        {
            filteriPoruka = Poruke.softverskaGreska;
            if (!indeksi.Repozitorijum.GetInterfaces()
                                      .Any(interfejs => interfejs.IsGenericType
                                          && interfejs.GetGenericTypeDefinition() == typeof(IOsnovniRepozitorijum<>))) return false;
            var repozitorijum = serviceProvider.GetService(indeksi.Repozitorijum);
            object brojRedova;
            if (repozitorijum != null
                && (brojRedova = repozitorijum.GetType().GetMethod("BrojRedova").Invoke(repozitorijum, null)) != null)
            {
                return proveraValidnostiIndeksaPomocnik(indeksi, pomocnikParser, (int)brojRedova, out filteriPoruka);
            }
            return false;
        }

        private bool proveraValidnostiIndeksaPomocnik(IIndeksi indeksi,
                                                      IPomocnikParser pomocnikParser,
                                                      int brojRedova,
                                                      out string filteriPoruka)
        {
            filteriPoruka = null;
            int? odIndeksa = pomocnikParser.ParsiranjeIntIzStringa(indeksi.OdIndeksa);
            if (odIndeksa == null) filteriPoruka = Poruke.PotrebnoProsleditiSaUslovom("Od indeksa", "i sme da sadrži samo cifre");
            int? koliko = pomocnikParser.ParsiranjeIntIzStringa(indeksi.Koliko);
            if (koliko == null) filteriPoruka = Poruke.PotrebnoProsleditiSaUslovom("Koliko", "i sme da sadrži samo cifre");
            if ((odIndeksa < 1
                || odIndeksa >= brojRedova) && brojRedova > 0) filteriPoruka = Poruke.Mora("Od indeksa", $"biti veći broj od nule, a manji ili jednak broju postojećih {indeksi.parametarPorukeValidacijeIndeksa}: {brojRedova}");
            if (koliko < 0) filteriPoruka = Poruke.Mora("Koliko", "biti pozitivan broj!");
            return filteriPoruka == null;
        }
    }
}