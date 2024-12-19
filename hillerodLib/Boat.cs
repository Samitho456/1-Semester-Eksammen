using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Boat
    {
        // Properties
        private static int _nextId = 1;
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
        public Boat (string name, BoatType type, string model, string sailNumber, string engine, int measures, string buildYear)
        {
            Id = _nextId++;
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
        public DamageReport DeleteDamageReport(DamageReport report)
        {
            MaintenanceLog.DeleteReport(report.Id);
            return report;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Type: {Type}, IsAvailable: {IsAvailable}, Model: {Model}, Sail Number: {SailNumber}, Engine: {Engine}, Measures: {Measures}, Build year: {BuildingYear}";
        }
    }
}
