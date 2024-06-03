using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SAIT_lab2_inheritance
{
    internal class PartTime : Employee
    {
        private double _rate;
        public double Rate { get { return _rate; } set { _rate = value; } }

        private double _hours;
        public double Hours { get { return _hours; } set { _hours = value; } }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            // PartTime employees have ID numbers starting with 8-9


            // Calculate payment
            Rate = rate;
            Hours = hours;
            WeeklyPayment = Rate * Hours;

        }
        public double getPay()
        {
            return this.WeeklyPayment;
        }
    }
}
