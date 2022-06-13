using System;
using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class OblastEntitet : IEntitet
    {
        public Guid ID { get; set; }
        public string Putanja { get; set; }
        public string Naziv { get; set; }
        public bool PotrebnoOdobrenje { get; set; }
        public ICollection<MaterijalEntitet> Materijali { get; set; }
        public OblastEntitet Nadoblast { get; set; }
        public ICollection<OblastEntitet> Podoblasti { get; set; }
        public IList<KorisnickiNalogOblastEntitet> NadlezniKorisnici { get; set; }
    }
}