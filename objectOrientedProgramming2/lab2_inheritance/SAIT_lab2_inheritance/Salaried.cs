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

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double weeklySalary) : base(id, name, address, phone, sin, dob, dept)
        {
            Id = id.Trim();
            Name = name.Trim();
            Address = address.Trim();
            Phone = phone.Trim();
            Sin = sin;
            Dob = dob.Trim();
            Dept = dept.Trim();

            // Calculate payment
            WeeklyPayment = weeklySalary;
        }
        public override double getPay()
        {
            return this.WeeklyPayment;
        }
    }
}
