using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignment1_OOP2_SAIT.ProblemDomain.ApplianceDataType;

namespace assignment1_OOP2_SAIT
{
    internal class Vacuum : Appliance
    {
        // ====================== INSTANCE FIELDS ====================== 

        private string _grade;
        private string _batteryVoltageTerm;
        private string _batteryVoltageValue;

        // ======================== PROPERTIES ========================= 

        public string Grade { get { return _grade; } set { _grade = value; } }
        public string BatteryVoltageTerm { get { return _batteryVoltageTerm; } set { _batteryVoltageTerm = value; } }
        public string BatteryVoltageValue { get { return _batteryVoltageValue; } set { _batteryVoltageValue = value; } }

        // ======================== CONSTRUCTORS ======================= 

        public Vacuum(int itemNumber, string brand, int quantity, short wattage, string color, float price, string grade, string batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            BatteryVoltageValue = batteryVoltage;
            if (BatteryVoltageValue == "18")
                BatteryVoltageTerm = "Low";
            else if (BatteryVoltageValue == "24")
                BatteryVoltageTerm = "High";
            else
                throw new ArgumentException(" The Battery voltage value can be either 18 V (Low) or 24 V (High).", " Battery voltage not acceptable.");

            Grade = grade;
            Type = ApplianceType.Vacuum;
        }

        // ========================== METHODS ========================== 
        public override string FormatForFile()
        {
            string delimiter = ";";
            return $"{ItemNumber}{delimiter}{Brand}{delimiter}{Quantity}{delimiter}{Wattage}{delimiter}{Color}{delimiter}{Price}{delimiter}{Grade}{delimiter}{BatteryVoltageValue}{delimiter}";
        }
        public override string ToString()
        {
            return $" ItemNumber: {ItemNumber}\n Brand: {Brand}\n Quantity: {Quantity}\n Wattage: {Wattage}\n Color: {Color}\n Price: {Price}\n Grade: {Grade}\n BatteryVoltage: {BatteryVoltageTerm}\n";
        }
    }
}
