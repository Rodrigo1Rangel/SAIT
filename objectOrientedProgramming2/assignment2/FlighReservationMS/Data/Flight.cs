//using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using System.Globalization;
using FlighReservationMS.Properties;

namespace FlighReservationMS.Data
{
        public class Flight
    {
        // =====================================  INSTANCE FIELDS =====================================
        protected readonly string _flightCode;
        protected readonly string _airline;
        private readonly string _originAirport;
        private readonly string _destinationAirport;
        private readonly string _weekDayOfDeparture; // to do: Enumerate
        private readonly string _timeOfDeparture; // to do: TimeOnly
        private readonly ushort _seatsAvailable;
        protected readonly double _cost;

        // =======================================  PROPERTIES =======================================
        public string OriginAirport { get { return _originAirport; }}
        public string DestinationAirport { get { return _destinationAirport; } }
        public string WeekDayOfDeparture { get { return _weekDayOfDeparture; } }
        public string TimeOfDeparture { get { return _timeOfDeparture; } }
        public string FlightCode { get { return _flightCode; } }
        public string Airline { get { return _airline; } }
        public double Cost { get { return _cost; } }
        public ushort SeatsAvailable { get { return _seatsAvailable; } set { value = _seatsAvailable; } }


        // =======================================  CONSTRUCTOR  ======================================
        public Flight(
            string flightCode, 
            string airline, 
            string originAirport, 
            string destinationAirport,
            string weekDayOfDeparture,
            string timeOfDeparture,
            ushort seatsAvailable,
            double cost)
        {
            _flightCode = flightCode;
            _airline = airline;
            _originAirport = originAirport;
            _destinationAirport = destinationAirport;
            _weekDayOfDeparture = weekDayOfDeparture;
            _timeOfDeparture = timeOfDeparture;
            _seatsAvailable = seatsAvailable;
            _cost = cost;
        }

        // =========================================  METHODS  ========================================
        public override string ToString()
        {
            return $"{_flightCode}, {_airline}, {_originAirport}, {_destinationAirport}, {_weekDayOfDeparture}, {_timeOfDeparture}, {_cost}";
        }
    }
}