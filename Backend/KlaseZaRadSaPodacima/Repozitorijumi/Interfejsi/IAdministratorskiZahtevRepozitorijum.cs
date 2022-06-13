using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi
{
    public interface IAdministratorskiZahtevRepozitorijum : IOsnovniRepozitorijum<ZahtevAdministratoruEntitet>
    {
        Task<List<ZahtevAdministratoruEntitet>> PribaviSve();
    }
}