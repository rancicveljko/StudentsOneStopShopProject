using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class OcenaEntitetKonfiguracija : IEntityTypeConfiguration<OcenaEntitet>
    {
        public void Configure(EntityTypeBuilder<OcenaEntitet> entitet)
        {
            entitet.HasKey(kljuc => new { kljuc.AutorID, kljuc.MaterijalID });
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.Autor)
                .WithMany(prop => prop.Ocene)
                .HasForeignKey(kljuc =>  kljuc.AutorID );
            entitet.HasOne<MaterijalEntitet>(prop => prop.Materijal)
                .WithMany(prop => prop.Ocene)
                .HasForeignKey(kljuc =>kljuc.MaterijalID);
            entitet.Property(prop => prop.TipOcene).IsRequired();
        }
    }
}