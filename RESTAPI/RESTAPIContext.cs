using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

public class RESTAPIContext : DbContext
{
    public RESTAPIContext(DbContextOptions<RESTAPIContext> options)
        : base(options)
    {
    }

    public DbSet<RESTAPI.Models.TheoryPages> theorypages { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        modelBuilder.Entity<TheoryPages>()
            .ToTable("theorypages");
    }
}
