using Microsoft.EntityFrameworkCore;
using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Persistance;

internal partial class UbootStoreContext(DbContextOptions<UbootStoreContext> options) : DbContext(options)
{
    public virtual DbSet<ProductModel> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.ToTable("Product");
        });
    }
}
