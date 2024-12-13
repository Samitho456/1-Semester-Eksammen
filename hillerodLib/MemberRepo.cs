using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class MemberRepo
    {
        private  Dictionary<int, Member> _repo = new Dictionary<int, Member>();

        // Constructor
        public MemberRepo() { }

        // Add a member to Dictionary
        // Key is the Members Id and value is the member
        public void CreateMember(Member member)
        {
            _repo.Add(member.Id, member);
        }

        // Find a Member by the members Id and return the member object
        public Member FindMemberById(int id) 
        {
            _repo.TryGetValue(id, out Member member);
            return member;
        }

        // Gets a list of all the members with a given name
        public List<Member> FilterMembersByName(string name)
        {
            string filterName = name.ToLower().Trim();
            List<Member> members = new List<Member>();
            foreach (Member member in _repo.Values)
            {
                if (member.Name.ToLower().Trim() == filterName)
                {
                    members.Add(member);
                }
            }
            return members;
        }

        // Returns a List of all members
        public List<Member> GetAllMembers()
        {
            return _repo.Values.ToList();
        }

        // Updates a member with given Id to a new member
        public bool UpdateMember(int id, Member updatedMember)
        {
            if (_repo.ContainsKey(id))
            {
                _repo[id].Name = updatedMember.Name;
                _repo[id].Id = updatedMember.Id;
                _repo[id].Email = updatedMember.Email;
                _repo[id].PhoneNumber = updatedMember.PhoneNumber;
                _repo[id].IsAdmin = updatedMember.IsAdmin;
                return true;
            }
            return false;
        }

        //deletes member by the given Id and returns a bool with an out of the deleted member
        public bool DeleteMember(int id, out Member member)
        {
            return _repo.Remove(id, out member);
        }
    }
}
