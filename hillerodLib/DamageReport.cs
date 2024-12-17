using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hillerodLib
{
    public class DamageReport
    {
        public int Id { get; set; }
        public string Date { get; set; }

        public string Description { get; set; }
        public DamageReport(int id, string date, string description) 
        {
            Id = id;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"Id: {Id}" + " " + "\n" + $"Date: {Date}" + " " + "\n" + $"Description: {Description} ";
        }

    }
}
