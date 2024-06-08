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
        // --------------------------- FIELDS ---------------------------

        private double _rate;
        private double _hours;

        // ------------------------- PROPERTIES -------------------------
        public double Rate { get { return _rate; } set { _rate = value; } }
        public double Hours { get { return _hours; } set { _hours = value; } }

        // ------------------------ CONSTRUCTORS ------------------------
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            Rate = rate;
            Hours = hours;
        }

        // -------------------------- METHODS --------------------------
        public override string ToString()
        {
            return $"Employee data:\n\nID: {Id}\nName: {Name}\nAddress: {Address}]=\nPhone: {Phone}]=\nSIN: {Sin}\nDate of Birth: {Dob}\nDepartment: {Dept}\nContract Category: Part-Time\nHours worked: {Hours}\nHour rate: {Rate}\n";
        }
        public override double GetPay()
        {
            // Calculate payment
            WeeklySalary = Rate * Hours;
            return WeeklySalary;
        }
    }
}
