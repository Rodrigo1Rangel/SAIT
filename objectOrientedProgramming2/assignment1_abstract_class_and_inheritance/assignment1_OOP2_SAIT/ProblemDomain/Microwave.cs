using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1_OOP2_SAIT
{
    internal class Microwave : Appliance
    {
        // ====================== INSTANCE FIELDS ====================== 

        private float _capacity;
        private string _roomType;

        // ======================== PROPERTIES ========================= 

        public float Capacity { get { return _capacity; } set { _capacity = value; } }
        public string RoomType { get { return _roomType; } set { _roomType = value; } }

        // ======================== CONSTRUCTORS ======================= 

        public Microwave(int itemNumber, string brand, int quantity, short wattage, string color, float price, float capacity, string roomType) : base (itemNumber, brand, quantity, wattage, color, price)
        {
        }

        // ========================== METHODS ========================== 
        public override string FormatForFile()
        {
            return "a";
        }
        public override string ToString()
        {
            return "a";
        }
    }
}
