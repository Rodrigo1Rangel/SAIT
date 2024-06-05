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

    internal class Employee // children: Salaried, PartTime, Wages
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
        public double WeeklyPayment { get { return _weeklyPayment; } set { _weeklyPayment = value; } }

        private EmployeeContractCategory _contractCategory;
        public EmployeeContractCategory ContractCategory { get { return _contractCategory; } set { _contractCategory = value; } }


        // CONSTRUCTORS


        // Vanilla Employee constructor
        public Employee (string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            Id = id.Trim();
            Name = name.Trim();
            Address = address.Trim();
            Phone = phone.Trim();
            Sin = sin;
            Dob = dob.Trim();
            Dept = dept.Trim();
        }

        // Salaried contract constructor
        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept, double weeklySalary)
        {
            Id = id.Trim();
            Name = name.Trim();
            Address = address.Trim();
            Phone = phone.Trim();
            Sin = sin;
            Dob = dob.Trim();
            Dept = dept.Trim();

            // Employee Category check
            EmployeeCategory thisContractCategory = new EmployeeCategory(id);
            ContractCategory = thisContractCategory.getEmployeeContractCategory();
            if (ContractCategory == EmployeeContractCategory.Salaried)
            {
                Employee employee = new Salaried(id, name, address, phone, sin, dob, dept, weeklySalary);
                Salaried salariedEmployee = (Salaried)employee;
                //employeeList.Add(salariedEmployee);
            }
            else
            // The only Contract Category class that takes 7 parameters is Salaried, so
            // there is no other conditional to be met
            {
                throw new ArgumentException("Employee ID number does not correspond to a Salaried contract.", "Employee ID number.");
            }
        }

        // Wages or PartTime contract constructor
        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            Id = id.Trim();
            Name = name.Trim();
            Address = address.Trim();
            Phone = phone.Trim();
            Sin = sin;
            Dob = dob.Trim();
            Dept = dept.Trim();

            // Employee Category check
            EmployeeCategory thisContractCategory = new EmployeeCategory(id);
            ContractCategory = thisContractCategory.getEmployeeContractCategory();
            if (ContractCategory == EmployeeContractCategory.Wages)
            {
                Employee employee = new Wages(id, name, address, phone, sin, dob, dept, rate, hours);
                Wages salariedEmployee = (Wages)employee;
                //employeeList.Add(salariedEmployee);
            }
            else if (ContractCategory == EmployeeContractCategory.PartTime)
            {
                Employee employee = new PartTime(id, name, address, phone, sin, dob, dept, rate, hours);
                PartTime salariedEmployee = (PartTime)employee;
                //employeeList.Add(salariedEmployee);
            }
            else
            {
                throw new ArgumentException("Employee ID number does not correspond to a Wages or Part-time contract.", "Employee ID number.");
            }
        }


        // METHODS


        public override string ToString()
        {
            return "abc";
        }
        public virtual double getPay()
        {
            return 0D;
        }

    }
}
