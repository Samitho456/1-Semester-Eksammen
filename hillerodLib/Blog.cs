using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Blog
    {
        private Dictionary<int, BlogItem> _blogRepo = new Dictionary<int, BlogItem>();

        // Add a blog with id
        public void AddBlog(BlogItem blog)
        {
            _blogRepo.TryAdd(blog.Id, blog);
        }

        // Delete a blog by id and out delete blog
        public bool DeleteBlog(int blogId, out BlogItem deleteBlog)
        {
            return _blogRepo.Remove(blogId, out deleteBlog);
        }

        // Update a blog by id, if it contains a valid id
        public void UpdateBlog(int id, BlogItem blog)
        {
            if (_blogRepo.ContainsKey(id))
            {
                _blogRepo[id] = blog;
            }
        }

        // Finding a blog by id, if it contains a valid id
        // If blog id is invalid, return null
        public BlogItem GetBlogById(int id)
        {
            if (_blogRepo.ContainsKey(id))
            {
                return _blogRepo[id];
            }
            return null;
        }
            // Finding a blog by type, and return a list of blogs by that type


           public List<BlogItem> GetBlogByEnum(BlogType blogEnum)
            {
                List<BlogItem> reault = new List<BlogItem>(); //create list of the results
                //goes through ever BlogItem and check if the BlogType is the same as the searched type
                foreach (BlogItem b in _blogRepo.Values)
                {
                    if (b.Type == blogEnum)
                        reault.Add(b);
                }
                return reault;
            }
        
    }
}
