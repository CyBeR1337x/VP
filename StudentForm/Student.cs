using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm {
    internal class Student {
        public string RegNo { get; set; }   
        public string Name { get; set; }
        public string Degree { get; set; }
        public DateTime DOB { get; set; }
        public double Age { get; set; }
        public double Percentage { get; set; }
        public string InterDegree { get; set; }
        public bool AidRequired { get; set; }
        public string ImagePath { get; set; }
    }
}
