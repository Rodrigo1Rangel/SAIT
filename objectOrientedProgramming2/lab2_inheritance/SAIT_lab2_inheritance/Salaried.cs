using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIT_lab2_inheritance
{
    internal class Salaried : Employee
    {
        private double _salary;
        public double Salary { get { return _salary; } set { _salary = value; } }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {

        }
    }
}
