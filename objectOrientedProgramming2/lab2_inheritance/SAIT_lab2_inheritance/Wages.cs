using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIT_lab2_inheritance
{
    internal class Wages : Employee
    {
        private double _rate;
        public double Rate { get { return _rate; } set { _rate = value; } }

        private double _hours;
        public double Hours { get { return _hours; } set { _hours = value; } }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {

        }
    }
}
