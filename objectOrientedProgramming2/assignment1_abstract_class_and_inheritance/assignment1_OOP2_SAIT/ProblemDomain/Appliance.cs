using assignment1_OOP2_SAIT.ProblemDomain;
using assignment1_OOP2_SAIT.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
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
        static private List<Appliance> _applianceList = new List<Appliance>();
        private ApplianceType _type;

        // ======================== PROPERTIES ========================= 

        public int ItemNumber { get { return _itemNumber; } set { _itemNumber = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public short Wattage { get { return _wattage; } set { _wattage = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public bool isAvailable { get { if (_quantity > 0) { return true; } else { return false; } } }
        static public List<Appliance> ApplianceList { get { return _applianceList; } set { _applianceList = value; } }
        public ApplianceType Type { get { return _type; } set { _type = value; } }

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
        public List<Appliance> LoadData()
        // Parse the appliances.txt file into a single list
        {
                string[] datasetPerLine = Resources.appliances.Split('\n');

                foreach (string line in datasetPerLine)
                {
                    char delimiter = ';';
                    string[] applianceItems = line.Split(delimiter);

                    int.TryParse(applianceItems[0].Trim(), out int itemNumber);
                    int.TryParse(applianceItems[2].Trim(), out int quantity);
                    short.TryParse(applianceItems[3].Trim(), out short wattage);
                    float.TryParse(applianceItems[5].Trim(), out float price);

                    ApplianceDataType thisApplianceType = new ApplianceDataType(applianceItems[0]);
                    Type = thisApplianceType.getApplianceType();

                    // Refrigerator check and creation
                    if (applianceItems.Length == 9 && Type == ApplianceType.Refrigerator)
                    {
                        byte.TryParse(applianceItems[6].Trim(), out byte doors);
                        float.TryParse(applianceItems[7].Trim(), out float height);
                        float.TryParse(applianceItems[8].Trim(), out float width);
                        Refrigerator refrigeratorItem = new Refrigerator(itemNumber, Brand, quantity, wattage, Color, price, doors, height, width);
                        ApplianceList.Add(refrigeratorItem);
                    }
                    // Vacuum check and creation
                    else if (applianceItems.Length == 8 && Type == ApplianceType.Vacuum)
                    {
                        byte.TryParse(applianceItems[7].Trim(), out byte batteryVoltage);
                        Vacuum vacuumItem = new Vacuum(itemNumber, Brand, quantity, wattage, Color, price, applianceItems[7].Trim(), batteryVoltage);
                        ApplianceList.Add(vacuumItem);
                    }
                    // Microwave check and creation
                    else if (applianceItems.Length == 9 && Type == ApplianceType.Microwave)
                    {
                        float.TryParse(applianceItems[6].Trim(), out float capacity);
                        Microwave microwaveItem = new Microwave(itemNumber, Brand, quantity, wattage, Color, price, capacity, applianceItems[7].Trim());
                        ApplianceList.Add(microwaveItem);
                    }
                    // Dishwasher check and creation
                    else if (applianceItems.Length == 9 && Type == ApplianceType.Dishwasher)
                    {
                        Dishwasher dishwasherItem = new Dishwasher(itemNumber, Brand, quantity, wattage, Color, price, applianceItems[6].Trim(), applianceItems[7].Trim());
                        ApplianceList.Add(dishwasherItem);
                    }
                    // ArgumentException when the quantity of paremeters is above or below the expected
                    else if (applianceItems.Length < 6)
                        {
                            throw new ArgumentException("Applience data is insufficient to register an appliance item in the system.", "Appliance database.");
                        }
                        else if (applianceItems.Length > 9)
                        {
                            throw new ArgumentException("More data than expected to register an appliance item in the system was given.", "Appliance database.");
                        }
                }
            return ApplianceList;
        }
        public abstract string FormatForFile();
    }
}
