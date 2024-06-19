using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignment1_OOP2_SAIT.ProblemDomain.ApplianceDataType;

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
            Doors = doors;
            Height = height;
            Width = width;
            Type = ApplianceType.Refrigerator;
    }

        // ========================== METHODS ========================== 

        public override string FormatForFile()
        {
            string delimiter = ";";
            return $"{ItemNumber}{delimiter}{Brand}{delimiter}{Quantity}{delimiter}{Wattage}{delimiter}{Color}{delimiter}{Price}{delimiter}{Doors}{delimiter}{Height}{delimiter}{Width}{delimiter}";
        }
        public override string ToString()
        {
            string DoorsTerm = "";
            if (Doors == 1)
                DoorsTerm = "Single Door";
            else if (Doors == 2)
                DoorsTerm = "Double Door";
            else if (Doors == 3)
                DoorsTerm = "Three Doors";

            return $" ItemNumber: {ItemNumber}\n Brand: {Brand}\n Quantity: {Quantity}\n Wattage: {Wattage}\n Color: {Color}\n Price: {Price}\n Doors: {DoorsTerm}\n Height: {Height}\n Width: {Width}\n";
        }
    }
}
