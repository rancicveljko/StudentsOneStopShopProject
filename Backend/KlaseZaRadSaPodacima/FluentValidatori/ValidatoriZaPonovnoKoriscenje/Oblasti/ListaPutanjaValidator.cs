using System;
using System.Collections.Generic;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti
{
    public class ListaPutanjaValidator : AbstractValidator<IListaPutanjaOblasti>
    {
        public ListaPutanjaValidator(IPomocnikManuelniValidator manuelniValidator,
                                     PutanjaValidator putanjaValidator,
                                     IPomocnikParser pomocnikParser,
                                     IPomocnikValidatoraPutanje pomocnikValidatoraPutanje)
        {
            string poruka = null;
            List<string> prosirenePutanje = new List<string>();
            RuleFor(listaPutanjaOblasti => listaPutanjaOblasti).Cascade(CascadeMode.Stop)
                                                               .Must(listaPutanjaOblasti => listaPutanjaOblasti.PotrebnaValidacijaPraznihPolja ? listaPutanjaOblasti.PutanjeOblasti != null : true)
                                                               .WithMessage(listaPutanjaOblasti => listaPutanjaOblasti.PotrebnaValidacijaPraznihPolja ? Poruke.PotrebnoProsleditiSaUslovom("Lista putanja", "za naprednog korisnika! Ukoliko korisnik nije nadležan ni za jednu oblast, potrebno je proslediti praznu listu") : Poruke.PotrebnoProsleditiSaUslovom("Lista putanja", "prazna, ukoliko korisnik nije nadležan ni za jednu oblast"))
                                                               .DependentRules(() =>
                                                               {
                                                                   OmotacPutanje putanja = null;
                                                                   RuleForEach(listaPutanjaOblasti => listaPutanjaOblasti.PutanjeOblasti).Cascade(CascadeMode.Stop)
                                                                                                                                         .NotEmpty()
                                                                                                                                         .WithMessage(listaPutanjaOblasti => Poruke.Sadrzi("Lista putanja", "samo neprazne putanje"))
                                                                                                                                         .Must(listaPutanjaOblasti => pomocnikValidatoraPutanje.DopuniPutanju(putanja = new OmotacPutanje(listaPutanjaOblasti, true, true), false, true, out poruka))
                                                                                                                                         .WithMessage(listaPutanjaOblasti => poruka)
                                                                                                                                         .Must(listaPutanjaOblasti => manuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, putanja, out poruka))
                                                                                                                                         .WithMessage(listaPutanjaOblasti => poruka)
                                                                                                                                         .Must(listaPutanjaOblasti => DodajUListuNovihPutanja(prosirenePutanje,putanja))
                                                                                                                                         .WithName("PutanjeOblasti");
                                                               })
                                                               .DependentRules(() => 
                                                               {
                                                                   RuleFor(listaPutanjaOblasti => listaPutanjaOblasti).Must(listaPutanjaOblasti => ZameniListuPutanja(listaPutanjaOblasti, prosirenePutanje));
                                                               })
                                                               .WithName("PutanjeOblasti")
                                                               .When(listaPutanjaOblasti => (pomocnikParser.ParsiranjeUlogeIzStringa(listaPutanjaOblasti.Uloga) == Uloga.Napredni_Korisnik || listaPutanjaOblasti.Uloga == null) && (listaPutanjaOblasti.PutanjeOblasti != null || listaPutanjaOblasti.PotrebnaValidacijaPraznihPolja));
        }
        private bool ZameniListuPutanja(IListaPutanjaOblasti listaPutanjaOblasti, List<string> novaListaPutanjaOblasti)
        {
            listaPutanjaOblasti.PutanjeOblasti = novaListaPutanjaOblasti;
            return true;
        }
        private bool DodajUListuNovihPutanja(List<string> listaNovihPutanja, OmotacPutanje putanja)
        {
            listaNovihPutanja.Add(putanja.Putanja);
            return true;
        }
    }
}
