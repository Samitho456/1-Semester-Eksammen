namespace hillerodLib
{
    public class EventMembers
    {
        public List<Member> Members { get; } = new List<Member>();
        public Event CurrentEvent { get; }
        public int MaxAmount { get; set; }
        
        // Constructor without max amount of members
        public EventMembers()
        {
            MaxAmount = 99999999;
        }

        // Constructor with max amount of members
        public EventMembers(int max)
        {
            MaxAmount = max;
        }

        // Addsmember if the member is not already a part of event and if there is space for the new member
        // Return true if member is added 
        public bool AddMember(Member member)
        {
            if (!Members.Contains(member) && Members.Count < MaxAmount)
            {
                Members.Add(member);
                return true;
            }
            return false;
        }

        // Deletes member with the given Id
        public bool DeleteEventMember(int id)
        {
            foreach (Member member in Members)
            {
                if (member.Id == id)
                {
                    Members.Remove(member);
                    return true;
                }
            }
            return false;
        }

        // Updates member with the given Id
        public bool UpdateEventMember(int id, Member UpdatedMember)
        {
            foreach (Member member in Members)
            {
                if (member.Id == id)
                {
                    member.Id = UpdatedMember.Id;
                    member.Name = UpdatedMember.Name;
                    member.Email = UpdatedMember.Email;
                    member.PhoneNumber = UpdatedMember.PhoneNumber;
                    return true;
                }
            }
            return false;
        }

        // Finds member with the given Id
        public Member FindMember(int id)
        {
            Member FoundMember = null;
            foreach (Member member in Members)
            {
                if (member.Id == id) FoundMember = member;
            }
            return FoundMember;
        }
    }
}
