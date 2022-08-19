using Microsoft.EntityFrameworkCore;
using VTNT1.Models;

namespace VTNT1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FaseCafe>()
                .HasOne(fc => fc.Passagem_VTNT1)
                .WithOne(p => p.FaseCafe)
                .HasForeignKey<Passagem_VTNT1>(p => p.FaseCafeID);


        }

        public DbSet<Passagem_VTNT1> tb_PassagemsVTNT1 { get; set; }
        public DbSet<FaseCafe> tb_FasesCafe { get; set; }
        
    }
}
