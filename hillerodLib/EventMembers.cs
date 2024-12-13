namespace hillerodLib
{
    public class EventMembers
    {
        public List<Member> Members { get; } = new List<Member>();
        public Event CurrentEvent { get; }
        public int MaxAmount { get; set; }
        
        public EventMembers()
        {
            MaxAmount = 99999999;
        }

        public EventMembers(int max)
        {
            MaxAmount = max;
        }

        public bool AddEventMember(Member member)
        {
            if(!Members.Contains(member) && Members.Count < MaxAmount)
            {
                Members.Add(member);
                return true;
            }
            return false;
        }


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

        public Member FindMember(int id)
        {
            Member FoundMember = null;
            foreach(Member member in Members)
            {
                if(member.Id == id) FoundMember = member;
            }
            return FoundMember;
        }
    }
}
