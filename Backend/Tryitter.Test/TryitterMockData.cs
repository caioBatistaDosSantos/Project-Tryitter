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

                if (!create)
                {
                    await tryitterDbContext.Database.EnsureDeletedAsync();
                }
            }
        }
    }
}