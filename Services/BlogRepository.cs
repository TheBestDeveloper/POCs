using System.Collections.Generic;
using System.Linq;
using OracleDBWithDotNetCore.Models;

namespace OracleDBWithDotNetCore.Services
{

    public class BlogRepository : IBlogRepository
    {
        private readonly BloggingContext _context;

        public BlogRepository(BloggingContext context)
        {
            _context = context;
        }
        public void AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            _context.Remove(blog);
            _context.SaveChanges();
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _context.Blogs.ToList();
        }

        public Blog GetBlogById(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            return blog;
        }
    }

}