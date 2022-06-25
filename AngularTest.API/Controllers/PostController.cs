using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularTest.Domain.Models;
using AngularTest.Services.DTO;
using AngularTest.Services.Services;

namespace AngularTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // private readonly MyDbContext _context;
        private PostService _service;

        public PostController(PostService service)
        {
            _service = service;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _service.GetAll();
            if (posts != null)
            {
                return Ok(posts);
            }
            return BadRequest(new { message = "Can't find posts" });
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _service.GetById(id);
        
            if (post != null)
            {
                return Ok(post);
            }
        
            return BadRequest(new { message = "Can't find post" });
        }

        // PUT: api/Post/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDto post)
        {
            var editedPost = await _service.Edit(id, post);
            if (editedPost != null)
            {
                return Created("Success", editedPost);
            }
            return BadRequest(new { message = "Post wasn't edited" });
        }

        // POST: api/Post
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(PostDto post)
        {
            var newPost = await _service.Create(post);
            if (newPost != null)
            {
                return Created("Success", newPost);
            }
            return BadRequest(new { message = "Post wasn't created" });
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var res = await _service.Delete(id);
            if (res)
            {
                return Ok(new { message = "Post was deleted" });
            }
            return BadRequest(new { message = "Post wasn't deleted" });
        }
    }
}
