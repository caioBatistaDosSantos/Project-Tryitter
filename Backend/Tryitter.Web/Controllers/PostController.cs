using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tryitter.PostRepository;
using tryitter.Models;
using Microsoft.AspNetCore.Authorization;


namespace Tryitter.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get() {
            return Ok(await _repository.Get());
        }

        /// <summary>
        /// Lista um único item do objeto Post de acordo com id passado
        /// </summary>
        /// <returns>Um item do objeto Post</returns>
        /// <response code="200">Retorna o objeto Post encontrado</response>
        [HttpGet("me/last")]
        public async Task<ActionResult<Post>> GetLastPostFromUserLogged() {
            try 
            {
                return Ok(await _repository
                    .GetLastPostFromUserLogged(Convert.ToInt32(User.Identity.Name)));
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Não encontrei.");
            }
        }

        /// <summary>
        /// Lista um único item do objeto Post de acordo com id passado
        /// </summary>
        /// <returns>Um item do objeto Post</returns>
        /// <response code="200">Retorna o objeto Post encontrado</response>
        [HttpGet("{postid}")]
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

        /// <summary>
        /// Lista todo os Posts de um usuário específico
        /// </summary>
        /// <returns>Um item do objeto User</returns>
        /// <response code="200">Retorna os posts do objeto Post</response>
        [HttpGet("all/{userid}")]
        public async Task<ActionResult<List<Post>>> GetAllPostsFromUser(int id) {
            try 
            {
                return Ok(await _repository.GetAllPostsFromUser(id));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Não encontrei.");
            }
        }

        /// <summary>
        /// Lista o último post de um usuário específico
        /// </summary>
        /// <returns>Um item do objeto Post</returns>
        /// <response code="200">Retorna o objeto Post encontrado</response>
        [HttpGet("last/{userid}")]
        public async Task<Post> GetLastPostFromUser(int userid) {
            return await _repository.GetLastPostFromUser(userid);
        }

        /// <summary>
        /// Remove o item o objeto Post se existir
        /// </summary>
        /// <returns>Um item do objeto Post</returns>
        /// <response code="200">Retorna o objeto Post encontrado</response>
        [HttpDelete("{postid}")]
        public async Task<ActionResult<Post>> Remove(int id) {
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
        /// Atualiza o item o objeto Post de acordo com id
        /// </summary>
        /// <returns>Um item do objeto Post</returns>
        /// <response code="200">Retorna o objeto Post atualizado</response>
        [HttpPut("{postid}")]
        public async Task<ActionResult<Post>> Update(int id, Post request) {
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
        /// Cria um objeto Post
        /// </summary>
        /// <returns>Um item do objeto Post</returns>
        /// <response code="200">Retorna o objeto Post criado</response>
        [HttpPost]
        public async Task<ActionResult<Post>> Create(Post request) {
            request.UserId = Convert.ToInt32(User.Identity.Name);
            return Ok(await _repository.Create(request));
        }
    }
}