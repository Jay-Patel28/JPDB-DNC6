using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JPDB.Model;
using System.Reflection.Metadata;

namespace JPDB.Data
{
    public class JPDBContext : DbContext
    {
        public JPDBContext (DbContextOptions<JPDBContext> options)
            : base(options)
        {
        }

        public DbSet<JPDB.Model.Crypto> Crypto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

         modelBuilder.Entity<Crypto>()
        .Property(b => b.Created)
        .HasDefaultValueSql("getdate()");
      
        modelBuilder.Entity<CarOwner>().HasKey(co => new { co.CarId, co.OwnerId });  
        
            modelBuilder.Entity<CarOwner>()
    .HasOne<Car>(sc => sc.Car)
    .WithMany(s => s.CarOwners)
    .HasForeignKey(sc => sc.CarId);


modelBuilder.Entity<CarOwner>()
    .HasOne<Owner>(sc => sc.Owner)
    .WithMany(s => s.CarOwners)
    .HasForeignKey(sc => sc.OwnerId);


        }

        public DbSet<JPDB.Model.User>? User { get; set; }

        public DbSet<JPDB.Model.CarOwner>? CarOwners { get; set; }

        public DbSet<JPDB.Model.Car>? Car { get; set; }

        public DbSet<JPDB.Model.Owner>? Owner { get; set; }
        public DbSet<JPDB.Model.CarInputModel>? CarInputModel { get; set; }
        public DbSet<JPDB.Model.OwnerInputModel>? OwnerInputModel { get; set; }
        public DbSet<JPDB.Model.OwnerInputWithNewCarModel>? OwnerInputWithNewCarModel { get; set; }

    }
}
