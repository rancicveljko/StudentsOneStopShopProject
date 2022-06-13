using System;
using System.Linq;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora
{
    public class PomocnikZajednickihValidatora : IPomocnikZajednickihValidatora
    {
        public bool validirajPodesavanjeValidatora(IPodesavanjaZajednickihValidatora podesavanjaZajednickihValidatora,
                                                   out string poruka)
        {
            poruka = Poruke.softverskaGreska;
            var naziviZaProveruPostojanja = new string[] { "Pomocnik", "OcekivanaVrednostPostojanja", "NazivUPorukamaProverePostojanja", "PodesavanjaValidatoraParametara" };
            var props = podesavanjaZajednickihValidatora.GetType()
                                                        .GetProperties()
                                                        .Where(prop => !naziviZaProveruPostojanja.Contains(prop.Name)
                                                        && !prop.Name.Equals("PotrebnoValidiranjePrazogPolja")
                                                        && !prop.Name.Equals("PorukaZaPraznoPolje"));
            foreach (var prop in props)
            {
                if (prop.GetValue(podesavanjaZajednickihValidatora) == null) return false;
            }
            var tipProverePostojanja = PribaviVrednostPropertija(podesavanjaZajednickihValidatora, "TipProverePostojanja");
            var potrebnaValidacijaPraznihPolja = PribaviVrednostPropertija(podesavanjaZajednickihValidatora, "PotrebnoValidiranjePrazogPolja");
            if (!tipProverePostojanja.GetType().Equals(typeof(NeProveravajPostojanje))
                || (NeProveravajPostojanje)tipProverePostojanja != NeProveravajPostojanje.Ne_Proveravaj_Postojanje)
            {
                foreach (var naziv in naziviZaProveruPostojanja)
                {
                    if (PribaviVrednostPropertija(podesavanjaZajednickihValidatora, naziv) == null) return false;
                }
            }
            if ((bool)potrebnaValidacijaPraznihPolja == true)
            {
                if (PribaviVrednostPropertija(podesavanjaZajednickihValidatora, "PorukaZaPraznoPolje") == null) return false;
            }
            return true;
        }

        public bool validirajProveruPostojanja(IPodesavanjaZajednickihValidatora podesavanjaZajednickihValidatora,
                                               string vrednost,
                                               out string poruka)
        {
            poruka = null;
            if (podesavanjaZajednickihValidatora.TipProverePostojanja.Equals(NeProveravajPostojanje.Ne_Proveravaj_Postojanje)
                || string.IsNullOrEmpty(vrednost)) return true;
            return podesavanjaZajednickihValidatora.Pomocnik.entitetSaNavedinimParametromVecPostoji(podesavanjaZajednickihValidatora.TipProverePostojanja,
                                                                                                    vrednost,
                                                                                                    podesavanjaZajednickihValidatora.PodesavanjaValidatoraParametara,
                                                                                                    podesavanjaZajednickihValidatora.NazivUPorukamaProverePostojanja,
                                                                                                    (bool)podesavanjaZajednickihValidatora.OcekivanaVrednostPostojanja,
                                                                                                    out poruka);
        }

        private object PribaviVrednostPropertija(IPodesavanjaZajednickihValidatora podesavanjaZajednickihValidatora, string naziv)
        {
            return podesavanjaZajednickihValidatora.GetType()
                                                   .GetProperty(naziv)
                                                   .GetValue(podesavanjaZajednickihValidatora);
        }
    }
}