using System.Security.Claims;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Komentari
{
    public class BrisanjeSvogKomentaraValidator : AbstractValidator<BrisanjeSvogKomentaraDTO>
    {
        public BrisanjeSvogKomentaraValidator(IPomocnikValidatoraPutanje pomocnikValidatoraPutanje,
                                              VremeSlanjaValidator vremeSlanjaValidator,
                                              PutanjaNazivIEkstenzijaValidator putanjaNazivIEkstenzijaMaterijalaValidator,
                                              IPomocnikValidatoraParametara pomockValidatoraParametara,
                                              IPodesavanjaValidatoraParametaraKomentara podesavanjaValidatoraParametaraKomentara,
                                              IPomocnikKolacic pomocnikKolacic)
        {
            Include(vremeSlanjaValidator);
            string poruka = null;
            RuleFor(komentarZaBrisanje => komentarZaBrisanje).Must(komentarZaBrisanje => pomocnikValidatoraPutanje.DopuniPutanju(komentarZaBrisanje,
                                                                                                                                 true,
                                                                                                                                 false,
                                                                                                                                 out string poruka))
                                                             .SetValidator(putanjaNazivIEkstenzijaMaterijalaValidator)
                                                             .DependentRules(() =>
                                                             {
                                                                 RuleFor(komentarZaBrisanje => komentarZaBrisanje).Must(komentarZaBrisanje => pomockValidatoraParametara.entitetSaNavedinimParametromVecPostoji(TipProverePostojanjaKomentara.Korisnicko_Ime_Autora_Iz_Kolacica,
                                                                                                                                                                                                                pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier),
                                                                                                                                                                                                                podesavanjaValidatoraParametaraKomentara,
                                                                                                                                                                                                                "Nijedan komentar",
                                                                                                                                                                                                                true,
                                                                                                                                                                                                                out poruka))
                                                                                                                  .WithMessage(komentarZaBrisanje => poruka)
                                                                                                                  .WithName("KorisnickoIme");
                                                             });
        }
    }
}