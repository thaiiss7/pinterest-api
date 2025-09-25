using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pinterest.Models;

public class PinterestDbContext(DbContextOptions<PinterestDbContext> options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Pin> Pins => Set<Pin>();
    public DbSet<Folder> Folders => Set<Folder>();
    public DbSet<Like> Likes => Set<Like>();

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

        model.Entity<Like>()
            .HasOne(l => l.LikedByProfile)
            .WithMany(p => p.LikesByProfile)
            .HasForeignKey(l => l.ProfileId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Like>()
            .HasOne(l => l.LikedPin)
            .WithMany(p => p.Likes)
            .HasForeignKey(l => l.PinId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(p => p.CommentsByProfile)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Comment>()
            .HasOne(c => c.Pin)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PinId)
            .OnDelete(DeleteBehavior.NoAction);

        // N-N
        model.Entity<Folder>()
            .HasMany(f => f.Pins)
            .WithMany(p => p.Folders)
            .UsingEntity("PinFolder");
    }
}

public class PinterestDbContextFactory : IDesignTimeDbContextFactory<PinterestDbContext>
{
    public PinterestDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION") ?? "PinterestDB";

        var optionsBuilder = new DbContextOptionsBuilder<PinterestDbContext>();
        optionsBuilder.UseInMemoryDatabase(connectionString);

        return new PinterestDbContext(optionsBuilder.Options);
    }
}