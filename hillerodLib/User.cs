using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public abstract class User
    {
        // properties
        public static int NextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor
        protected User(string name, string email, string phonenumber)
        {
            Id = NextId++;
            Name = name;
            Email = email;
            PhoneNumber = phonenumber;
        }
    }
}
