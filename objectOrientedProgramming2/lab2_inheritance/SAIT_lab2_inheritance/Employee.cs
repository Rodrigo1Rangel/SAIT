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

    internal abstract class Employee // Parent of: Salaried, PartTime, Wages
    {
        // -------------------------- FIELDS --------------------------

        private string _id;
        private string _name;       
        private string _address;        
        private string _phone;       
        private long _sin;       
        private string _dob;
        private string _dept;
        private double _weeklyPayment;

        // -------------------------- PROPERTIES --------------------------
        public string Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public long Sin { get { return _sin; } set { _sin = value; } }
        public string Dob { get { return _dob; } set { _dob = value; } }
        public string Dept { get { return _dept; } set { _dept = value; } }
        public double WeeklySalary { get { return _weeklyPayment; } set { _weeklyPayment = value; } }

        // ------------------------ CONSTRUCTORS ------------------------

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
        
        // -------------------------- METHODS --------------------------

        public abstract override string ToString();
        public abstract double GetPay();

    }
}
