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
        // -------------------------- FIELDS --------------------------

        static private EmployeeContractCategory _contractCategory;
        static private List<Employee> _employeeList = new List<Employee>();
        static private List<Employee> _highestPayingEmployeeList = new List<Employee>();
        static private List<Employee> _lowestPayingEmployeeList = new List<Employee>();
        static private int _quantityEmployeeSalaried = 0;
        static private int _quantityEmployeeWages = 0;
        static private int _quantityEmployeePartTime = 0;
        static private int _quantityEmployee = 0;

        // -------------------------- PROPERTIES --------------------------
        static public EmployeeContractCategory ContractCategory { get { return _contractCategory; } set { _contractCategory = value; } }
        static public List<Employee> EmployeeList { get { return _employeeList; } set { _employeeList = value; } }
        static public List<Employee> HighestPayingEmployeeList { get { return _highestPayingEmployeeList; } set { _highestPayingEmployeeList = value; } }
        static public List<Employee> LowestPayingEmployeeList { get { return _lowestPayingEmployeeList; } set { _lowestPayingEmployeeList = value; } }
        static public int QuantityEmployeeSalaried { get { return _quantityEmployeeSalaried; } set { _quantityEmployeeSalaried = value; } }
        static public int QuantityEmployeeWages { get { return _quantityEmployeeWages; } set { _quantityEmployeeWages = value; } }
        static public int QuantityEmployeePartTime { get { return _quantityEmployeePartTime; } set { _quantityEmployeePartTime = value; } }
        static public int QuantityEmployee { get { return _quantityEmployee; } set { _quantityEmployee = value; } }

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

            /* e. What percentage of the company’s employees fall into each employee category?
            We could have iterated through the employeeList checking and incrementing (extra O(N)), but I believe that it is 
            better to have static variables that will be incremented upon file loading once, and will remain accessible
            later on.
            */
            EmployeeCategoryShare();
        }

        // -------------------------- METHODS --------------------------

        static public List<Employee> LoadData()
        // Fill a list with objects based on the supplied data file.
        {
            // Is "res" a pre-requisite to have "Resources" as the parent directory after we have added the resource file to Visual Studio?
            // C: \Users\rodri\OneDrive\Documents\GitHub\SAIT\objectOrientedProgramming2\lab2_inheritance\SAIT_lab2_inheritance\Resources\employees.txt
            string[] datasetPerLine = Resources.employees.Split('\n');
            /* We could also have done without storing each line in a variable:
             
               foreach (string datasetPerLine in Resources.employees.Split('\n')
               {
                    foreach (string lineItem in datasetPerLine)
                    {
                    
                    }
               }
            */

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
                    QuantityEmployeeSalaried += 1;
                }
                // Wages contract check
                else if (employeeItems.Length == 9 && ContractCategory == EmployeeContractCategory.Wages)
                {
                    long.TryParse(employeeItems[4], out sin);
                    double.TryParse(employeeItems[7], out rate);
                    double.TryParse(employeeItems[8], out hours);
                    Wages employeePaymentData = new Wages(employeeItems[0].Trim(), employeeItems[1].Trim(), employeeItems[2].Trim(), employeeItems[3].Trim(), sin, employeeItems[5].Trim(), employeeItems[6].Trim(), rate, hours);
                    EmployeeList.Add(employeePaymentData);
                    QuantityEmployeeWages += 1;
                }
                // PartTime contract check
                else if (employeeItems.Length == 9 && ContractCategory == EmployeeContractCategory.PartTime)
                {
                    long.TryParse(employeeItems[4], out sin);
                    double.TryParse(employeeItems[7], out rate);
                    double.TryParse(employeeItems[8], out hours);
                    PartTime employeePaymentData = new PartTime(employeeItems[0].Trim(), employeeItems[1].Trim(), employeeItems[2].Trim(), employeeItems[3].Trim(), sin, employeeItems[5].Trim(), employeeItems[6].Trim(), rate, hours);
                    EmployeeList.Add(employeePaymentData);
                    QuantityEmployeePartTime += 1;
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
            QuantityEmployee = QuantityEmployeeSalaried + QuantityEmployeeWages + QuantityEmployeePartTime;
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

        static public void EmployeeCategoryShare()
        {
            Console.WriteLine($"The employee share that belong to each contract category is the following: {QuantityEmployeeSalaried/ (double)QuantityEmployee:P} Salaried, {QuantityEmployeeWages/(double)QuantityEmployee:P} Wages, and {QuantityEmployeePartTime/(double)QuantityEmployee:P} Part-Time.\n");
        }
    }
}

