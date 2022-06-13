using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.ModeliAzuriranja
{
    public class KorisnikSvojNalogAzuriranje : IModelAzuriranja
    {
        public string KorisnickoIme { get; set; } = null;
        public string Email { get; set; } = null;
        public string Lozinka { get; set; } = null;
    }
}