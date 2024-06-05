using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAIT_lab2_inheritance.EmployeeCategory;
using System.IO;

namespace SAIT_lab2_inheritance
{
    internal class Program
    {
        static private List<Employee> _employeeList = new List<Employee>();
        static public List<Employee> EmployeeList { get { return _employeeList; } set { _employeeList = value; } }

        static void Main(string[] args)
        {
            LoadData();
        }

        // METHODS

        static public List<Employee> LoadData()
        // Fill a list with objects based on the supplied data file.
        {
            string employeeFileLine;
            string path = Directory.GetCurrentDirectory();
            string filePath = $"{path}/../res/employees.txt";
            StreamReader readFile = null; // it needs to be assigned to later be able to be ".Close()"

            try
            {
                readFile = new StreamReader(filePath);
                employeeFileLine = readFile.ReadLine();

                while (employeeFileLine != null)
                {
                    char delimiter = ':';
                    string[] employeeItems = employeeFileLine.Split(delimiter);

                    double weeklySalary;
                    long sin;
                    double rate;
                    double hours;
                    if (employeeItems.Length == 8) 
                    // is there another way less manual to address the array items as inputs when calling a constructor?
                    // create a constructor to do it
                    {
                        long.TryParse(employeeItems[4], out sin);
                        double.TryParse(employeeItems[7], out weeklySalary);
                        Employee employeePaymentData = new Employee(employeeItems[0], employeeItems[1], employeeItems[2], employeeItems[3], sin, employeeItems[5], employeeItems[6], weeklySalary);
                        EmployeeList.Add(employeePaymentData);
                        employeeFileLine = readFile.ReadLine();
                    }
                    if (employeeItems.Length == 9)
                    {
                        long.TryParse(employeeItems[4], out sin);
                        double.TryParse(employeeItems[7], out rate);
                        double.TryParse(employeeItems[8], out hours);
                        Employee employeePaymentData = new Employee(employeeItems[0], employeeItems[1], employeeItems[2], employeeItems[3], sin, employeeItems[5], employeeItems[6], rate, hours);
                        EmployeeList.Add(employeePaymentData);
                        employeeFileLine = readFile.ReadLine();
                    }
                    if (employeeItems.Length < 7 || employeeItems.Length == 8)
                    {
                        throw new ArgumentException("Employee data is insufficient to register an employee payment in the system.", "Employee data.");
                    }
                    else
                    {
                        throw new ArgumentException("More data than expected to register an employee payment in the system was given.", "Employee data.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.Message}");
            }
            finally
            {
                readFile.Close();
            }
            return EmployeeList;
        }
        
        static public double AverageWeeklyPay()
        // Calculate and return the average weekly pay for all employees.
        {
            double averagePayAmount = 0D;
            
            foreach (Employee employee in EmployeeList)
            {
                averagePayAmount += employee.getPay();
            }

            return averagePayAmount;
        }
    }
}
