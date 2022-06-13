using System;
using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri
{
    public interface IPomocnikValidatoraParametara
    {
        bool entitetSaNavedinimParametromVecPostoji(Enum tip,
                                                    string vrednost,
                                                    IPodesavanjaValidatoraParametara podesavanjaValidatoraParametara,
                                                    string nazivUPorukama,
                                                    bool ocekivanaVrednostPostojanja,
                                                    out string poruka);

    }
}