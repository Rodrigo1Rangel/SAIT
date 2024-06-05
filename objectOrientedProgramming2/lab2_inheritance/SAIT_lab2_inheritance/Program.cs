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
using static System.Net.Mime.MediaTypeNames;

namespace SAIT_lab2_inheritance
{
    internal class Program
    {
        static private EmployeeContractCategory _contractCategory;
        static public EmployeeContractCategory ContractCategory { get { return _contractCategory; } set { _contractCategory = value; } }

        static private List<Employee> _employeeList = new List<Employee>();
        static public List<Employee> EmployeeList { get { return _employeeList; } set { _employeeList = value; } }

        static private List<Employee> _highestPayingEmployeeList = new List<Employee>();
        static public List<Employee> HighestPayingEmployeeList { get { return _highestPayingEmployeeList; } set { _highestPayingEmployeeList = value; } }

        static private List<Employee> _lowestPayingEmployeeList = new List<Employee>();
        static public List<Employee> LowestPayingEmployeeList { get { return _lowestPayingEmployeeList; } set { _lowestPayingEmployeeList = value; } }

        static void Main(string[] args)
        {
            // a. Fill a list with objects based on the supplied data file.
            LoadData();

            // b. Calculate and return the average weekly pay for all employees.
            AverageWeeklyPay();

            /* c. Calculate and return the highest weekly pay for the wage employees, including the name of the employee.

            There are two options to solve it:
             a. Instanciate a new list, add the (employees == Wages) and then search
                through it. -> possibly more memory space consumption

             b. Filter the search each time for a specific contract category. -> likely to
                consume less memory, but it possibly would have a longer runtime.

            Although it seems that it would be useful to have a list for each contract category
            for other future searches in the system, it would need to go through all the EmployeeList
            items anyway to make sure that new list was updated. Therefore, I will just implement b.
             */
            HighestWeeklyPay(EmployeeContractCategory.Wages);

            // d. Calculate and return the lowest salary for the salaried employees, including the name of the employee.
            LowestWeeklyPaySalaried(EmployeeContractCategory.Salaried);

            // e. What percentage of the company’s employees fall into each employee category?


        }

        // -------------------------- METHODS --------------------------

        static public List<Employee> LoadData()
        // Fill a list with objects based on the supplied data file.
        {
            // Is "res" a pre-requisite to have "Resources" as the parent directory after we have added the resource file to Visual Studio?
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
            Console.WriteLine($"The average weekly pay for all employees is: ${averagePayAmount:N}\n");

            return averagePayAmount;
        }

        static public List<Employee> HighestWeeklyPay(EmployeeContractCategory targetContractCategory)
        {
            double highestWeeklyPayment = 0D;
            string highestPayingEmployeeNames = "";

            // Find highest payment by Contract Category
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                EmployeeCategory thisContractCategory = new EmployeeCategory(EmployeeList[i].Id);
                ContractCategory = thisContractCategory.getEmployeeContractCategory();

                if (ContractCategory == targetContractCategory && highestWeeklyPayment < EmployeeList[i].GetPay())
                    {
                        highestWeeklyPayment = EmployeeList[i].GetPay();
                    }             
            }
            Console.WriteLine($"The highest {targetContractCategory} payment is of: ${highestWeeklyPayment:N}");

            // Add highest paying employees by Contract Category to a list
            foreach (Employee i in EmployeeList)
            {
                EmployeeCategory thisContractCategory = new EmployeeCategory(i.Id);
                ContractCategory = thisContractCategory.getEmployeeContractCategory();
                if (ContractCategory == targetContractCategory && highestWeeklyPayment == i.GetPay())
                {
                    HighestPayingEmployeeList.Add(i);
                    highestPayingEmployeeNames += i.Name + ", ";
                }
            }
            Console.WriteLine($"The {targetContractCategory} Employees who receive this amount are: {highestPayingEmployeeNames.TrimEnd(',', ' ')}\n");

            return HighestPayingEmployeeList;
        }

        static public List<Employee> LowestWeeklyPaySalaried(EmployeeContractCategory targetContractCategory)
        {
            double lowestSalariedWeeklyPayment = 9999999999999999999999999999999999999D;
            string lowestPayingEmployeeNames = "";

            // Find lowest Salaried payment
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                EmployeeCategory thisContractCategory = new EmployeeCategory(EmployeeList[i].Id);
                ContractCategory = thisContractCategory.getEmployeeContractCategory();
                if (ContractCategory == targetContractCategory && lowestSalariedWeeklyPayment > EmployeeList[i].GetPay())
                    {
                        lowestSalariedWeeklyPayment = EmployeeList[i].GetPay();
                    }
            }
            Console.WriteLine($"The lowest {targetContractCategory} payment is of: ${lowestSalariedWeeklyPayment:N}");

            // Add lowest paying employees by Contract Category to a list
            foreach (Employee i in EmployeeList)
            {
                EmployeeCategory thisContractCategory = new EmployeeCategory(i.Id);
                ContractCategory = thisContractCategory.getEmployeeContractCategory();
                if (ContractCategory == targetContractCategory && lowestSalariedWeeklyPayment == i.GetPay())
                {
                    LowestPayingEmployeeList.Add(i);
                    lowestPayingEmployeeNames += i.Name + ", ";
                }
            }
            Console.WriteLine($"The {targetContractCategory} Employees who receive this amount are: {lowestPayingEmployeeNames.TrimEnd(',', ' ')}\n");

            return LowestPayingEmployeeList;
        }
    }
}

