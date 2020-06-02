using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OracleDBWithDotNetCore.Models;
using OracleDBWithDotNetCore.Services;

namespace OracleDBWithDotNetCore.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetAll()
        {
            var blogs = _blogRepository.GetAllBlogs();
            return Ok(blogs);
        }

        [HttpGet("{id}", Name = "GetBlogById")]
        public ActionResult<Blog> GetById(int id)
        {
            var blog = _blogRepository.GetBlogById(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPost]
        public ActionResult<Blog> CreateBlog(Blog blog)
        {
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