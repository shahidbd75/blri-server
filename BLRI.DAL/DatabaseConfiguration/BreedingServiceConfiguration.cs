using BLRI.Entity.Animals;
using BLRI.Entity.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class BreedingServiceConfiguration:IEntityTypeConfiguration<BreedingService>
    {
        public void Configure(EntityTypeBuilder<BreedingService> builder)
        {
            builder.Property(b => b.AnimalId).IsRequired();
            builder.Property(b => b.Parity).IsRequired();
            //builder.Property(b => b.CalvingDate).IsRequired(false);

            builder.HasOne<Animal>(a => a.Animal)
                .WithMany(b=>b.BreedingServices)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("BreedingService");
        }
    }
}
