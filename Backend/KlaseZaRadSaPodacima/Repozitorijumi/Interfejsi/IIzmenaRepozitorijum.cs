using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi
{
    public interface IIzmenaRepozitorijum : IOsnovniRepozitorijum<IstorijaIzmenaEntitet>
    {
        Task<List<IstorijaIzmenaEntitet>> PribaviSve();
        Task<List<IstorijaIzmenaEntitet>> PribaviSveIzmeneBrisanja();
    }
}