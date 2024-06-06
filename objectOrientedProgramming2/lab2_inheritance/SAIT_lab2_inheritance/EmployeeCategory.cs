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
        // ------------------------- FIELDS -------------------------

        private EmployeeContractCategory _ContractCategory;

        //  Salaried employees have ID numbers starting with 0–4
        private string[] _salariedInitial = { "0", "1", "2", "3", "4" };

        //  Wage employees have ID numbers starting with 5-7
        private string[] _wagesInitial = { "5", "6", "7" };

        // PartTime employees have ID numbers starting with 8-9
        private string[] _partimeInitial = { "8", "9" };

        // ----------------------- PROPERTIES -----------------------
        public string[] SalariedInitial { get { return _salariedInitial; } set { _salariedInitial = value; } }
        public string[] WagesInitial { get { return _wagesInitial; } set { _wagesInitial = value; } }
        public string[] PartTimeInitial { get { return _partimeInitial; } set { _partimeInitial = value; } }

        public EmployeeContractCategory ContractCategory { get { return _ContractCategory; } set { _ContractCategory = value; } }
        public enum EmployeeContractCategory
        {
            Salaried,
            Wages,
            PartTime
        }

        // ------------------------ CONSTRUCTORS ------------------------
        public EmployeeCategory (string id)
        {
            int idCheck;
            if (!int.TryParse(id, out idCheck))
            {
                    throw new ArgumentException("The employee ID must numerical.", "Employee ID number");
            }
            else if (SalariedInitial.Contains(id.Substring(0,1)))
            {
                ContractCategory = EmployeeContractCategory.Salaried;
            }
            else if (WagesInitial.Contains(id.Substring(0, 1)))
            {
                ContractCategory = EmployeeContractCategory.Wages;
            }
            else // if (PartTimeInitial.Contains(id.Substring(0, 1)))
            {
                ContractCategory = EmployeeContractCategory.PartTime;
            }
        }

        // -------------------------- METHODS --------------------------
        public EmployeeContractCategory getEmployeeContractCategory()
        {
            return ContractCategory;
        }

    }
}
