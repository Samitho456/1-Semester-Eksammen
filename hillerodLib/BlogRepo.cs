using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class BlogRepo
     
    {
        private Dictionary<int, Blog> _blogList = new Dictionary<int, Blog>();

        // Add a blog with id
        public void AddBlog(Blog blog)
        {
            _blogList.TryAdd(blog.Id, blog);
        }

        // Delete a blog by id and out delete blog
        public bool DeleteBlog(int blogId, out Blog deleteBlog)
        {
            return _blogList.Remove(blogId, out deleteBlog);
        }

        // Update a blog by id, if it contains a valid id
        public void UpdateBlog(int id, Blog blog)
        {
            if (_blogList.ContainsKey(id))
            {
                _blogList[id].Id = blog.Id;
                _blogList[id].Name = blog.Name;
                _blogList[id].Description = blog.Description;
                _blogList[id].Type = blog.Type;
                
            }
        }

        // Finding a blog by id, if it contains a valid id
        // If blog id is invalid, return null

        public Blog GetBlogById(int id)
        {
            if (_blogList.ContainsKey(id))
            {
                return _blogList[id];
            }
            return null;
        }
            // Finding a blog by type, and return a list of blogs by that type


           public List<Blog> GetBlogByEnum(BlogType blogEnum, Blog blog)
            {
                List<Blog> list = new List<Blog>();

                foreach (KeyValuePair<int, Blog> kvp in _blogList)
                {
                    Blog Blog = kvp.Value;
                    if (blog.Type == blogEnum)
                        list.Add(blog);
                }
                return list;
            }
        
    }
}
