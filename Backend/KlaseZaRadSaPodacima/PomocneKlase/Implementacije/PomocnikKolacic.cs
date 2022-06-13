using System.Linq;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Microsoft.AspNetCore.Http;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije
{
    public class PomocnikKolacic : IPomocnikKolacic
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PomocnikKolacic(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string IzvadiClaimIzKolacica(string claimTip)
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type.Equals(claimTip))?.Value;
        }
    }
}