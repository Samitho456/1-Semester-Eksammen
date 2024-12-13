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

        // Så man kan tilføje en blog
        public void AddBlog(Blog blog)
        {
            _blogList.TryAdd(blog.Id, blog);
        }

        // Så man kan slette en blog
        public bool DeleteBlog(int blogId, out Blog deleteBlog)
        {
            return _blogList.Remove(blogId, out deleteBlog);
        }

        // Så man kan opdatere en blog
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

        // Så man kan finde en blog på Id nummer

        public Blog GetBlogById(int id)
        {
            if (_blogList.ContainsKey(id))
            {
                return _blogList[id];
            }
            return null;
        }
            // Så man kan finde blogs ud fra type


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
