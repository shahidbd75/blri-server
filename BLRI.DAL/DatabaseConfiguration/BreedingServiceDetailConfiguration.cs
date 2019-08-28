using BLRI.Entity.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class BreedingServiceDetailConfiguration:IEntityTypeConfiguration<BreedingServiceDetail>
    {
        public void Configure(EntityTypeBuilder<BreedingServiceDetail> builder)
        {
            builder.Property(bs=>bs.BreedingServiceId).IsRequired();
            builder.Property(bs=>bs.EstrousDate).IsRequired();
            //builder.Property(bs=>bs.ServiceDate).IsRequired(false);
            builder.Property(bs=>bs.ServiceConfirmed).IsRequired().HasDefaultValueSql("false");

            builder.HasOne<BreedingService>(b => b.BreedingService)
                .WithMany(bs=>bs.BreedingServiceDetails)
                .HasForeignKey(b => b.BreedingServiceId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("BreedingServiceDetail");
        }
    }
}
