using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIT_lab2_inheritance
{
    internal class Wages : Employee
    {
        // --------------------------- FIELDS ---------------------------

        private double _rate;
        private double _hours;
        private float _OVERTIMEPAYMENTRATE = 1.5F;
        private float _OVERTIMEHOURTHRESHOLD = 40; 

        // ------------------------- PROPERTIES -------------------------
        public double Rate { get { return _rate; } set { _rate = value; } }
        public double Hours { get { return _hours; } set { _hours = value; } }
        public float OVERTIMEPAYMENTRATE { get { return _OVERTIMEPAYMENTRATE; } set { _OVERTIMEPAYMENTRATE = value; } }
        public float OVERTIMEHOURTHRESHOLD { get { return _OVERTIMEHOURTHRESHOLD; } set { _OVERTIMEHOURTHRESHOLD = value; } }

        // ------------------------ CONSTRUCTORS ------------------------
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            Rate = rate;
            Hours = hours;
        }

        // -------------------------- METHODS --------------------------
        public override string ToString()
        {
            return $"Employee data:\n\nID: {Id}\nName: {Name}\nAddress: {Address}]=\nPhone: {Phone}]=\nSIN: {Sin}\nDate of Birth: {Dob}\nDepartment: {Dept}\nContract Category: Wages\nHours worked: {Hours}\nHour rate: {Rate}\n";
        }
        public override double GetPay()
        {
            // Calculate payment
            if (Hours > OVERTIMEHOURTHRESHOLD)
            {
                WeeklySalary = Rate * OVERTIMEHOURTHRESHOLD + (Hours - OVERTIMEHOURTHRESHOLD) * Rate * OVERTIMEPAYMENTRATE;
            }
            else
            {
                WeeklySalary = Rate * Hours;
            }
            return WeeklySalary;
        }
    }
}
