using BLRI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class AnimalConfiguration:IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(a => a.Code).IsRequired();
            builder.Property(a => a.DamId).IsRequired();
            builder.Property(a => a.SireId).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.Generation).IsRequired();
            builder.Property(a => a.GenoType).IsRequired();
            //builder.HasOne(e => e.Details).WithOne(o => o.Product).HasForeignKey<ProductDetail>(e => e.ProductID);
            //builder.Property(x => x.Cost).HasColumnName("StandardCost");
            //builder.HasQueryFilter(o => o.Cost > 0);
            builder.ToTable("Animal");
        }
    }
}
