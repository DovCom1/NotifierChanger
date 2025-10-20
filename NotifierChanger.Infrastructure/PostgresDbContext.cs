using NotifierChanger.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace NotifierChanger.Infrastructure;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    public DbSet<MessageEvent> MessageEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}