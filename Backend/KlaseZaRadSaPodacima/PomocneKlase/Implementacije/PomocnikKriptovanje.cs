using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Microsoft.Extensions.Configuration;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije
{
    public class PomocnikKriptovanje : IPomocnikKriptovanje
    {
        private readonly IConfiguration _konfiguracija;

        public PomocnikKriptovanje(IConfiguration konfiguracija)
        {
            _konfiguracija = konfiguracija;
        }
        public string KriptujLozinku(string lozinka)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(lozinka, _konfiguracija.GetValue<int>("KriptoConfig:BrojIteracija"));
        }

        public bool VerifikujLozinku(string lozinka, string lozinkaIzBaze)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(lozinka, lozinkaIzBaze);
        }
    }
}