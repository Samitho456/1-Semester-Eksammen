using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hillerodLib.Enums;
using hillerodLib.Services.Repos;

namespace hillerodLib.Models
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
        public bool IsAvailable { get; set; }
        public MaintenanceLog MaintenanceLog { get; set; }

        // Constructor
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
            IsAvailable = true;
        }

        //Uses the DamageReport Class Methods to perform Crud operations on its maintenance log
        public DamageReport AddDamageReport(DamageReport report)
        {
            MaintenanceLog.AddReport(report);
            IsAvailable = false;
            return report;
        }

        // Updated DamageReport using the old report Id and the new updated report
        // Updates DamageReport with a given id, with a new damageReport
        public DamageReport UpdateDamageReport(int id, DamageReport report)
        {
            MaintenanceLog.UpdateReport(id, report);
            return report;
        }

        // Deletes DamageReport with the given Id and outputs the deleted report
        public DamageReport DeleteDamageReport(int id, out DamageReport report)
        {
            MaintenanceLog.DeleteReport(id, out report);
            return report;
        }

        public override string ToString()
        {
            return $"Id: {Id}" + " " + "\n" + $"Name: {Name}" + "\n" + $"Type: {Type}" + "\n" + $"Model: {Model}" + "\n"
                + $"Sail Number: {SailNumber}" + "\n" + $"Engine: {Engine}" + "\n" + $"Measures: {Measures}" + "\n" + $"Build year: {BuildingYear}";
        }
    }
}
