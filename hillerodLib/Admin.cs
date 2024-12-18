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
        // The following methods makes use of the existing methods within the objects, and gives the admin the methods needed for CRUD.
        public Event AddEventInRepo(Event newEvent, EventRepo eventRepo )
        {
            eventRepo.AddEvent(newEvent);
            return newEvent;
        }

        // Deletes Event in EventRepo
        public Event DeleteEventInRepo(int id, Event badEvent, EventRepo eventRepo )
        {
            eventRepo.DeleteEvent(id, out badEvent);
            return badEvent;
        }

        // Updates Event in EventRepo
        public Event UpdateEventInRepo(int id, Event updatedEvent, EventRepo eventRepo)
        {

            eventRepo.UpdateEvent(id, updatedEvent);
            return updatedEvent;
        }

        // Add Boat to BoatRepo
        public Boat AddBoatInRepo(Boat newBoat, BoatRepo boatRepo)
        {
            boatRepo.AddBoat(newBoat);
            return newBoat;
        }

        // Updated Boat in BoatRepo
        public Boat UpdateBoatInRepo(int id, Boat updatedBoat, BoatRepo boatRepo)
        {
            boatRepo.UpdateBoat(id, updatedBoat);
            return updatedBoat;
        }

        // Deletes Boat in BoatRepo
        public Boat DeleteBoatInRepo(int id, Boat badBoat, BoatRepo boatRepo)
        {
            boatRepo.DeleteBoat(id, out badBoat);
            return badBoat;
        }

        // Adds Member to MemberRepo
        public Member AddMemberInRepo(Member newMember, MemberRepo memberRepo)
        {
            memberRepo.CreateMember(newMember);
            return newMember;
        }

        // Deletes Member in MemberRepo
        public Member DeleteMemberInRepo(int id, Member badMember, MemberRepo memberRepo)
        {
            memberRepo.DeleteMemberById(badMember.Id);
            return badMember;
        }

        // Updates Member in MemberRepo
        public Member UpdateMemberInRepo(int id, Member updatedMember, MemberRepo memberRepo)
        {
            memberRepo.UpdateMember(id,updatedMember);
            return updatedMember;
        }

        // Add DamageReport to Maintenance log
        public DamageReport AddDamageReportInLog(Boat boat, DamageReport report)
        {
            boat.MaintenanceLog.AddReport(report);
            boat.IsAvailable = false;
            return report;
        }

        // Updated DamageReport in Maintenance log
        public DamageReport UpdateDamageReportInLog(int id, Boat boat, DamageReport report)
        {
            boat.MaintenanceLog.UpdateReport(id, report);
            return report;
        }

        // Deletes DamageReport in Maintenance log
        public DamageReport DeleteDamageReportInLog(int id, Boat boat, DamageReport report)
        {
            boat.MaintenanceLog.DeleteReport(id,out report);
            return report;
        }

        // ??????
        public DamageReport FindDamageReportInLog(Boat boat, DamageReport report)
        {
           return boat.MaintenanceLog.FindReportById(report.Id);
        }

        // Boat has returned from trip and is ready to be booked again
        public bool BoatIsHome(Boat boat)
        {
            if (boat == null)
            {
                return false;
            }       
            return boat.IsAvailable = true;
        }

        // Tostring
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, IsAdmin: {IsAdmin}, Email: {Email}, PhoneNumber: {PhoneNumber} ";
        }        
    }
}
