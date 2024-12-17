namespace hillerodLib
{
    public class MemberRepo
    {
        private List<Member> _repo = new List<Member>();

        // Constructor
        public MemberRepo() { }

        // Add a member to Dictionary
        public void CreateMember(Member member)
        {
            _repo.Add(member);
        }

        // Find a Member by the members Id and return the member object
        public Member FindMemberById(int id)
        {
            Member foundMember = null;
            foreach (Member member in _repo)
            {
                if (member.Id == id)
                    foundMember = member;
            }
            return foundMember;

        }

        // Gets a list of all the members with a given name
        public List<Member> FilterMembersByName(string name)
        {
            string filterName = name.ToLower().Trim();
            List<Member> members = new List<Member>();
            foreach (Member member in _repo)
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
            return _repo;
        }

        // Updates a member with given Id to a new member. returns true if update was succesful
        public bool UpdateMember(int id, Member updatedMember)
        {
            foreach (Member member in _repo)
            {
                if (member.Id == id)
                {

                    member.Id = updatedMember.Id;
                    member.Name = updatedMember.Name;
                    member.Email = updatedMember.Email;
                    member.PhoneNumber = updatedMember.PhoneNumber;
                    return true;
                }
            }
            return false;
        }

        //deletes member by the given Id and returns a bool. returns true if delete was succesful
        public bool DeleteMemberById(int id)
        {
            foreach (Member m in _repo)
            {
                if (m.Id == id)
                {
                    _repo.Remove(m);
                    return true;
                }
            }
            return false;
        }
    }
}
