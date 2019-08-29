using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class BreedingConfiguration:IEntityTypeConfiguration<Breeding>
    {
        public void Configure(EntityTypeBuilder<Breeding> builder)
        {
            builder.Property(a => a.AnimalId).IsRequired();
//            builder.Property(a => a.FirstCalvingDate).IsRequired();
//            builder.Property(a => a.FirstConceptionDate).IsRequired();
//            builder.Property(a => a.FirstHeatDate).IsRequired();
//            builder.Property(a => a.WeaningDate).IsRequired();

            builder.HasOne<Animal>(s => s.Animal)
                .WithMany(a=>a.Breedings)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("Breeding");
        }
    }
}
