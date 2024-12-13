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
        public Member(int id, string name, string email, string phonenumber) : base (id,  name, email, phonenumber)
        { 
            IsAdmin = false;
        }

        public DamageReport AddDamageReport(Boat boat, DamageReport report)
        {
            boat.MaintenanceLog.AddReport(report);
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
