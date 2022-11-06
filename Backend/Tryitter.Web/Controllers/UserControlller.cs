using Microsoft.AspNetCore.Mvc;
using tryitter.UserRepository;
using System.Threading.Tasks;
using tryitter.Models;
using Microsoft.AspNetCore.Authorization;
using Tryitter.Requesties;
using tryitter.Auth;


// Remover os campos Published, UpdatedAT, PostId, UserId.

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
    /// Realiza o login do usuário retornando um token caso o usuário seja validado com sucesso.
    /// </summary>
    /// <returns>Retorna um token</returns>
    /// <response code="200">Retorna um token</response>
    [HttpPost("/login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthToken>> Login(UserLogin request) 
    {
        return Ok(await _repository.Login(request));
    }

    /// <summary>
    /// Lista os itens do objeto User
    /// </summary>
    /// <returns>Os itens do objeto User</returns>
    /// <response code="200">Retorna os itens do objeto User</response>
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<User>>> Get() {
        return Ok(await _repository.Get());
    }

    /// <summary>
    /// Lista um único item do objeto User de acordo com id passado
    /// </summary>
    /// <returns>Um item do objeto User</returns>
    /// <response code="200">Retorna o objeto User encontrado</response>
    [HttpGet("{userid}")]
    public async Task<ActionResult<User>> GetByPk(int userid) {
        try 
        {
            return Ok(await _repository.GetByPk(userid));
        }
        catch (InvalidOperationException err)
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
    public async Task<ActionResult<User>> Remove(int userid) {
        try 
        {
            return Ok(await _repository.Remove(userid));
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
    public async Task<ActionResult<User>> Update(int userid, User request) {
        try 
        {
            return Ok(await _repository.Update(userid, request));
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
