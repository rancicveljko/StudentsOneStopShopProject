using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class KorisnickiNalogOblastEntitetKonfiguracija : IEntityTypeConfiguration<KorisnickiNalogOblastEntitet>
    {
        public void Configure(EntityTypeBuilder<KorisnickiNalogOblastEntitet> entitet)
        {
            entitet.HasKey(kljuc => new { kljuc.NadlezniID, kljuc.OblastID });
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.Nadlezni)
                .WithMany(prop => prop.NadlezanZaOblasti)
                .HasForeignKey(kljuc => kljuc.NadlezniID );
            entitet.HasOne<OblastEntitet>(prop => prop.Oblast)
                .WithMany(prop => prop.NadlezniKorisnici)
                .HasForeignKey(kljuc => kljuc.OblastID);
        }
    }
}