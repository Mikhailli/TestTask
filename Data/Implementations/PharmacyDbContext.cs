#nullable enable
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations;

public class PharmacyDbContext : DbContext
{
    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Medicine> Medicines { get; set; }
    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>()
            .HasMany(s => s.Medicines)
            .WithOne(m => m.Supplier)
            .HasForeignKey(m => m.SupplierId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=pharmacy.db", b => b.MigrationsAssembly("Data"));
    }
}
