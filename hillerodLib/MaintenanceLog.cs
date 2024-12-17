using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class MaintenanceLog
    {
        private Dictionary<int, DamageReport> _log = new Dictionary<int, DamageReport>();

        public MaintenanceLog() { }
        //Adds a Damage Report to the Maintenance log. 
        // Throws an exception if the argument is invalid. 
        public void AddReport(DamageReport report)
        {
            if (!_log.TryAdd(report.Id, report))
            {
                throw new BadReport.DuplicateReport($"A report with ID {report.Id} already exists.");
            }
        }

        //Deletes a report from the Maintenance Log.
        //Ensures valid arguments using the FindReportById method. 
        public bool DeleteReport(int id, out DamageReport report)
        {
            FindReportById(id);
            return _log.Remove(id, out report);
        }

        //Updates a report to a new one.
        //Ensures valid arguments using the FindReportById method
        // Old report is deleted and a new one is added, ensuring that the object's key is always the same as the object's id. 
        public bool UpdateReport(int id, DamageReport report) 
        { 
            DamageReport oldReport = FindReportById(id);
            DeleteReport(id,out oldReport);
            AddReport(report);
            return true;

        }
        // A method to filter logs by date. 
        public List<DamageReport> FilterLogsByDate(string date)
        {
            string FilterName = date.ToLower().Trim();
            List<DamageReport> reports = new List<DamageReport>();
            foreach (var report in _log.Values)
            {
                if (report.Date.ToLower().Trim() == FilterName)
                {
                    reports.Add(report);
                }
            }
            return reports;
            
        }
        //Returns a list of all reports in the Maintenance Log.
        public List<DamageReport> GetAllReports()
        {
            List<DamageReport> reports = new List<DamageReport>();
            foreach (var e in _log)
            {
                reports.Add(e.Value);
            }
            return reports;
        }
        // Finds a report based on id.
        // Throws an exception if argument is invalid.
        public DamageReport FindReportById(int id)
        {
            if (!_log.ContainsKey(id))
            {
                throw new BadReport.FaultyIdReport($"No report found with ID {id}");
            }
            return _log[id];
        }


    }
}
