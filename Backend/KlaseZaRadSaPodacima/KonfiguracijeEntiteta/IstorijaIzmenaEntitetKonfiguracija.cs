using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class IstorijaIzmenaEntitetKonfiguracija : IEntityTypeConfiguration<IstorijaIzmenaEntitet>
    {
        public void Configure(EntityTypeBuilder<IstorijaIzmenaEntitet> entitet)
        {
            entitet.HasKey(kljuc => new { kljuc.AutorID, kljuc.MaterijalID, kljuc.VremeIzmene });
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.Autor)
                .WithMany(prop => prop.IstorijaIzmena)
                .HasForeignKey(kljuc => new { kljuc.AutorID });
            entitet.HasOne<MaterijalEntitet>(prop => prop.Materijal)
                .WithMany(prop => prop.Izmene)
                .HasForeignKey(kljuc => kljuc.MaterijalID);
            entitet.Property(prop => prop.TipIzmene).IsRequired();
            entitet.Property(prop => prop.VremeIzmene).IsRequired();
        }
    }
}