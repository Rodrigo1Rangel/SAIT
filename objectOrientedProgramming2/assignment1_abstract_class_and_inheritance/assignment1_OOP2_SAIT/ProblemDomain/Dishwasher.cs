using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1_OOP2_SAIT
{
    internal class Dishwasher : Appliance
    {
        // ====================== INSTANCE FIELDS ====================== 

        private string _feature;
        private string _soundRating;

        // ======================== PROPERTIES ========================= 

        public string Feature { get { return _feature; } set { _feature = value; } }
        public string SoundRating { get { return _soundRating; } set { _soundRating = value; } }
        // SoundRatingDi...

        // ======================== CONSTRUCTORS ======================= 

        public Dishwasher(int itemNumber, string brand, int quantity, short wattage, string color, float price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
        }

        // ========================== METHODS ========================== 
        public override string FormatForFile()
        {
            return "a";
        }
        public override string ToString()
        {
            return $"ItemNumber: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nFeature: {Feature}\nSound Rating: {SoundRating}\n";
        }
    }
}
