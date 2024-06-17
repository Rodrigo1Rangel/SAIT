using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1_OOP2_SAIT
{
    internal class Vacuum : Appliance
    {
        // ====================== INSTANCE FIELDS ====================== 

        private string _grade;
        private byte _batteryVoltage;

        // ======================== PROPERTIES ========================= 

        public string Grade { get { return _grade; } set { _grade = value; } }
        public byte BatteryVoltage { get { return _batteryVoltage; } set { _batteryVoltage = value; } }

        // ======================== CONSTRUCTORS ======================= 

        public Vacuum(int itemNumber, string brand, int quantity, short wattage, string color, float price, string grade, byte batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
        }

        // ========================== METHODS ========================== 
        public override string FormatForFile()
        {
            return "a";
        }
        public override string ToString()
        {
            return $"ItemNumber: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nGrade: {Grade}\nBatteryVoltage: {BatteryVoltage}\n";
        }
    }
}
