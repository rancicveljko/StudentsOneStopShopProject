using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore
{
    public class OmotacKorisnika : IKorisnickoIme
    {
        private bool ocekivanaVrednostPostojanja;
        private bool potrebnaValidacijaPraznihPolja;
        public OmotacKorisnika(string korisnickoIme,
                                 bool ocekivanaVrednostPostojanja,
                                 bool potrebnaValidacijaPraznihPolja)
        {
            KorisnickoIme = korisnickoIme;
            this.ocekivanaVrednostPostojanja = ocekivanaVrednostPostojanja;
            this.potrebnaValidacijaPraznihPolja = potrebnaValidacijaPraznihPolja;
        }
        public bool OcekivanaVrednostPostojanja => ocekivanaVrednostPostojanja;

        public bool PotrebnaValidacijaPraznihPolja => potrebnaValidacijaPraznihPolja;

        public string KorisnickoIme { get; set; }
    }
}