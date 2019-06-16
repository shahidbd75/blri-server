using BLRI.DAL.DatabaseConfiguration;
using BLRI.DAL.Extensions;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using BLRI.Entity.Auth;
using BLRI.Entity.Units;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BLRI.DAL.Repositories.Core
{
    public class ApplicationDbContext: IdentityDbContext<User>, IApplicationDbContext
    {
        public DbSet<BiometricUnit> BiometricUnit { get; set; }
        public DbSet<GrowthUnit> GrowthUnit { get; set; }
        public DbSet<WeightUnit> WeightUnit { get; set; }
        public DbSet<AnimalCategory> AnimalCategory { get; set; }

        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
    