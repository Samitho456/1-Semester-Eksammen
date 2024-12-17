using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Boat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BoatType Type { get; set; }
        public string Model { get; set; }
        public string SailNumber { get; set; }
        public string Engine { get; set; }
        public int Measures { get; set; }
        public string BuildingYear { get; set; }
        public MaintenanceLog MaintenanceLog { get; set; }

        public Boat (int id, string name, BoatType type, string model, string sailNumber, string engine, int measures, string buildYear)
        {
            Id = id;
            Name = name;
            Type = type;
            Model = model;
            SailNumber = sailNumber;
            Engine = engine;
            Measures = measures;
            BuildingYear = buildYear;
            MaintenanceLog = new MaintenanceLog();
        }

        public DamageReport AddDamageReport(DamageReport report)
        {
            MaintenanceLog.AddReport(report);
            return report;

        }

        public DamageReport UpdateDamageReport(DamageReport report)
        {
            MaintenanceLog.UpdateReport(report.Id, report);
            return report;

        }

        public DamageReport DeleteDamageReport(DamageReport report)
        {
            MaintenanceLog.DeleteReport(report.Id, out report);
            return report;
        }

        public override string ToString()
        {
            return ($"Id: {Id}" + " " + "\n" + $"Name: {Name}" + "\n" + $"Type: {Type}" + "\n" + $"Model: {Model}" + "\n" 
                + $"Sail Number: {SailNumber}" + "\n" + $"Engine: {Engine}" + "\n" + $"Measures: {Measures}" + "\n" + $"Build year: {BuildingYear}");
        }
    }
}
