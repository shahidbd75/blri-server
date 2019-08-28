using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Task;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class HealthConfiguration:IEntityTypeConfiguration<Health>
    {
        public void Configure(EntityTypeBuilder<Health> builder)
        {
            builder.Property(a => a.AnimalId).IsRequired();
            builder.Property(a => a.DeWorming).IsRequired();
            builder.Property(a => a.Disease).IsRequired();
            builder.Property(a => a.Parasite).IsRequired();
            builder.Property(a => a.Treatment).IsRequired();
            builder.Property(a => a.Vaccination).IsRequired();

            builder.HasOne<Animal>(s => s.Animal)
                .WithMany(a=>a.Healths)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("Health");
        }
    }
}
