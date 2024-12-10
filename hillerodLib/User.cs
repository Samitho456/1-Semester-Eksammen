using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    // Constructor
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        protected User(int id, string name, string email, string phonenumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phonenumber;
        }
    }
}
