using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.ProsirenjaMetoda;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.EntitetUEntitet
{
    public class ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitetUIstorijaIzmenaEntitetKonverter : ITypeConverter<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, IstorijaIzmenaEntitet>
    {
        public IstorijaIzmenaEntitet Convert(ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet izvor, IstorijaIzmenaEntitet destinacija, ResolutionContext context)
        {
            TipIzmene tipIzmene = default;
            if (izvor.TipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala) tipIzmene = TipIzmene.Dodavanje_Materijala;
            else if (izvor.TipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala) tipIzmene = TipIzmene.Azuriranje_Materijala;

            return destinacija = new IstorijaIzmenaEntitet(DateTime.UtcNow.SkratiMilisekunde(), tipIzmene, izvor.Autor, izvor.Materijal);
        }
    }
}