using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SAIT_lab2_inheritance.EmployeeCategory;

namespace SAIT_lab2_inheritance
{
    internal class EmployeeCategory
    {
        private EmployeeContractCategory _ContractCategory;
        public EmployeeContractCategory ContractCategory { get { return _ContractCategory; } set { _ContractCategory = value; } }

        public enum EmployeeContractCategory
        {
            Salaried,
            Wages,
            PartTime
        }

        //  Salaried employees have ID numbers starting with 0–4
        private string[] _salariedInitial = { "0", "1", "2", "3", "4" };
        public string[] SalariedInitial { get { return _salariedInitial; } set { _salariedInitial = value; } }

        //  Wage employees have ID numbers starting with 5-7
        private string[] _wagesInitial = { "5", "6", "7" };
        public string[] WagesInitial { get { return _wagesInitial; } set { _wagesInitial = value; } }

        // PartTime employees have ID numbers starting with 8-9
        private string[] _partimeInitial = { "8", "9" };
        public string[] PartTimeInitial { get { return _partimeInitial; } set { _partimeInitial = value; } }


        public EmployeeCategory (string id)
        {
            if (SalariedInitial.Contains(id.Substring(0,1)))
            {
                ContractCategory = EmployeeContractCategory.Salaried;
            }
            else if (WagesInitial.Contains(id.Substring(0, 1)))
            {
                ContractCategory = EmployeeContractCategory.Wages;
            }
            else if (PartTimeInitial.Contains(id.Substring(0, 1)))
            {
                ContractCategory = EmployeeContractCategory.Wages;
            }


            /* Inefficient:
            
            //  Salaried employees have ID numbers starting with 0–4
            foreach (string i in SalariedInitial)
            {
                if (id.StartsWith(i))
                {
                    ContractCategory = EmployeeContractCategory.Salaried;
                }
            }

            //  Wage employees have ID numbers starting with 5-7
            foreach (string i in WagesInitial)
            {
                if (id.StartsWith(i))
                {
                    ContractCategory = EmployeeContractCategory.Wages;
                }
            }

            // PartTime employees have ID numbers starting with 8-9
            foreach (string i in PartTimeInitial)
            {
                if (id.StartsWith(i))
                {
                    ContractCategory = EmployeeContractCategory.PartTime;
                }
            */
        }

        public EmployeeContractCategory getEmployeeContractCategory()
        {
            return ContractCategory;
        }

    }
}
