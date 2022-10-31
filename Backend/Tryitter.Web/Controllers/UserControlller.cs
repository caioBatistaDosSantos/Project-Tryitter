using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using System.Threading.Tasks;
using tryitter.Models;

namespace Tryitter.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public TryitterRepository _repository { get; set; }
    public UserController(TryitterRepository repository) {
        _repository = repository;
    }

    [HttpGet]
    public async Task<List<User>> Get() {
        return await _repository.Get();
    }
}
