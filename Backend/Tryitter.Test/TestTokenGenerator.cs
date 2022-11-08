using tryitter.Models;
using TryitterAuth;

namespace tryitter.Tests;

public class TestTokenGenerator
{
    [Theory(DisplayName = "Teste para TokenGenerator em que token não é nulo")]
    [InlineData(4, "Perry", "agentep@gmail.com", "Fundamentos do Desenvolvimento Web", "Ué, cadê o Perry?", "123456")]
    public void TestTokenGeneratorSuccess(int id, string name, string email, string module, string status, string pass)
    {
        User client = new()
        {
            Id = id,
            Name = name,
            Email = email,
            Module = module,
            Status = status,
            Password = pass
        };

        var response = new TokenGenerator().Generate(client);

        response.Should().NotBeNullOrEmpty();
    }

    [Theory(DisplayName = "Teste para TokenGenerator em que token JWT possui 3 partes")]
    [InlineData(4, "Perry", "agentep@gmail.com", "Fundamentos do Desenvolvimento Web", "Ué, cadê o Perry?", "123456")]
    public void TestTokenGeneratorKeysSuccess(int id, string name, string email, string module, string status, string pass)
    {
        User client = new()
        {
            Id = id,
            Name = name,
            Email = email,
            Module = module,
            Status = status,
            Password = pass
        };

        var response = new TokenGenerator().Generate(client);
        var result = response.Split(".");

        result.Count().Should().Be(3);
    }
}
