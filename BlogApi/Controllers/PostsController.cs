using Api_blog.Repositório;
using BlogApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Api_blog.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {

        private readonly IBlogRepository _repositorio;

        
        public PostsController(IBlogRepository repositorio)
        {
            _repositorio = repositorio;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {

            try
            {
                var posts = await _repositorio.GetAllPosts();
                return Ok(posts);
            }
            catch
            {
                return BadRequest("Error, posts not found");
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Post>> GetPostId([FromRoute] string Id)
        {

                var post = await _repositorio.GetById(Id);
                if (post == null)
                {
                    return BadRequest();
                }
                return post;
            

        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] PostEntitie post)
        {   
            
            var result = await _repositorio.Create(post);

            if (result)
            {
                return Ok(post);
            } else
            {
                return BadRequest();
            }

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatePost([FromBody] Post post, [FromRoute] string Id)
        {

            var result = await _repositorio.Update(post, Id);

            if (result)
            {
                return Ok(post);
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
