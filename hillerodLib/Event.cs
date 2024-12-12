using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Event
    {
        //private List<Member> _memberJoin = new List<Member>();
        

        // Creating propertys
        private static int nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public List<Member> MemberJoined { get; private set; }



        // Creating the constructors 
        public Event(string name, DateTime dateStart, DateTime dateEnd, string description)
        {
            Id = nextId++;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Description = description;
            MemberJoined = new List<Member>();
        }


        public void MemberJoin(Member m)
        {
            MemberJoined.Add(m);
        }

        public bool MemberDeletedFromList(int id)
        {
            foreach (var m in MemberJoined)
            {
                if (m.Id == id)
                {
                    return MemberJoined.Remove(m);
                }
            }
            return false;
        }

        // overriding ToString to creat our own ToString
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Date Start : {DateStart}, Date End : {DateEnd}, Description: {Description}";
        }
    }
}

