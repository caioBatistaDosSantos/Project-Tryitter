using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using tryitter.Models;
using tryitter.Context;

namespace tryitter.Tests;

public class TryitterMockData
{
    public static async Task CreateAPI(TryitterFactory application, bool create)
    {
        using (var scope = application.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using (var tryitterDbContext = provider.GetRequiredService<TryitterContext>())
            {
                await tryitterDbContext.Database.EnsureCreatedAsync();
                // await tryitterDbContext.Database.EnsureDeletedAsync();

                if (!create)
                {
                    await tryitterDbContext.Database.EnsureDeletedAsync();

                    // await tryitterDbContext.Users.AddAsync(
                    //     new User {
                    //         Id = 1,
                    //         Name = "Bruce",
                    //         Email = "wayne@gmail.com",
                    //         Module = "Ciência da Computação",
                    //         Status = "Eu sou a vingança!",
                    //         Password = "123456"
                    //     }
                    // );
                    
                    // await tryitterDbContext.Users.AddAsync(
                    //     new User {
                    //         Id = 2,
                    //         Name = "Hulk",
                    //         Email = "hulkbravo@gmail.com",
                    //         Module = "Frontend",
                    //         Status = "Quebrando o computador porque não conseguiu centralizar o texto do botão!",
                    //         Password = "123456"
                    //     }
                    // );

                    // await tryitterDbContext.Posts.AddAsync(
                    //     new Post {
                    //         PostId = 1,
                    //         UserId = 2,
                    //         UrlImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.contabeis.com.br%2Fartigos%2F7479%2Fbatman-e-suas-fraudes-contabeis%2F&psig=AOvVaw3lKYN8Pd65-zTxWCyQbFpH&ust=1667600202902000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCMj-xICFk_sCFQAAAAAdAAAAABAE",
                    //         PublishedAt = DateTime.Now,
                    //         UpdatedAt = DateTime.Now,
                    //         Content = "Combatendo o crime em Gothan por meio da programação.",
                    //     }
                    // );

                    // await tryitterDbContext.Posts.AddAsync(
                    //     new Post {
                    //         PostId = 2,
                    //         UserId = 2,
                    //         UrlImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.contabeis.com.br%2Fartigos%2F7479%2Fbatman-e-suas-fraudes-contabeis%2F&psig=AOvVaw3lKYN8Pd65-zTxWCyQbFpH&ust=1667600202902000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCMj-xICFk_sCFQAAAAAdAAAAABAE",
                    //         PublishedAt = DateTime.Now,
                    //         UpdatedAt = DateTime.Now,
                    //         Content = "Alfred, envie o bat-pc!",
                    //     }
                    // );

                    // await tryitterDbContext.Posts.AddAsync(
                    //     new Post {
                    //         PostId = 3,
                    //         UserId = 1,
                    //         UrlImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.uol.com.br%2Fsplash%2Fnoticias%2F2021%2F08%2F04%2Fvilao-hulk.htm&psig=AOvVaw0_VAZo8OXL6wC9veOz7Zh9&ust=1667600642950000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCKjG9NGGk_sCFQAAAAAdAAAAABAE",
                    //         PublishedAt = DateTime.Now,
                    //         UpdatedAt = DateTime.Now,
                    //         Content = "Quebrando o computador porque não conseguiu centralizar o texto do botão!",
                    //     }
                    // );
                    
                    // await tryitterDbContext.SaveChangesAsync();
                }
            }
        }
    }
}