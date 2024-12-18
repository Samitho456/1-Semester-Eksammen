using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Admin : User

    {   // Creates the Admin class that inherits from the User base class, only changing IsAdmin to true
        public Admin(string name, string email, string phonenumber) : base (name, email, phonenumber) 
        {
            IsAdmin = true;
        }

        // ToString
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, IsAdmin: {IsAdmin}, Email: {Email}, PhoneNumber: {PhoneNumber} ";
        }        
    }
}
