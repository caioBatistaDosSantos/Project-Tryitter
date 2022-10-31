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

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get() {
        return Ok(await _repository.Get());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetByPk(int id) {

        var user = await _repository.GetByPk(id);

        if(user == null)
            return NoContent();

        return Ok(user);
    }
}
