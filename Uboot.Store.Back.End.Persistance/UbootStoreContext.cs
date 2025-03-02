using Microsoft.EntityFrameworkCore;

namespace Uboot.Store.Back.End.Persistance;

internal partial class UbootStoreContext(DbContextOptions<UbootStoreContext> options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}
