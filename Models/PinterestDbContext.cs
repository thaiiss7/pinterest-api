using Microsoft.EntityFrameworkCore;

namespace Pinterest.Models;

public class PinterestDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Pin> Pins => Set<Pin>();
    public DbSet<Pasta> Pastas => Set<Pasta>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Profile>();

        model.Entity<Pin>()
        .HasOne(p => p.Author)
        .WithMany(p => p.CreatedPins)
        .HasForeignKey(p => p.ProfileID)
        .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Pasta>()
        .HasOne(p => p.Author)
        .WithMany(p => p.Pastas)
        .HasForeignKey(p => p.ProfileID)
        .OnDelete(DeleteBehavior.NoAction);
    }
}