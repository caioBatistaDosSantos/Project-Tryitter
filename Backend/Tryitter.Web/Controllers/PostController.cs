using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tryitter.PostRepository;
using tryitter.Models;

namespace Tryitter.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private PostRepository _repository { get; set; }
        public PostController(PostRepository repository) {
            _repository = repository;
        }

        /// <summary>
        /// Lista os itens do objeto Post
        /// </summary>
        /// <returns>Os itens do objeto Post</returns>
        /// <response code="200">Retorna os itens do objeto Post</response>
        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get() {
            return Ok(await _repository.Get());
        }

        /// <summary>
        /// Lista um único item do objeto Post de acordo com id passado
        /// </summary>
        /// <returns>Um item do objeto Post</returns>
        /// <response code="200">Retorna o objeto Post encontrado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetByPk(int id) {
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
    }
}