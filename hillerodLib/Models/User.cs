using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib.Models
{
    // Constructor
    public abstract class User
    {

        public static int NextId = 1;
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        protected User(string name, string email, string phonenumber)
        {
            Id = NextId++;
            Name = name;
            Email = email;
            PhoneNumber = phonenumber;
        }
    }
}
