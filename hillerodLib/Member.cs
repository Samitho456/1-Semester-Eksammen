using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Member : User
    {
        public Member(int id, string name, string email, string phonenumber) : base (id,  name, email, phonenumber)
        { 
            IsAdmin = false;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, IsAdmin: {IsAdmin}, Email: {Email}, PhoneNumber: {PhoneNumber} ";
        }
    }
}
