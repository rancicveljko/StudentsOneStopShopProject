using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEntitet
{
    public class StringKorisnickoImeUKorisnickiNalogEntitetKonverter : ITypeConverter<string, KorisnickiNalogEntitet>
    {
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;

        public StringKorisnickoImeUKorisnickiNalogEntitetKonverter(IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum)
        {
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
        }
        public KorisnickiNalogEntitet Convert(string izvor, KorisnickiNalogEntitet destinacija, ResolutionContext context)
        {
            return _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(izvor);
        }
    }
}