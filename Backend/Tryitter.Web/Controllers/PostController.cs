using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tryitter.PostRepository;

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
    }
}