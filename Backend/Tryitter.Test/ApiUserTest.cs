using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using tryitter.Models;

namespace tryitter.Tests;

public class ApiUserTest
{
    [Fact]
    public async Task GET_all_users_test_sucess()
    {
        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User";

        var client = application.CreateClient();

        var result = await client.GetAsync(url);
        var users = await client.GetFromJsonAsync<IEnumerable<User>>(url);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        users.Count().Should().Be(4);
    }
}