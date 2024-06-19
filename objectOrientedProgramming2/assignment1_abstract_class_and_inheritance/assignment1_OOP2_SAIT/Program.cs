using assignment1_OOP2_SAIT.ProblemDomain;
using assignment1_OOP2_SAIT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static assignment1_OOP2_SAIT.ProblemDomain.ApplianceDataType;
using System.IO;
using System.Threading;

namespace assignment1_OOP2_SAIT
{
    internal class Program
    {
        // ====================== INSTANCE FIELDS ====================== 

        static private List<Appliance> _applianceList = new List<Appliance>();

        // ======================== PROPERTIES ========================= 
        static public List<Appliance> ApplianceList { get { return _applianceList; } set { _applianceList = value; } }

        private static void Main(string[] args)
        {
            // To make sure that the decimals from the file are interpreted with dot separators
            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            LoadData();
            Menu();
        }

        // ========================== METHODS ========================== 
        public static List<Appliance> LoadData()
        // Parse the appliances.txt file into a single list
        {
            string[] datasetPerLine = Resources.appliances.Split('\r');

            foreach (string line in datasetPerLine)
            {

                char delimiter = ';';
                string[] applianceItems = line.TrimEnd(delimiter).TrimStart('\n').Split(delimiter);


                int.TryParse(applianceItems[0].Trim(), out int itemNumber);
                int.TryParse(applianceItems[2].Trim(), out int quantity);
                short.TryParse(applianceItems[3].Trim(), out short wattage);
                float.TryParse(applianceItems[5].Trim(), out float price);

                ApplianceDataType thisApplianceType = new ApplianceDataType(applianceItems[0]);
                thisApplianceType.Type = thisApplianceType.getApplianceType();

                // Refrigerator check and creation
                if (applianceItems.Length == 9 && thisApplianceType.Type == ApplianceType.Refrigerator)
                {
                    byte.TryParse(applianceItems[6].Trim(), out byte doors);
                    float.TryParse(applianceItems[7].Trim(), out float height);
                    float.TryParse(applianceItems[8].Trim(), out float width);
                    Refrigerator refrigeratorItem = new Refrigerator(itemNumber, applianceItems[1].Trim(), quantity, wattage, applianceItems[4].Trim(), price, doors, height, width);
                    ApplianceList.Add(refrigeratorItem);
                }
                // Vacuum check and creation
                else if (applianceItems.Length == 8 && thisApplianceType.Type == ApplianceType.Vacuum)
                {
                    Vacuum vacuumItem = new Vacuum(itemNumber, applianceItems[1].Trim(), quantity, wattage, applianceItems[4].Trim(), price, applianceItems[6].Trim(), applianceItems[7].Trim());
                    ApplianceList.Add(vacuumItem);
                }
                // Microwave check and creation
                else if (applianceItems.Length == 8 && thisApplianceType.Type == ApplianceType.Microwave)
                {
                    float.TryParse(applianceItems[6].Trim(), out float capacity);
                    Microwave microwaveItem = new Microwave(itemNumber, applianceItems[1].Trim(), quantity, wattage, applianceItems[4].Trim(), price, capacity, applianceItems[7].Trim());
                    ApplianceList.Add(microwaveItem);
                }
                // Dishwasher check and creation
                else if (applianceItems.Length == 8 && thisApplianceType.Type == ApplianceType.Dishwasher)
                {
                    Dishwasher dishwasherItem = new Dishwasher(itemNumber, applianceItems[1].Trim(), quantity, wattage, applianceItems[4].Trim(), price, applianceItems[6].Trim(), applianceItems[7].Trim());
                    ApplianceList.Add(dishwasherItem);
                }
                // ArgumentException when the quantity of paremeters is above or below the expected
                else if (applianceItems.Length < 6)
                {
                    throw new ArgumentException("Applience data is insufficient to register an appliance item in the system.", "Appliance data input.");
                }
                else if (applianceItems.Length > 9)
                {
                    throw new ArgumentException("More data than expected to register an appliance item in the system was given.", "Appliance data input.");
                }
            }
            return ApplianceList;
        }

        public static void Save()
        {
            //Create empty array with the size of the quantity of the appliance items
            string[] textToFileLines = new string[ApplianceList.Count];
            for (int i = 0; i < ApplianceList.Count; i++)
            {
                //Point the array's memory allocation to each item of the ApplianceList
                textToFileLines[i] = ApplianceList[i].FormatForFile();
            }
            File.WriteAllLines(Environment.CurrentDirectory + "\\..\\..\\Resources\\appliances.txt", textToFileLines);
        }

        public static void Menu()
        {

            string menuUserSelection;
            do
            {
                Console.Write($" Welcome to Modern Appliances!\n How may we assist you?\n 1 – Check out appliance\n 2 – Find appliances by brand\n 3 – Display appliances by type\n 4 – Produce random appliance list\n 5 – Save & exit\n Enter option:\n     ");
                menuUserSelection = Console.ReadLine();

                switch (menuUserSelection)
                {
                    case "1": // CHECK OUT APPLIANCE
                        Console.Write(" Enter the item number of an appliance:\n     ");
                        string itemNumberSelection = Console.ReadLine();
                        if (!int.TryParse(itemNumberSelection, out int itemNumberSearch))
                        {
                            Console.WriteLine("\n Please, enter a numerical item number.\n");
                            Menu();
                        }
                        // Search for the matching appliance
                        bool isItemRegistered = false;
                        foreach (Appliance appliance in ApplianceList)
                        {
                            if (appliance.ItemNumber == itemNumberSearch)
                            {
                                appliance.ToString();
                                isItemRegistered = true;
                                if (appliance.isAvailable)
                                    appliance.Checkout();
                                else
                                    Console.WriteLine(" The appliance is not available to be checked out.\n");
                            }
                        }
                        if (!isItemRegistered)
                        {
                            Console.WriteLine(" No appliances found with that item number.\n");
                        }
                        break;

                    case "2": // FIND APPLIANCES BY BRAND
                        Console.Write(" Enter brand to search for:\n     ");
                        string brandSelection = Console.ReadLine();
                        bool isBrandRegistered = false;
                        // ugly code incoming:
                        foreach (Appliance appliance in ApplianceList)
                        {
                            if (appliance.Brand.ToLower() == brandSelection.ToLower())
                            {
                                isBrandRegistered = true;
                            }
                        }
                        if (isBrandRegistered)
                        {
                            Console.WriteLine(" Matching Appliances:");
                            foreach (Appliance appliance in ApplianceList)
                            {
                                if (appliance.Brand.ToLower() == brandSelection.ToLower())
                                {
                                    Console.WriteLine(appliance.ToString());
                                }
                            }
                        }
                        if (!isBrandRegistered)
                        {
                            Console.WriteLine(" No appliances found from that brand.\n");
                        }
                        break;

                    case "3": // DISPLAY APPLIANCES BY TYPE
                        Console.Write(" Appliance Types\n 1 – Refrigerators\n 2 – Vacuums\n 3 – Microwaves\n 4 – Dishwashers\n Enter type of appliance:\n     ");
                        string applianceSelection = Console.ReadLine();
                        switch (applianceSelection)
                        {
                            // REFRIGERATOR
                            case "1":
                                Console.Write(" Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):\n     ");
                                string numberOfDoors = Console.ReadLine();

                                // User entry validation
                                bool numberOfDoorsCheckDigit = byte.TryParse(numberOfDoors, out byte byteNumberOfDoors);
                                while (byteNumberOfDoors > 4 || byteNumberOfDoors < 2 || !numberOfDoorsCheckDigit)
                                {
                                    Console.Write(" Invalid entry.\n Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):\n     ");
                                    numberOfDoors = Console.ReadLine();
                                    numberOfDoorsCheckDigit = byte.TryParse(numberOfDoors, out byteNumberOfDoors);
                                }

                                // Print matching refrigerators by number of doors
                                Console.WriteLine(" Matching refrigerators:");
                                foreach (Appliance appliance in ApplianceList)
                                {
                                    if (appliance.Type == ApplianceType.Refrigerator)
                                    {
                                        Refrigerator refrigerator = (Refrigerator)appliance;
                                        if (refrigerator.Doors == byteNumberOfDoors)
                                        {
                                            Console.WriteLine(refrigerator.ToString());
                                        }
                                    }
                                }
                                break;

                            // VACUUM
                            case "2":
                                Console.Write(" Enter battery voltage value. 18 V (low) or 24 V (high):\n     ");
                                string voltageValue = Console.ReadLine();

                                // User entry validation
                                while (voltageValue != "18" && voltageValue != "24")
                                {
                                    Console.Write(" Invalid entry.\n Enter battery voltage value. 18 V (low) or 24 V (high):\n     ");
                                    voltageValue = Console.ReadLine();
                                }

                                // Print matching vacuums by voltage
                                Console.WriteLine(" Matching vacuums:");
                                foreach (Appliance appliance in ApplianceList)
                                {
                                    if (appliance.Type == ApplianceType.Vacuum)
                                    {
                                        Vacuum vacuum = (Vacuum)appliance;
                                        if (vacuum.BatteryVoltageValue == voltageValue)
                                        {
                                            Console.WriteLine(vacuum.ToString());
                                        }
                                    }
                                }
                                break;

                            // MICROWAVE
                            case "3":
                                Console.Write(" Room where the microwave will be installed: K (kitchen) or W (work site):\n     ");
                                string placeOfInstallation = Console.ReadLine().ToLower();

                                // User entry validation
                                while (placeOfInstallation != "k" && placeOfInstallation != "w")
                                {
                                    Console.Write(" Invalid entry.\n Room where the microwave will be installed: K (kitchen) or W (work site):\n     ");
                                    placeOfInstallation = Console.ReadLine();
                                }

                                // Print matching microwaves by voltage
                                Console.WriteLine(" Matching microwaves:");
                                foreach (Appliance appliance in ApplianceList)
                                {
                                    if (appliance.Type == ApplianceType.Microwave)
                                    {
                                        Microwave microwave = (Microwave)appliance;
                                        if (microwave.RoomTypeInitial.ToLower() == placeOfInstallation)
                                        {
                                            Console.WriteLine(microwave.ToString());
                                        }
                                    }
                                }
                                break;

                            // DISHWASHER
                            case "4":
                                Console.Write(" Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):\n     ");
                                string soundRating = Console.ReadLine().ToLower();


                                // User entry validation
                                while (soundRating != "qt" && soundRating != "qr" && soundRating != "qu" && soundRating != "m")
                                {
                                    Console.Write(" Invalid entry.\n Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):\n     ");
                                    soundRating = Console.ReadLine();
                                }

                                // Print matching microwaves by voltage
                                Console.WriteLine(" Matching Dishwashers:");
                                foreach (Appliance appliance in ApplianceList)
                                {
                                    if (appliance.Type == ApplianceType.Dishwasher)
                                    {
                                        Dishwasher dishwasher = (Dishwasher)appliance;
                                        if (dishwasher.SoundRating.ToLower() == soundRating)
                                        {
                                            Console.WriteLine(dishwasher.ToString());
                                        }
                                    }
                                }
                                break;
                        }
                        break;

                    case "4": // PRODUCE RANDOM APPLIANCE LIST

                        // User prompt
                        Console.Write(" Enter number of appliances:\n     ");
                        string randomApplianceQuantity = Console.ReadLine();
                        bool randomApplianceQuantityCheck = int.TryParse(randomApplianceQuantity, out int randomApplianceQuantityValue);

                        // Validates that the random number is a int32.
                        while (!randomApplianceQuantityCheck || randomApplianceQuantityValue > ApplianceList.Count)
                        {
                            Console.Write(" Invalid entry. The number of appliances must be a numerical (Int32) value.\n Enter number of appliances:\n     ");
                            randomApplianceQuantity = Console.ReadLine();
                            randomApplianceQuantityCheck = int.TryParse(randomApplianceQuantity, out randomApplianceQuantityValue);
                        }

                        // Validates that the random number is lower than the amount of unique appliances.
                        while (randomApplianceQuantityValue > ApplianceList.Count)
                        {
                            Console.Write($" Invalid entry. There are {ApplianceList.Count} unique appliances. Choose a value lower than {ApplianceList.Count}.\n Enter number of appliances:\n     ");
                            randomApplianceQuantity = Console.ReadLine();
                            randomApplianceQuantityCheck = int.TryParse(randomApplianceQuantity, out randomApplianceQuantityValue);
                        }

                        // Random selection and display of appliances
                        Random randomNumberOfAppliances = new Random();
                        for (int i = 0; i < randomApplianceQuantityValue; i++)
                        {
                            int randomValue = randomNumberOfAppliances.Next(ApplianceList.Count + 1);
                            Console.WriteLine(ApplianceList[randomValue].ToString());
                        }
                        break;

                    case "5":
                        break;
                    
                    default:
                        Console.WriteLine("\n Please, enter a valid option.");
                        break;
                }
            } while (menuUserSelection != "5"); // SAVE & EXIT
            Save();
        }

    }
}
