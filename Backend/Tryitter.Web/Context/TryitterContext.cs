using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Context;

public class TryitterContext : DbContext, ITryitterContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable(@"Server=localhost; Database=tryitter_db; Uid=root; Pwd=123456;");

            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 11)),
                options => options.EnableRetryOnFailure()
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder mb) 
    {
        mb.Entity<User>()
            .HasKey(u => u.Id);

        mb.Entity<Post>()
            .HasKey(p => p.Content);
        
        mb.Entity<User>()
            .HasData(
                new User {
                    Id = 1,
                    Name = "Bruce",
                    Email = "wayne@gmail.com",
                    Module = "Ciência da Computação",
                    Status = "Combatendo o crime em Gothan por meio da programação.",
                    Password = "123456"
                },
                new User {
                    Id = 2,
                    Name = "Hulk",
                    Email = "hulkbravo@gmail.com",
                    Module = "Frontend",
                    Status = "Quebrando o computador porque não conseguiu centralizar o texto do botão!",
                    Password = "123456"
                },
                new User {
                    Id = 3,
                    Name = "Ichigo",
                    Email = "kurosaki@gmail.com",
                    Module = "Backend",
                    Status = "Muuuahahahah",
                    Password = "123456"
                },
                new User {
                    Id = 4,
                    Name = "Perry",
                    Email = "agentep@gmail.com",
                    Module = "Fundamentos do Desenvolvimento Web",
                    Status = "Ué, cadê o Perry?",
                    Password = "123456"
                }
            );
    }
}