using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class MemberRepo
    {
        private  Dictionary<int, Member> Repo = new Dictionary<int, Member>();

        public MemberRepo() { }

        public void CreateMember(Member member)
        {
            Repo.Add(member.Id, member);
        }

        public Member FindMemberById(int id) 
        {
            Repo.TryGetValue(id, out Member member);
            return member;
        }

        public List<Member> FilterMembersByName(string name)
        {
            string filterName = name.ToLower().Trim();
            List<Member> members = new List<Member>();
            foreach (Member member in Repo.Values)
            {
                if (member.Name.ToLower().Trim() == filterName)
                {
                    members.Add(member);
                }
            }
            return members;
        }

        public List<Member> GetAllMembers()
        {
            return Repo.Values.ToList();
        }

        public void UpdateMember(int id, Member member)
        {
            if (Repo.ContainsKey(id))
            {
                Repo[id] = member;
            }
        }

        public Member DeleteMember(int id) { 
            Repo.TryGetValue(id, out Member member);
            Repo.Remove(id);
            return member;
            }
    }
}
