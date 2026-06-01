using Microsoft.EntityFrameworkCore;

public class RESTAPIContext : DbContext
{
    public RESTAPIContext(DbContextOptions<RESTAPIContext> options)
        : base(options)
    {
    }

    public DbSet<RESTAPI.Models.TheoryPages> theorypages { get; set; } = default!;
}