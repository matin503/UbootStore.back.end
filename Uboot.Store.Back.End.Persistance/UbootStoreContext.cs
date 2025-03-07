using Microsoft.EntityFrameworkCore;
using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Persistance;

internal partial class UbootStoreContext(DbContextOptions<UbootStoreContext> options) : DbContext(options)
{
    public virtual DbSet<SubCategory> Products { get; set; }
    public virtual DbSet<SubCategory> SubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.ToTable("Product")
            .HasOne(q => q.SubCategory)
            .WithMany(q=>q.Product)
            .HasForeignKey(q=>q.SubCategoryId);
        });
        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.ToTable("SubCategory")
            .HasMany(q => q.Product)
            .WithOne(q => q.SubCategory);
        });
    }
}
