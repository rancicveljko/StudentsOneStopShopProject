using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class KorisnickiNalogEntitetKonfiguracija : IEntityTypeConfiguration<KorisnickiNalogEntitet>
    {
        public void Configure(EntityTypeBuilder<KorisnickiNalogEntitet> entitet)
        {
            entitet.HasIndex(index => index.KorisnickoIme).IsUnique();
            entitet.HasKey(kljuc => kljuc.KorisnikID);
            entitet.Property(prop => prop.Uloga).IsRequired();
            entitet.Property(prop => prop.KorisnickoIme).IsRequired();
            entitet.Property(prop => prop.Lozinka).IsRequired();
            entitet.Property(prop => prop.StatusNaloga).IsRequired();
            entitet.Property(prop => prop.PoslednjaPromena).IsRequired();
        }
    }
}