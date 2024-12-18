using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hillerodLib.Enums;
using hillerodLib.Models;

namespace hillerodLib.Services.Repos
{
    public class BlogRepo
    {
        private Dictionary<int, Blog> _blogRepo = new Dictionary<int, Blog>();

        // Add a blog with id
        public void AddBlog(Blog blog)
        {
            _blogRepo.TryAdd(blog.Id, blog);
        }

        // Delete a blog by id and out delete blog
        public bool DeleteBlog(int blogId, out Blog deleteBlog)
        {
            return _blogRepo.Remove(blogId, out deleteBlog);
        }

        // Update a blog by id, if it contains a valid id
        public void UpdateBlog(int id, Blog blog)
        {
            if (_blogRepo.ContainsKey(id))
            {
                _blogRepo[id] = blog;
            }
        }

        // Finding a blog by id, if it contains a valid id
        // If blog id is invalid, return null
        public Blog GetBlogById(int id)
        {
            if (_blogRepo.ContainsKey(id))
            {
                return _blogRepo[id];
            }
            return null;
        }
        // Finding a blog by type, and return a list of blogs by that type


           public List<Blog> GetBlogByEnum(BlogType blogEnum)
            {
                List<Blog> reault = new List<Blog>(); //create list of the results
                //goes through ever BlogItem and check if the BlogType is the same as the searched type
                foreach (Blog b in _blogRepo.Values)
                {
                    if (b.Type == blogEnum)
                        reault.Add(b);
                }
                return reault;
            }
        
    }
}
