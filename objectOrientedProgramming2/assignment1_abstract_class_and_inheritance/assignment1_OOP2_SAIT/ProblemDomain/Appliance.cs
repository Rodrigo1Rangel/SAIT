using assignment1_OOP2_SAIT.ProblemDomain;
using assignment1_OOP2_SAIT.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static assignment1_OOP2_SAIT.ProblemDomain.ApplianceDataType;

namespace assignment1_OOP2_SAIT
{
    internal abstract class Appliance
    {
        // ====================== INSTANCE FIELDS ======================
        
        private int _itemNumber;
        private string _brand;
        private int _quantity;
        private short _wattage;
        private string _color;
        private float _price;
        private ApplianceType _type;

        // ======================== PROPERTIES ========================= 

        public int ItemNumber { get { return _itemNumber; } set { _itemNumber = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public short Wattage { get { return _wattage; } set { _wattage = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public bool isAvailable { get { if (_quantity > 0) { return true; } else { return false; } } }
        public ApplianceType Type { get { return _type; } set { _type = value; } }

        // ======================== CONSTRUCTORS ======================= 

        public Appliance(int itemNumber, string brand, int quantity, short wattage, string color, float price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }

        // ========================== METHODS ========================== 

        public void Checkout()
        {
            Quantity -= 1;
            Console.WriteLine($" Appliance \"{ItemNumber}\" has been checked out.\n");
        }
        public abstract string FormatForFile();
        public override abstract string ToString();
    }
}
