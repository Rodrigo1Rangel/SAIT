using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1_OOP2_SAIT
{
    internal class Refrigerator : Appliance
    {
        // ====================== INSTANCE FIELDS ====================== 

        private byte _doors;
        private float _height;
        private float _width;

        // ======================== PROPERTIES ========================= 

        public byte Doors { get { return _doors; } set { _doors = value; } }
        public float Height { get { return _height; } set { _height = value; } }
        public float Width { get { return _width; } set { _width = value; } }

        // ======================== CONSTRUCTORS ======================= 

        public Refrigerator(int itemNumber, string brand, int quantity, short wattage, string color, float price, byte doors, float height, float width) : base(itemNumber, brand, quantity, wattage, color, price)
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
