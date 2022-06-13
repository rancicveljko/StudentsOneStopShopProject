using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class KorisnikEntitetKonfiguracija : IEntityTypeConfiguration<KorisnikEntitet>
    {
        public void Configure(EntityTypeBuilder<KorisnikEntitet> entitet)
        {
            entitet.HasKey(kljuc => kljuc.ID);
            entitet.HasIndex(index => index.Email).IsUnique();
            entitet.Property(prop => prop.ID).ValueGeneratedOnAdd();
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.KorisnickiNalog)
                .WithOne(prop => prop.Korisnik)
                .HasForeignKey<KorisnickiNalogEntitet>(kljuc => kljuc.KorisnikID).IsRequired();
            entitet.HasOne<OsnovniKorisnikPodaciEntitet>(prop => prop.OsnovniKorisnikPodaci)
                .WithOne(prop => prop.Korisnik)
                .HasForeignKey<OsnovniKorisnikPodaciEntitet>(kljuc => kljuc.KorisnikID).IsRequired();
            entitet.Property(prop => prop.Email).IsRequired();
            entitet.Property(prop => prop.Prezime).IsRequired();
            entitet.Property(prop => prop.Ime).IsRequired();
        }
    }
}