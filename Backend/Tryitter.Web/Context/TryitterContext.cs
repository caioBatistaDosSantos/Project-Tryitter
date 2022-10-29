using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Context;

public class TryitterContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable(@"Server=localhost; Database=students_db; Uid=root; Pwd=123456;");

            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 11)),
                options => options.EnableRetryOnFailure()
            );
        }
    }
}