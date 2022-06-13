using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore
{
    public class OmotacPutanje : IPutanja
    {
        private bool ocekivanaVrednostPostojanja;
        private bool potrebnaValidacijaPraznihPolja;
        public string Putanja { get; set; }

        public OmotacPutanje(string putanja,
                             bool potrebnaValidacijaPraznihPolja,
                             bool ocekivanaVrednostPostojanja)
        {
            Putanja = putanja;
            this.potrebnaValidacijaPraznihPolja = potrebnaValidacijaPraznihPolja;
            this.ocekivanaVrednostPostojanja = ocekivanaVrednostPostojanja;
        }

        public bool OcekivanaVrednostPostojanjaPutanje => ocekivanaVrednostPostojanja;

        public bool PotrebnaValidacijaPraznihPoljaPutanje => potrebnaValidacijaPraznihPolja;
    }
}