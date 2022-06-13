using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi
{
    public interface IOblastRepozitorijum : IOsnovniRepozitorijum<OblastEntitet>
    {
        OblastEntitet PribaviPoIDSaUkljucenim(string putanja, bool ukljuciMaterijaleIPodoblasti = false);
        Task AzurirajPutanjuZaOblastiKojeSadrzePutanju(string putanja, string novaPutanja, bool sacuvaj = true);
        string PribaviAdresuPocetnogFoldera();
    }
}