using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.ModeliAzuriranja
{
    public class OblastAzuriranje : IModelAzuriranja
    {
        public string Naziv { get; set; } = null;
        public bool? PotrebnoOdobrenje { get; set; } = null;
    }
}