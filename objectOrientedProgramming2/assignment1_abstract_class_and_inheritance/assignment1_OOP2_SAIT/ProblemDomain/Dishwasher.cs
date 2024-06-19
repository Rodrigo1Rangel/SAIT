using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignment1_OOP2_SAIT.ProblemDomain.ApplianceDataType;

namespace assignment1_OOP2_SAIT
{
    internal class Dishwasher : Appliance
    {
        // ====================== INSTANCE FIELDS ====================== 

        private string _feature;
        private string _soundRating;
        private string _soundRatingTerm;

        // ======================== PROPERTIES ========================= 

        public string Feature { get { return _feature; } set { _feature = value; } }
        public string SoundRating { get { return _soundRating; } set { _soundRating = value; } }
        public string SoundRatingTerm { get { return _soundRatingTerm; } set { _soundRatingTerm = value; } }

        // ======================== CONSTRUCTORS ======================= 

        public Dishwasher(int itemNumber, string brand, int quantity, short wattage, string color, float price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Feature = feature;
            SoundRating = soundRating;
            Type = ApplianceType.Dishwasher;

            if (SoundRating.ToLower() == "qt")
                SoundRatingTerm = "Quietest";
            if (SoundRating.ToLower() == "qr")
                SoundRatingTerm = "Quieter";
            if (SoundRating.ToLower() == "qu")
                SoundRatingTerm = "Quiet";
            if (SoundRating.ToLower() == "m")
                SoundRatingTerm = "Moderate";
        }

        // ========================== METHODS ========================== 
        public override string FormatForFile()
        {
            string delimiter = ";";
            return $"{ItemNumber}{delimiter}{Brand}{delimiter}{Quantity}{delimiter}{Wattage}{delimiter}{Color}{delimiter}{Price}{delimiter}{Feature}{delimiter}{SoundRating}{delimiter}";
        }
        public override string ToString()
        {
            return $" ItemNumber: {ItemNumber}\n Brand: {Brand}\n Quantity: {Quantity}\n Wattage: {Wattage}\n Color: {Color}\n Price: {Price}\n Feature: {Feature}\n Sound Rating: {SoundRatingTerm}\n";
        }
    }
}
