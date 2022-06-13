using System;
using System.Collections.Generic;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class KomentarEntitet : AutorMaterijalKompozitniKljucEntitet
    {
        public DateTime VremeKomentarisanja { get; set; }
        public string Tekst { get; set; }
        public KomentarEntitet OdgovorNa { get; set; }
        public ICollection<KomentarEntitet> Odgovori { get; set; }

        public override string ToString()
        {
            return VremeKomentarisanja.ToString() + AutorID.ToString() + MaterijalID.ToString();
        }
    }
}