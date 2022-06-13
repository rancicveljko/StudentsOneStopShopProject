using System.Collections.Generic;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.Servisi.Enumeracije;
using Backend.Servisi.Interfejsi;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori
{
    public class ZahtevAdministratoruDTOValidator : AbstractValidator<ZahtevAdministratoruDTO>
    {
        public ZahtevAdministratoruDTOValidator(IPomocnikParser pomocnikParser,
                                                TipZahtevaValidator tipZahtevaValidator,
                                                VremeSlanjaValidator vremeSlanjaValidator,
                                                IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum)
        {
            Include(tipZahtevaValidator);
            Include(vremeSlanjaValidator);
            KorisnickiNalogEntitet subjekat = null;
            string poruka = null;
            RuleFor(zahtevAdministratoru => zahtevAdministratoru).Cascade(CascadeMode.Stop)
                                                                 .Must(zahtevAdministratoru => !string.IsNullOrEmpty(zahtevAdministratoru.KorisnickoImeSubjekta))
                                                                 .WithMessage(zahtevAdministratoru => Poruke.PotrebnoProslediti("Korisničko ime subjekta"))
                                                                 .Must(zahtevAdministratoru => (subjekat = korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(zahtevAdministratoru.KorisnickoImeSubjekta, new List<System.Linq.Expressions.Expression<System.Func<KorisnickiNalogEntitet, object>>>() { korisnickiNalog => korisnickiNalog.Korisnik, korisnickiNalog => korisnickiNalog.Korisnik.OsnovniKorisnikPodaci })) != null)
                                                                 .WithMessage(zahtevAdministratoru => Poruke.NePostoji("Korisnik", "sa navedenim korisničkim imenom"))
                                                                 .Must(zahtevAdministratoru => subjekat.Uloga == Uloga.Osnovni_Korisnik)
                                                                 .WithMessage(zahtevAdministratoru => Poruke.Mora("Korisničko ime", "pripadati osnovnom korisniku"))
                                                                 .Must(zahtevAdministratoru => ProveriValidnostTipaSaStanjemNaloga(subjekat, pomocnikParser.ParsiranjeTipaAdminZahtevaIzStringa(zahtevAdministratoru.Tip), out poruka))
                                                                 .WithMessage(zahtevAdministratoru => poruka)
                                                                 .WithName("KorisnickoImeSubjekta");
        }
        private bool ProveriValidnostTipaSaStanjemNaloga(KorisnickiNalogEntitet korisnickiNalog, TipAdministratorskogZahteva? tip, out string poruka)
        {
            poruka = null;
            if (tip == null) return true;
            var neNullableTip = (TipAdministratorskogZahteva)tip;
            if (korisnickiNalog.StatusNaloga == StatusKorisnickogNaloga.Obrisan)
            {
                poruka = Poruke.PotrebnoProslediti("Korisničko ime naloga čiji status nije obrisan");
                return false;
            }
            if (korisnickiNalog.StatusNaloga == StatusKorisnickogNaloga.Blokiran && neNullableTip == TipAdministratorskogZahteva.Blokiranje_Korisnickog_Naloga)
            {
                poruka = Poruke.KorisnickiNalogJe("već blokiran");
                return false;
            }
            if (korisnickiNalog.StatusNaloga == StatusKorisnickogNaloga.Aktivan && neNullableTip == TipAdministratorskogZahteva.Deblokiranje_Korisnickog_Naloga)
            {
                poruka = Poruke.KorisnickiNalogJe("trenutno aktivan");
                return false;
            }
            if (korisnickiNalog.Korisnik.OsnovniKorisnikPodaci.Privilegije.HasFlag(OsnovniKorisnikPrivilegije.Zabrana_Komentarisanja) && neNullableTip.HasFlag(TipAdministratorskogZahteva.Ukidanje_Privilegija_Komentarisanja))
            {
                poruka = Poruke.KorisnikVecPoseduje("komentarisanja");
                return false;
            }
            if (korisnickiNalog.Korisnik.OsnovniKorisnikPodaci.Privilegije.HasFlag(OsnovniKorisnikPrivilegije.Zabrana_Dodavanja_Materijala) && neNullableTip.HasFlag(TipAdministratorskogZahteva.Ukidanje_Privilegija_Dodavanja_Materijala))
            {
                poruka = Poruke.KorisnikVecPoseduje("dodavanja materijala");
                return false;
            }
            if (korisnickiNalog.Korisnik.OsnovniKorisnikPodaci.Privilegije.HasFlag(OsnovniKorisnikPrivilegije.Zabrana_Ocenjivanja) && neNullableTip.HasFlag(TipAdministratorskogZahteva.Ukidanje_Privilegija_Ocenjivanja))
            {
                poruka = Poruke.KorisnikVecPoseduje("ocenjivanja");
                return false;
            }
            return true;
        }
    }
}
