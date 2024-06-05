using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIT_lab2_inheritance
{

    internal class Salaried : Employee
    {

        // ------------------------ CONSTRUCTORS ------------------------
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double weeklySalary) : base(id, name, address, phone, sin, dob, dept, weeklySalary)
        {
            WeeklySalary = weeklySalary;
        }

        // -------------------------- METHODS --------------------------
        public override string ToString()
        {
            return $"Employee data:\n\nID: {Id}\nName: {Name}\nAddress: {Address}]=\nPhone: {Phone}]=\nSIN: {Sin}\nDate of Birth: {Dob}\nDepartment: {Dept}\nContract Category: Salaried\nWeekly Salary: {WeeklySalary}\n";
        }
        public override double GetPay()
        {
            return WeeklySalary;
        }
    }
}
