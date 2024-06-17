using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1_OOP2_SAIT.ProblemDomain
{
    internal class ApplianceDataType
    {
        public enum ApplianceType
        {
            Dishwasher,
            Microwave,
            Refrigerator,
            Vacuum
        }

        // ====================== INSTANCE FIELDS ====================== 

        // Refrigerators have item numbers starting with 1
        private string[] _refrigeratorInitial = { "1" };
        
        // Vacuums have item numbers starting with 2
        private string[] _vacuumInitial = { "2" };

        // Microwave have item numbers starting with 3
        private string[] _microwaveInitial = { "3" };

        // Dishwasher have item numbers starting with 4-5
        private string[] _dishwasherInitial = { "4", "5" };

        private ApplianceType _applianceType;


        // ======================== PROPERTIES ========================= 

        public string[] RefrigeratorInitial { get { return _refrigeratorInitial; } set { _refrigeratorInitial = value; } }
        public string[] VacuumInitial { get { return _vacuumInitial; } set { _vacuumInitial = value; } }
        public string[] MicrowaveInitial { get { return _microwaveInitial; } set { _microwaveInitial = value; } }
        public string[] DishwasherInitial { get { return _dishwasherInitial; } set { _dishwasherInitial = value; } }
        public ApplianceType Type { get { return _applianceType; } set { _applianceType = value; } }


        // ======================== CONSTRUCTORS ======================= 

        public ApplianceDataType(string id)
        {
            int inCheck;
            if (!int.TryParse(id, out inCheck))
            {
                throw new ArgumentException("The appliance item number must numerical.", "Appliance Item Number");
            }
            else if (RefrigeratorInitial.Contains(id.Substring(0, 1)))
            {
                Type = ApplianceType.Refrigerator;
            }
            else if (VacuumInitial.Contains(id.Substring(0, 1)))
            {
                Type = ApplianceType.Vacuum;
            }
            else if (MicrowaveInitial.Contains(id.Substring(0, 1)))
            {
                Type = ApplianceType.Microwave;
            }
            else if (DishwasherInitial.Contains(id.Substring(0, 1)))
            {
                Type = ApplianceType.Dishwasher;
            }
            else
            {
                throw new ArgumentException("There are appliances within the database with item numbers out of the specified range.", "Appliance Item Number Out Of Range");
            }
        }

        // ========================== METHODS ==========================
        public ApplianceType getApplianceType()
        {
            return Type;
        }
    }
}
