using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class OblastEntitetKonfiguracija : IEntityTypeConfiguration<OblastEntitet>
    {
        public void Configure(EntityTypeBuilder<OblastEntitet> entitet)
        {
            entitet.HasKey(kljuc => kljuc.ID);
            entitet.HasOne<OblastEntitet>(prop => prop.Nadoblast)
                .WithMany(prop => prop.Podoblasti);
            entitet.HasIndex(prop => prop.Putanja).IsUnique();
            entitet.Property(prop => prop.ID).ValueGeneratedOnAdd();
            entitet.Property(prop => prop.Putanja).IsRequired();
            entitet.Property(prop => prop.Naziv).IsRequired();
            entitet.Property(prop => prop.PotrebnoOdobrenje).IsRequired();
        }
    }
}