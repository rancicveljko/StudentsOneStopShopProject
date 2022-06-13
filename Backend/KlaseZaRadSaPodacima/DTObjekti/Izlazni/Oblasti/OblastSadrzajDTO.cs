using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti
{
    public class OblastSadrzajDTO
    {
        public ICollection<string> Materijali { get; set; }
        public ICollection<string> Podoblasti { get; set; }
    }
}