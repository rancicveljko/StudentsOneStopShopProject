using System;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Filteri.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Filteri.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class ZahtevZaDodavanjeIliAzuriranjeMaterijalaFilter : IFilter
    {
        public string Putanja { get; set; } = null;
        public string Naziv { get; set; } = null;
        public string Ekstenzija { get; set; } = null;
        public KorisnickiNalogEntitet Autor { get; set; } = null;
        public TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? TipZahteva { get; set; } = null;
        public DateTime? OdVremeVremeSlanja { get; set; } = null;
        public DateTime? DoVremeVremeSlanja { get; set; } = null;
    }
}