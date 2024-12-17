using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Member : User
    {
        // Constructor
        public Member(string name, string email, string phonenumber) : base (name, email, phonenumber)
        { 
            IsAdmin = false;
        }

        public DamageReport AddDamageReport(Boat boat, DamageReport report)
        {
            boat.MaintenanceLog.AddReport(report);
            boat.IsAvailable = false;
            return report;
        }

        public DamageReport UpdateDamageReport(Boat boat, DamageReport report)
        {
            boat.MaintenanceLog.UpdateReport(report.Id, report);
            return report;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, IsAdmin: {IsAdmin}, Email: {Email}, PhoneNumber: {PhoneNumber} ";
        }
    }
}
