using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    public class Reservation
    {
        // =======================================  ATTRIBUTES =======================================
        private string _name;
        private string _citizenship;
        private string _status;
        private readonly string _flightCode;
        private readonly string _airlineName;
        private readonly string _cost;
        private readonly string _reservationCode;

        // =======================================  PROPERTIES =======================================
        public string TravellerName { get { return _name; } set { _name = value; } }
        public string TravellerCitizenship { get { return _citizenship; } set { _citizenship = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public string FlightCode { get { return _status; } }
        public string AirlineName { get { return _status; } }
        public string Cost { get { return _status; } }
        public string ReservationCode { get { return _status; } }


    }
}
