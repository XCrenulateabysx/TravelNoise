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



        // =========================
        // GENRE
        // =========================
        modelBuilder.Entity<Genre>().HasData(
            new Genre { id = 1, genrename = "Adventure" },
            new Genre { id = 2, genrename = "Puzzle" },
            new Genre { id = 3, genrename = "Racing" }
        );

        // =========================
        // USERS
        // =========================
        var adminid = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var player1id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var testerid = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = adminid,
                Username = "admin",
                Password = "$2a$11$hash_admin"
            },
            new User
            {
                Id = player1id,
                Username = "player1",
                Password = "$2a$11$hash_player1"
            },
            new User
            {
                Id = testerid,
                Username = "tester",
                Password = "$2a$11$hash_tester"
            }
        );

        // =========================
        // THEORYPAGES
        // =========================
        modelBuilder.Entity<TheoryPages>().HasData(
            new TheoryPages
            {
                id = 1,
                title = "Physics Basics",
                description = "Understanding movement in games",
                imageurl = "http://10.0.2.2:5035/images/WTTTTTTTF.png"
            },
            new TheoryPages
            {
                id = 2,
                title = "AI Behavior",
                description = "How game AI reacts to players",
                imageurl = "http://10.0.2.2:5035/images/WTTTTTTTF.png"
            },
            new TheoryPages
            {
                id = 3,
                title = "Level Design",
                description = "Designing engaging game levels",
                imageurl = "http://10.0.2.2:5035/images/WTTTTTTTF.png"
            }
        );

        // =========================
        // LOCATION
        // =========================
        modelBuilder.Entity<Location>().HasData(
            new Location
            {
                id = 1,
                RegionName = "Adventure Region",
                RegionDescription = "World exploration and quests",
                genreid = 1
            },
            new Location
            {
                id = 2,
                RegionName = "Puzzle Region",
                RegionDescription = "Logic challenges",
                genreid = 2
            },
            new Location
            {
                id = 3,
                RegionName = "Racing Region",
                RegionDescription = "Speed and competition",
                genreid = 3
            }
        );


    }
}