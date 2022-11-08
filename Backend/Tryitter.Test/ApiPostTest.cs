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

public class ApiPostTest
{   
    [Fact]
    public async Task GET_all_posts_test_sucess()
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
        var url = "/Post";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await client.GetFromJsonAsync<IEnumerable<Post>>(url);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Count().Should().Be(4);
    }

    [Fact]
    public async Task GET_post_me_last_test_sucess()
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
        var url = "/Post/me/last";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadFromJsonAsync<Post>();

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeOfType<Post>();
    }

    [Fact]
    public async Task GET_post_me_last_test_failed()
    {
        User user = new()
        {
            Id = 100,
            Name = "Bruce",
            Email = "wayne@gmail.com",
            Module = "Ciência da Computação",
            Status = "Combatendo o crime em Gothan por meio da programação.",
            Password = "123456"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/Post/me/last";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task GET_post_by_pk_test_sucess()
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
        var url = "/Post/1";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadFromJsonAsync<Post>();

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeOfType<Post>();
    }

    [Fact]
    public async Task GET_post_by_pk_test_failed()
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
        var url = "/Post/1000";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task GET_post_by_user_test_sucess()
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
        var url = "/Post/all/2";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadFromJsonAsync<List<Post>>();

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeOfType<List<Post>>();
        content.Count().Should().Be(1);
    }

    [Fact]
    public async Task GET_post_by_user_test_failed()
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
        var url = "/Post/all/1000";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task GET_last_post_by_user_test_sucess()
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
        var url = "/Post/last/2";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.GetAsync(url);
        var content = await result.Content.ReadFromJsonAsync<Post>();

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeOfType<Post>();
    }

    [Fact]
    public async Task DELETE_post_test_sucess()
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
        var url = "/Post/1";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.DeleteAsync(url);

        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DELETE_post_test_failed()
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
        var url = "/Post/1000";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.DeleteAsync(url);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task PUT_post_test_sucess()
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
        Post post = new()
        {
            Content = "Content for test"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/Post/1";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.PutAsJsonAsync(url, post);
        var content = await result.Content.ReadFromJsonAsync<Post>();

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeOfType<Post>();
        content.Content.Should().Be(post.Content);
    }

    [Fact]
    public async Task PUT_post_test_failed()
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
        Post post = new()
        {
            Content = "Content for test"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/Post/1000";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.PutAsJsonAsync(url, post);
        var content = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().BeEquivalentTo("Não encontrei.");
    }

    [Fact]
    public async Task POST_post_test_sucess()
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
        Post post = new()
        {
            Content = "Content for test"
        };

        var token = new TokenGenerator().Generate(user);

        await using var application = new TryitterFactory();

        await TryitterMockData.CreateAPI(application, true);
        var url = "/Post";

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var result = await client.PostAsJsonAsync(url, post);
        var content = await result.Content.ReadFromJsonAsync<Post>();

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeOfType<Post>();
        content.Content.Should().Be(post.Content);
    }
}