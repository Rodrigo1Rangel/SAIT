using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignment1_OOP2_SAIT.ProblemDomain.ApplianceDataType;

namespace assignment1_OOP2_SAIT
{
    internal class Microwave : Appliance
    {
        // ====================== INSTANCE FIELDS ====================== 

        private float _capacity;
        private string _roomType;
        private string _roomTypeInitial;


        // ======================== PROPERTIES ========================= 

        public float Capacity { get { return _capacity; } set { _capacity = value; } }
        public string RoomType { get { return _roomType; } set { _roomType = value; } }
        public string RoomTypeInitial { get { return _roomTypeInitial; } set { _roomTypeInitial = value; } }

        // ======================== CONSTRUCTORS ======================= 

        public Microwave(int itemNumber, string brand, int quantity, short wattage, string color, float price, float capacity, string roomType) : base (itemNumber, brand, quantity, wattage, color, price)
        {
            RoomTypeInitial = roomType;
            Capacity = capacity;

            if (roomType.ToLower() == "w")
                RoomType = "Work Site";
            else if (roomType.ToLower() == "k")
                RoomType = "Kitchen";

            Type = ApplianceType.Microwave;
        }

        // ========================== METHODS ========================== 
        public override string FormatForFile()
        {
            string delimiter = ";";
            return $"{ItemNumber}{delimiter}{Brand}{delimiter}{Quantity}{delimiter}{Wattage}{delimiter}{Color}{delimiter}{Price}{delimiter}{Capacity}{delimiter}{RoomTypeInitial}{delimiter}";
        }
        public override string ToString()
        {
            return $" ItemNumber: {ItemNumber}\n Brand: {Brand}\n Quantity: {Quantity}\n Wattage: {Wattage}\n Color: {Color}\n Price: {Price}\n Capacity: {Capacity}\n Room Type: {RoomType}\n";
        }
    }
}
