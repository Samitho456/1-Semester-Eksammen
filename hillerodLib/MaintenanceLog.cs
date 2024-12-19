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

        // Constructor
        public MaintenanceLog() { }

        // Adds a Damage Report to the Maintenance log
        public void AddReport(DamageReport report)
        {
            // Throws an exception if the argument is invalid 
            if (!_log.TryAdd(report.Id, report))
            {
                throw new BadReport.DuplicateReport($"A report with ID {report.Id} already exists.");
            }
        }

        // Deletes a report from the Maintenance Log
        public bool DeleteReport(int id)
        {
            // Ensures valid arguments using the FindReportById method
            DamageReport report = FindReportById(id);
            return _log.Remove(id, out report);
        }

        // Updates a report to a new one
        public bool UpdateReport(int id, DamageReport report) 
        {
            // Ensures valid arguments using the FindReportById method
            FindReportById(id); // Throws exeption if no Report found
            report.Id = id; // Change new report Id to old Id
            _log[id] = report; // Update oldReport to new report
            return true;
        }

        // A method to filter logs by date. 
        public List<DamageReport> FilterLogsByDate(string date)
        {
            string FilterName = date.ToLower().Trim(); // Change search Word to lower and remove whitespace

            List<DamageReport> reports = new List<DamageReport>(); // Create List to add results to

            // Goes through ever Damage Report
            foreach (var report in _log.Values)
            {
                // check if searchword matches date on DamageReport
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
            return _log.Values.ToList();
        }

        // Finds a report based on id.
        public DamageReport FindReportById(int id)
        {
            // Throws an exception if argument is invalid.
            if (!_log.ContainsKey(id))
            {
                throw new BadReport.FaultyIdReport($"No report found with ID {id}");
            }
            return _log[id];
        }


    }
}
