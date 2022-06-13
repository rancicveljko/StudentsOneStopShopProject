using System;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Filteri.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Filteri.ZahteviAdministratoru
{
    public class ZahtevAdministratoruFilter : IFilter
    {
        public KorisnickiNalogEntitet Autor { get; set; } = null;
        public KorisnickiNalogEntitet Subjekat { get; set; } = null;
        public TipAdministratorskogZahteva? Tip { get; set; } = null;
        public DateTime? OdVremeVremeSlanja { get; set; } = null;
        public DateTime? DoVremeVremeSlanja { get; set; } = null;
    }
}