using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

public class RESTAPIContext : DbContext
{
    public RESTAPIContext(DbContextOptions<RESTAPIContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<TheoryPages> TheoryPages => Set<TheoryPages>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<GameDescription> GameDescriptions => Set<GameDescription>();
    public DbSet<Page> Pages => Set<Page>();
    public DbSet<Practice> Practices => Set<Practice>();
    public DbSet<Vote> Votes => Set<Vote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Genre>().ToTable("genre");
        modelBuilder.Entity<TheoryPages>().ToTable("theorypages");
        modelBuilder.Entity<Location>().ToTable("Location");
        modelBuilder.Entity<GameDescription>().ToTable("gamedescription");
        modelBuilder.Entity<Page>().ToTable("pages");
        modelBuilder.Entity<Practice>().ToTable("practice");
        modelBuilder.Entity<Vote>().ToTable("vote");
        modelBuilder.Entity<Page>()
            .HasOne(p => p.location)
            .WithOne(l => l.Page)
            .HasForeignKey<Location>(l => l.pageid);





    }
}