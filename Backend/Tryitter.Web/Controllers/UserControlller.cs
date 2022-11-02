using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using System.Threading.Tasks;
using tryitter.Models;

namespace Tryitter.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserRepository _repository { get; set; }
    public UserController(UserRepository repository) {
        _repository = repository;
    }

    /// <summary>
    /// Lista os itens do objeto User
    /// </summary>
    /// <returns>Os itens do objeto User</returns>
    /// <response code="200">Retorna os itens do objeto User</response>
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get() {
        return Ok(await _repository.Get());
    }

    /// <summary>
    /// Lista um único item do objeto User de acordo com id passado
    /// </summary>
    /// <returns>Um item do objeto User</returns>
    /// <response code="200">Retorna o objeto User encontrado</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetByPk(int id) {
        try 
        {
            return Ok(await _repository.GetByPk(id));
        }
        catch (InvalidOperationException err)
        {
            Console.WriteLine(err.Message);
            return NoContent();
        }
    }
}
