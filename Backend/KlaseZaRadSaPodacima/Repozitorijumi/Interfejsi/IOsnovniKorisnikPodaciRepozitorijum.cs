using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi
{
    public interface IOsnovniKorisnikPodaciRepozitorijum : IOsnovniRepozitorijum<OsnovniKorisnikPodaciEntitet>
    {
        OsnovniKorisnikPodaciEntitet PribaviPoKorisnikID(int ID);
    }
}