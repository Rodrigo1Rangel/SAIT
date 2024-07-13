using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    public class Flight
    {
        // =======================================  ATTRIBUTES =======================================
        private string _originAirport;
        private string _destinationAirport;
        private string _weekDayOfDeparture;

        // =======================================  PROPERTIES =======================================
        public string OriginAirport { get { return _originAirport; } set { _originAirport = value; } }
        public string DestinationAirport { get { return _destinationAirport; } set { _destinationAirport = value; } }
        public string WeekDayOfDeparture { get { return _weekDayOfDeparture; } set { _weekDayOfDeparture = value; } }

    }
}
