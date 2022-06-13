using Backend.KlaseZaRadSaPodacima.Filteri.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Filteri.Oblasti
{
    public class OblastInfoFilter : IFilter
    {
        public string Putanja { get; set; } = null;
        public string Naziv { get; set; } = null;
        public bool? PotrebnoOdobrenje { get; set; } = null;
    }
}