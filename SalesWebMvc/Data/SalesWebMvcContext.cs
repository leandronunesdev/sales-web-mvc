using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

public class SalesWebMvcContext : DbContext
{
    public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Department { get; set; }
    public DbSet<Seller> Seller { get; set; }
    public DbSet<SalesRecord> SalesRecord { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesRecord>()
            .HasOne(sr => sr.Seller)
            .WithMany(s => s.Sales)
            .HasForeignKey(sr => sr.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
