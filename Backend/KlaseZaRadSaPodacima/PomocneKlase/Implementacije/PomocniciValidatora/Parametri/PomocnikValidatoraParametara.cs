using System;
using System.Collections.Generic;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri
{
    public class PomocnikValidatoraParametara : IPomocnikValidatoraParametara
    {
        public bool entitetSaNavedinimParametromVecPostoji(Enum tip,
                                                           string vrednost,
                                                           IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                                           string nazivUPorukama,
                                                           bool ocekivanaVrednostPostojanja,
                                                           out string poruka)
        {
            try
            {
                poruka = Poruke.softverskaGreska;
                bool postojiEntitetSaParametrom = !ocekivanaVrednostPostojanja;
                foreach (var item in podesavanjaValidatoraParametara.kolekcijaPodesavanja)
                {
                    if (item.Key.Equals(tip))
                    {
                        postojiEntitetSaParametrom = item.Value.FunkcijaProvere(vrednost);
                        if (ocekivanaVrednostPostojanja != postojiEntitetSaParametrom)
                        {
                            if (item.Key.Equals(TipProverePostojanjaKorisnika.Lozinka)
                                || item.Key.Equals(TipProverePostojanjaKorisnika.Nova_Lozinka))
                            {
                                if (!ocekivanaVrednostPostojanja) poruka = "Nova lozinka ne sme biti identična staroj!";
                                else poruka = Poruke.pogresnaLozinka;
                            }
                            else
                            {
                                if (!ocekivanaVrednostPostojanja) poruka = Poruke.VecPostoji(nazivUPorukama, item.Value.ParametarPorukaPostojanja);
                                else poruka = Poruke.NePostoji(nazivUPorukama, item.Value.ParametarPorukaPostojanja);
                            }
                        }
                    }
                }
                return postojiEntitetSaParametrom == ocekivanaVrednostPostojanja;
            }
            catch (Exception)
            {
                poruka = Poruke.softverskaGreska;
                foreach (var item in podesavanjaValidatoraParametara.kolekcijaPodesavanja)
                {
                    if (item.Key.Equals(tip))
                    {
                        poruka = Poruke.ServerskaGreska($"Neuspela validacija {item.Value.ParametarPorukaIzuzetka} u bazi podataka!");
                    }
                }
                return !ocekivanaVrednostPostojanja;
            }
        }
    }
}