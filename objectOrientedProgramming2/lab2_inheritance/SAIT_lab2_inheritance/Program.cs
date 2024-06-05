using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAIT_lab2_inheritance.EmployeeCategory;
using System.IO;
using SAIT_lab2_inheritance.Properties;
using System.Xml.Linq;
using System.ComponentModel;

namespace SAIT_lab2_inheritance
{
    internal class Program
    {
        static private EmployeeContractCategory _contractCategory;
        static public EmployeeContractCategory ContractCategory { get { return _contractCategory; } set { _contractCategory = value; } }

        static private List<Employee> _employeeList = new List<Employee>();
        static public List<Employee> EmployeeList { get { return _employeeList; } set { _employeeList = value; } }

        static void Main(string[] args)
        {
            // a. Fill a list with objects based on the supplied data file.
            LoadData();

            // b. Calculate and return the average weekly pay for all employees.
            Console.WriteLine($"The average weekly pay for all employees is: ${AverageWeeklyPay():N}");


        }

        // -------------------------- METHODS --------------------------

        static public List<Employee> LoadData()
        // Fill a list with objects based on the supplied data file.
        {
            // Is "res" a prerequisite to have "Resources" as the parent directory after we added the resource to Visual Studio?
            // C: \Users\rodri\OneDrive\Documents\GitHub\SAIT\objectOrientedProgramming2\lab2_inheritance\SAIT_lab2_inheritance\Resources\employees.txt
            string[] datasetPerLine = Resources.employees.Split('\n');
            foreach (string lineItem in datasetPerLine)
            {
                double weeklySalary;
                long sin;
                double rate;
                double hours;

                char delimiter = ':';
                string[] employeeItems = lineItem.Split(delimiter);
                EmployeeCategory thisContractCategory = new EmployeeCategory(employeeItems[0]);
                ContractCategory = thisContractCategory.getEmployeeContractCategory();

                // Salaried contract check
                if (employeeItems.Length == 8 && ContractCategory == EmployeeContractCategory.Salaried)
                {
                    long.TryParse(employeeItems[4].Trim(), out sin);
                    double.TryParse(employeeItems[7].Trim(), out weeklySalary);
                    Salaried employeePaymentData = new Salaried(employeeItems[0].Trim(), employeeItems[1].Trim(), employeeItems[2].Trim(), employeeItems[3].Trim(), sin, employeeItems[5].Trim(), employeeItems[6].Trim(), weeklySalary);
                    EmployeeList.Add(employeePaymentData);
                }
                // Wages contract check
                else if (employeeItems.Length == 9 && ContractCategory == EmployeeContractCategory.Wages)
                {
                    long.TryParse(employeeItems[4], out sin);
                    double.TryParse(employeeItems[7], out rate);
                    double.TryParse(employeeItems[8], out hours);
                    Wages employeePaymentData = new Wages(employeeItems[0].Trim(), employeeItems[1].Trim(), employeeItems[2].Trim(), employeeItems[3].Trim(), sin, employeeItems[5].Trim(), employeeItems[6].Trim(), rate, hours);
                    EmployeeList.Add(employeePaymentData);
                }
                // PartTime contract check
                else if (employeeItems.Length == 9 && ContractCategory == EmployeeContractCategory.PartTime)
                {
                    long.TryParse(employeeItems[4], out sin);
                    double.TryParse(employeeItems[7], out rate);
                    double.TryParse(employeeItems[8], out hours);
                    PartTime employeePaymentData = new PartTime(employeeItems[0].Trim(), employeeItems[1].Trim(), employeeItems[2].Trim(), employeeItems[3].Trim(), sin, employeeItems[5].Trim(), employeeItems[6].Trim(), rate, hours);
                    EmployeeList.Add(employeePaymentData);
                }
                // ArgumentException when the quantity of paremeters is above or below the expected
                else if (employeeItems.Length < 8)
                {
                    throw new ArgumentException("Employee data is insufficient to register an employee payment in the system.", "Employee data.");
                }
                else if (employeeItems.Length > 9)
                {
                    throw new ArgumentException("More data than expected to register an employee payment in the system was given.", "Employee data.");
                }
            }

            return EmployeeList;
        }

        static public double AverageWeeklyPay()
        // Return the average weekly pay for all employees.
        {
            double totalPayAmount = 0D;
            double averagePayAmount = 0D;
            
            foreach (Employee employee in EmployeeList)
            {
                totalPayAmount += employee.GetPay();
            }
            averagePayAmount = totalPayAmount / EmployeeList.Count;
            return averagePayAmount;
        }
    }
}
