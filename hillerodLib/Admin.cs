using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Admin : User

    {
        public Admin(int id, string name, string email, string phonenumber) : base (id, name, email, phonenumber) 
        {
            IsAdmin = true;
        }
    
        public Event AddEventInRepo(Event newEvent, EventRepo eventRepo )
        {
            eventRepo.AddEvent(newEvent);
            return newEvent;
        }

        public Event DeleteEventInRepo(Event badEvent, EventRepo eventRepo )
        {
            eventRepo.DeleteEvent(badEvent.Id, out badEvent);
            return badEvent;
        }

        public Event UpdateEventInRepo(int id, Event updatedEvent, EventRepo eventRepo)
        {

            eventRepo.UpdateEvent(id, updatedEvent);
            return updatedEvent;
        }

        public Boat AddBoatInRepo(Boat newBoat, BoatRepo boatRepo)
        {
            boatRepo.AddBoat(newBoat);
            return newBoat;
        }

        public Boat DeleteBoatInRepo(Boat badBoat, BoatRepo boatRepo)
        {
            boatRepo.DeleteBoat(badBoat.Id,out badBoat);
            return badBoat;
        }

        public Boat UpdateBoatInRepo(Boat updatedBoat, BoatRepo boatRepo)
        {
            boatRepo.UpdateBoat( updatedBoat.Id, updatedBoat);
            return updatedBoat;
        }

        public Member AddMemberInRepo(Member newMember, MemberRepo memberRepo)
        {
            memberRepo.CreateMember(newMember);
            return newMember;
        }

        public Member DeleteMemberInRepo(Member badMember, MemberRepo memberRepo)
        {
            memberRepo.DeleteMember(badMember.Id,out badMember);
            return badMember;
        }

        public Member UpdateMemberInRepo(Member updatedMember, MemberRepo memberRepo)
        {
            memberRepo.UpdateMember(updatedMember.Id,updatedMember);
            return updatedMember;
        }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, IsAdmin: {IsAdmin}, Email: {Email}, PhoneNumber: {PhoneNumber} ";
        }

        
    }


}
