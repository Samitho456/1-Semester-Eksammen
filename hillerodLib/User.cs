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
        private static  int _id = 1;
        public int Id { get; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        protected User(string name, string email, string phonenumber)
        {
            Id = _id;
            Name = name;
            Email = email;
            PhoneNumber = phonenumber;
            _id++;
        }
    }
}
