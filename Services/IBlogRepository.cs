using System.Collections.Generic;
using OracleDBWithDotNetCore.Models;

namespace OracleDBWithDotNetCore.Services
{
    public interface IBlogRepository
    {

        IEnumerable<Blog> GetAllBlogs();

        Blog GetBlogById(int id);

        void AddBlog(Blog blog);

        void DeleteBlog(Blog blog);

    }
}