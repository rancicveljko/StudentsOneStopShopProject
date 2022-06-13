using System;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora
{
    public interface IPomocnikZajednickihValidatora
    {
        bool validirajPodesavanjeValidatora(IPodesavanjaZajednickihValidatora podesavanjaZajednickihValidatora,
                                            out string poruka);
        bool validirajProveruPostojanja(IPodesavanjaZajednickihValidatora podesavanjaZajednickihValidatora, string vrednost, out string poruka);
    }
}