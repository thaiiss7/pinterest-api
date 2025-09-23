using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pinterest.Models;

public class PinterestDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Pin> Pins => Set<Pin>();
    public DbSet<Folder> Folders => Set<Folder>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Profile>();

        model.Entity<Pin>()
            .HasOne(p => p.Author)
            .WithMany(p => p.CreatedPins)
            .HasForeignKey(p => p.ProfileID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Folder>()
            .HasOne(p => p.Author)
            .WithMany(p => p.Folders)
            .HasForeignKey(p => p.ProfileID)
            .OnDelete(DeleteBehavior.NoAction);


        model.Entity<Folder>()
            .HasMany(f => f.Pins)
            .WithMany(p => p.Folders)
            .UsingEntity("PinFolder");
    }
}