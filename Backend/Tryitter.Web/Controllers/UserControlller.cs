using Microsoft.AspNetCore.Mvc;
using tryitter.UserRepository;
using System.Threading.Tasks;
using tryitter.Models;
using Microsoft.AspNetCore.Authorization;


namespace Tryitter.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
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
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<string>> Login(User request) 
    {
        return Ok(await _repository.Login(request));
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
    [HttpGet("{userid}")]
    public async Task<ActionResult<User>> GetByPk(int id) {
        try 
        {
            return Ok(await _repository.GetByPk(id));
        }
        catch (InvalidOperationException err)
        {
            Console.WriteLine(err.Message);
            return NotFound("Não encontrei.");
        }
    }

    /// <summary>
    /// Lista um objeto User com seus respectivos item de objeto Post
    /// </summary>
    /// <returns>Um item do objeto User</returns>
    /// <response code="200">Retorna o objeto User encontrado com seus posts</response>
    [HttpGet("posts")]
    public async Task<ActionResult<User>> GetUserWithYourPosts(int id) {
        try 
        {
            return Ok(await _repository.GetUserWithYourPosts(id));
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
            return NotFound("Não encontrei.");
        }
    }

    /// <summary>
    /// Remove o item o objeto User se existir
    /// </summary>
    /// <returns>Um item do objeto User</returns>
    /// <response code="200">Retorna o objeto User encontrado</response>
    [HttpDelete("{userid}")]
    public async Task<ActionResult<User>> Remove(int id) {
        try 
        {
            return Ok(await _repository.Remove(id));
        }
        catch (InvalidOperationException err)
        {
            Console.WriteLine(err.Message);
            return NotFound("Não encontrei.");
        }
    }

    /// <summary>
    /// Atualiza o item o objeto User de acordo com id
    /// </summary>
    /// <returns>Um item do objeto User</returns>
    /// <response code="200">Retorna o objeto User atualizado</response>
    [HttpPut("{userid}")]
    public async Task<ActionResult<User>> Update(int id, User request) {
        try 
        {
            return Ok(await _repository.Update(id, request));
        }
        catch(Exception err) 
        {
            return NotFound(err.Message);
        }
    }

    /// <summary>
    /// Cria um objeto User
    /// </summary>
    /// <returns>Um item do objeto User</returns>
    /// <response code="200">Retorna o objeto User criado</response>
    [HttpPost]
    public async Task<ActionResult<User>> Create(User request) {
        return Ok(await _repository.Create(request));
    }
}
