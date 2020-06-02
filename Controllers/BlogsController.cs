using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OracleDBWithDotNetCore.Models;
using OracleDBWithDotNetCore.Services;
using Serilog;

namespace OracleDBWithDotNetCore.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ILogger<BlogsController> _logger;

        public BlogsController(IBlogRepository blogRepository, ILogger<BlogsController> logger)
        {
            _blogRepository = blogRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetAll()
        {
            _logger.LogInformation("All the blogs are fetched..");
            var blogs = _blogRepository.GetAllBlogs();
            return Ok(blogs);
        }

        [HttpGet("{id}", Name = "GetBlogById")]
        public ActionResult<Blog> GetById(int id)
        {
            _logger.LogInformation("A particular blog is being fetched..");
            var blog = _blogRepository.GetBlogById(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPost]
        public ActionResult<Blog> CreateBlog(Blog blog)
        {
            _logger.LogInformation("A blog is added");
            _blogRepository.AddBlog(blog);
            return CreatedAtRoute("GetBlogById", new { Id = blog.BlogId }, blog);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBlog(int id)
        {
            var blog = _blogRepository.GetBlogById(id);
            if (blog == null) return NotFound();
            _blogRepository.DeleteBlog(blog);
            return NoContent();
        }

    }
}