using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    public class Airport
    {
        // =====================================  INSTANCE FIELDS =====================================
        private string _airportCode;
        private string _airportName;

        // =======================================  PROPERTIES ========================================
        public string AirportCode { get { return _airportCode; } set { _airportCode = value; } }
        public string AirportName { get { return _airportName; } set { _airportName = value; } }

        // ======================================  CONSTRUCTORS ======================================
        public Airport(string airportCode, string airportName)
        {
            AirportCode = airportCode;
            AirportName = airportName;
        }
        public override string ToString()
        {
            return $"Airport: {AirportName}, {AirportCode}";
        }
    }
}
