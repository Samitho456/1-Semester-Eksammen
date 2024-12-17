using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BlogType Type { get; set; }
        public Blog(int id, string name, string description, BlogType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;

        }
        public override string ToString()
        {
            return($"Id: { Id}" + "\n" + $"Name: { Name}" + "\n" + $"Description: {Description}" + "\n" + $"Type: {Type}");
        }
    }
}
