using System;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Filteri.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Filteri.Materijali
{
    public class KomentariFilter : IFilter
    {
        public MaterijalEntitet Materijal { get; set; } = null;
        public KorisnickiNalogEntitet Autor { get; set; } = null;
        public DateTime? OdVremeVremeKomentarisanja { get; set; } = null;
        public DateTime? DoVremeVremeKomentarisanja { get; set; } = null;
        public KomentarEntitet NullOdgovorNa { get; set; } = null;
    }
}