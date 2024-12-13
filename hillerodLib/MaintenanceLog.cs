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

        public void AddReport(DamageReport report)
        {
            _log.TryAdd(report.Id, report);
        }

        public bool DeleteReport(int id, out DamageReport report)
        {
            return _log.Remove(id, out report);
        }

        public bool UpdateReport(int id, DamageReport report)
        {
            if (_log.ContainsKey(id))
            {
                _log[id].Id = report.Id;
                _log[id].Date = report.Date;
                _log[id].Description = report.Description;
                return true;
            }
            else
                return false;
        }

        public DamageReport FindReportById(int id)
        { 
            _log.TryGetValue(id, out DamageReport report);
            return report;
        }


    }
}
