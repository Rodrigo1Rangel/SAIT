using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SAIT_lab2_inheritance.EmployeeCategory;

namespace SAIT_lab2_inheritance
{

    internal abstract class Employee // children: Salaried, PartTime, Wages
    {

        private string _id;
        public string Id { get { return _id; } set { _id = value; } }
        
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        
        private string _address;
        public string Address { get { return _address; } set { _address = value; } }
        
        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; } }
        
        private long _sin;
        public long Sin { get { return _sin; } set { _sin = value; } }
        
        private string _dob;
        public string Dob { get { return _dob; } set { _dob = value; } }

        private string _dept;
        public string Dept { get { return _dept; } set { _dept = value; } }

        private double _weeklyPayment;
        public double WeeklySalary { get { return _weeklyPayment; } set { _weeklyPayment = value; } }


        // ------------------------ CONSTRUCTORS ------------------------

        /* Vanilla Employee constructor
        public Employee (string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
        }
        */

        // Salaried contract constructor
        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept, double weeklySalary)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
        }

        // Wages or PartTime contract constructor
        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
        }


        // -------------------------- METHODS --------------------------

        public abstract override string ToString();
        public abstract double GetPay();

    }
}
