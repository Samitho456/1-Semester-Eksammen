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
        // Throws an Exception if a Member with the same ID already exists.
        public void CreateMember(Member member)
        {
            if(!_repo.TryAdd(member.Id, member))
                throw new BadMember.DuplicateMember($"A Member with ID {member.Id} already exists.");

        }

        // Find a Member by the members Id and return the member object
        // Throws an exception if the argument ID is invalid.
        public Member FindMemberById(int id) 
        {
            if (!_repo.TryGetValue(id, out Member member))
                throw new BadMember.FaultyId($"A Member with ID {id} doesn't exist.");
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
        // 
        public List<Member> GetAllMembers()
        {
            return _repo.Values.ToList();
        }

        // Updates a member with given Id to a new member
        // Ensures arguments are valid using the FindMemberById method
        // Deletes the old member and adds the new one, ensuring that every object's key is equal to the object's ID.
        public bool UpdateMember(int id, Member updatedMember)
        {
            FindMemberById(id);
            Member oldMember = FindMemberById(id);
            DeleteMember(id,out oldMember);
            CreateMember(updatedMember);
            return true;
        }

        //deletes member by the given Id and returns a bool with an out of the deleted member
        //Ensures valid arguments using the FIndMemberById method.
        public bool DeleteMember(int id, out Member member)
        {
            FindMemberById(id);
            return _repo.Remove(id, out member);
        }
    }
}
