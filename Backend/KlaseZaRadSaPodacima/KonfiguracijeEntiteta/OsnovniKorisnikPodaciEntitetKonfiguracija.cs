using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class OsnovniKorisnikPodaciEntitetKonfiguracija : IEntityTypeConfiguration<OsnovniKorisnikPodaciEntitet>
    {
        public void Configure(EntityTypeBuilder<OsnovniKorisnikPodaciEntitet> entitet)
        {
            entitet.HasKey(prop => prop.IDBroj);
            entitet.HasIndex(index => index.KorisnikID).IsUnique();
            entitet.Property(prop => prop.Privilegije).IsRequired();
        }
    }
}