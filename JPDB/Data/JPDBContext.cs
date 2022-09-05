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
        }

        public DbSet<JPDB.Model.User>? User { get; set; }

    }
}
