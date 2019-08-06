using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class SemenConfiguration : IEntityTypeConfiguration<Semen>
    {
        public void Configure(EntityTypeBuilder<Semen> builder)
        {
            builder.Property(a => a.AnimalId).IsRequired();
            builder.Property(a => a.AgeAtFirstEjac).IsRequired();
            builder.Property(a => a.NonReturnRate).IsRequired();
            builder.Property(a => a.ProgressiveSperm).IsRequired();
            builder.Property(a => a.SemenConc).IsRequired();
            builder.Property(a => a.SemenVolume).IsRequired();
            builder.Property(a => a.SpermLivability).IsRequired();
            builder.Property(a => a.SpermMotility).IsRequired();
            builder.Property(a => a.SpermNormality).IsRequired();

            builder.HasOne<Animal>(s => s.Animal)
                .WithMany(a=>a.Semens)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("Semen");
        }
    }
}
