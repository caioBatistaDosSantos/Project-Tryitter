using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using tryitter.Models;
using TryitterAuth;
using Tryitter.Requesties;
using tryitter.Auth;
using tryitter.Requesties;

namespace tryitter.Tests;

public class ApiUserTest
{
    [Fact]
    public async Task GET_all_users_test_sucess()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var users = await client.GetFromJsonAsync<IEnumerable<User>>(url);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        users.Count().Should().Be(4);
    }

    [Fact]
    public async Task GET_all_users_test_empty()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, false);
        var url = "/User";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var users = await client.GetFromJsonAsync<IEnumerable<User>>(url);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        users.Count().Should().Be(0);
    }

    [Fact]
    public async Task POST_login_test_sucess()
    {
        UserLogin userLogin = new()
        {
            Email = "wayne@gmail.com",
            Password = "123456"
        };

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User";

        var client = application.CreateClient();

        var result = await client.PostAsJsonAsync(url, userLogin);
        var content = await result.Content.ReadFromJsonAsync<AuthToken>();

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Token.Should().BeOfType<string>();
    }

    [Fact]
    public async Task GET_user_by_id_test_sucess()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User/1";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await client.GetFromJsonAsync<User>(url);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task GET_user_by_id_test_failed()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User/100";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task DELETE_user_by_id_test_sucess()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User/1";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.DeleteAsync(url);

        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DELETE_user_by_id_test_failed()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User/100";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.DeleteAsync(url);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task PUT_user_by_id_test_sucess()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User/2";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.PutAsJsonAsync(url, user);
        var content = await client.GetFromJsonAsync<User>(url);

        user.Id = 2;
        
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task PUT_user_by_id_test_failed()
    {
        User user = new()
        {
            Id = 1,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User/100";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.PutAsJsonAsync(url, user);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task POST_user_test_sucess()
    {
        User user = new()
        {
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/User";

        var client = application.CreateClient();

        var result = await client.PostAsJsonAsync(url, user);
        var content = await result.Content.ReadFromJsonAsync<User>();
        
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Name.Should().Be(user.Name);
    }
}