using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // ======================== PROPERTIES ========================= 

        public int ItemNumber { get { return _itemNumber; } set { _itemNumber = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public short Wattage { get { return _wattage; } set { _wattage = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public bool isAvailable { get { if (_quantity > 0) { return true; } else { return false; } } }
        // Type?

        // ======================== CONSTRUCTORS ======================= 

        public Appliance(int itemNumber, string brand, int quantity, short wattage, string color, float price)
        {
        }

        // ========================== METHODS ========================== 

        public string Checkout()
        {
            return "a";
        }
        public string DetermineAppliance()
        {
            return "a";
        }
        public abstract string FormatForFile();
    }
}
