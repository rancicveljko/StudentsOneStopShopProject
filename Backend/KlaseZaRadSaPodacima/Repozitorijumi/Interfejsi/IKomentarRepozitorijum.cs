using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi
{
    public interface IKomentarRepozitorijum : IOsnovniRepozitorijum<KomentarEntitet>
    {
        Task<List<KomentarEntitet>> PribaviKomentareNaMaterijalu(string putanjaNadoblastiMaterijala, string nazivMaterijala);
    }
}