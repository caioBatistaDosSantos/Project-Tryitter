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
            var connectionString = Environment.GetEnvironmentVariable(@"Server=db; Database=tryitter_db; Uid=root; Pwd=123456;");

            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 11)),
                options => options.EnableRetryOnFailure()
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder mb) 
    {
        // User -> 1:N Post
        // Grade -> 1:N Student
        mb.Entity<Post>()
            .HasOne<User>(u => u.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);

        mb.Entity<User>()
            .HasKey(u => u.Id);

        mb.Entity<Post>()
            .HasKey(p => p.PostId);
        
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

        mb.Entity<Post>()
            .Property(p => p.Content)
            .HasMaxLength(300);

        mb.Entity<Post>()
            .HasData(
                new Post {
                    PostId = 1,
                    UserId = 2,
                    UrlImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.contabeis.com.br%2Fartigos%2F7479%2Fbatman-e-suas-fraudes-contabeis%2F&psig=AOvVaw3lKYN8Pd65-zTxWCyQbFpH&ust=1667600202902000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCMj-xICFk_sCFQAAAAAdAAAAABAE",
                    PublishedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Content = "Combatendo o crime em Gothan por meio da programação.",
                },
                new Post {
                    PostId = 2,
                    UserId = 1,
                    UrlImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.uol.com.br%2Fsplash%2Fnoticias%2F2021%2F08%2F04%2Fvilao-hulk.htm&psig=AOvVaw0_VAZo8OXL6wC9veOz7Zh9&ust=1667600642950000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCKjG9NGGk_sCFQAAAAAdAAAAABAE",
                    PublishedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Content = "Quebrando o computador porque não conseguiu centralizar o texto do botão!",
                },
                new Post {
                    PostId = 3,
                    UserId = 3,
                    UrlImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DUT4COqFmN3U&psig=AOvVaw3lIWidWWZFj2XAimiVh8mQ&ust=1667600583332000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCMCv0LWGk_sCFQAAAAAdAAAAABAE",
                    PublishedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Content = "Bwahahahahahaha",
                },
                new Post {
                    PostId = 4,
                    UserId = 4,
                    UrlImage = "https://www.google.com/imgres?imgurl=https%3A%2F%2F64.media.tumblr.com%2F6a7a90ddf33fd8793cf0e9bcd0b3ae75%2F7325867cb61c486a-7a%2Fs500x750%2F57f4db17cfee6d364a68875f5d09bf4c4977f83a.png&imgrefurl=https%3A%2F%2Fericsrandomstuff.tumblr.com%2Fpost%2F45156076828%2F30-day-phineas-and-ferb-challenge-day-29&tbnid=oypBwrspvT3l_M&vet=12ahUKEwjP6_OdhpP7AhUeM7kGHS0JAR4QMygdegUIARCWAg..i&docid=9zBYnRKiD8KzzM&w=500&h=371&q=phineas%20and%20ferb%20where%27s%20perry&ved=2ahUKEwjP6_OdhpP7AhUeM7kGHS0JAR4QMygdegUIARCWAg",
                    PublishedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Content = "Ué, cadê o Perry?",
                }
            );
    }
}