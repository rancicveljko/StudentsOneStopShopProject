using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.ModeliAzuriranja
{
    public class PremestanjeOblastiAzuriranje : IModelAzuriranja
    {
        public OblastEntitet Nadoblast { get; set; } = null;
    }
}