﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hillerodLib
{
    public class DamageReport
    {
        // Properties
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        // Constructor
        public DamageReport(string date, string description) 
        {
            Id = _nextId++;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"Id: {Id}" + " " + "\n" + $"Date: {Date}" + " " + "\n" + $"Description: {Description} ";
        }

    }
}
