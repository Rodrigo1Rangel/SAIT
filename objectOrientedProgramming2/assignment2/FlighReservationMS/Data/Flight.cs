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

        static private List<Flight> _flightList = new List<Flight>();
        static private List<Flight> _matchingFlights = new List<Flight>();

        // =======================================  PROPERTIES =======================================
        public string OriginAirport { get { return _originAirport; }}
        public string DestinationAirport { get { return _destinationAirport; } }
        public string WeekDayOfDeparture { get { return _weekDayOfDeparture; } }
        public string TimeOfDeparture { get { return _timeOfDeparture; } }
        public string FlightCode { get { return _flightCode; } }
        public string Airline { get { return _airline; } }
        public double Cost { get { return _cost; } }
        public ushort SeatsAvailable { get { return _seatsAvailable; } set { value = _seatsAvailable; } }

        static public List<Flight> FlightList { get { return _flightList; } set { _flightList = value; } }
        static public List<Flight> MatchingFlights { get { return _matchingFlights; } set { _matchingFlights = value; } }

        // =======================================  CONSTRUCTOR  ======================================
        protected Flight(
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
            return $"{_flightCode.ToUpper()}, {_airline.ToUpper()}, {_originAirport.ToUpper()}, {_destinationAirport.ToUpper()}, {_weekDayOfDeparture.ToUpper()}, {_timeOfDeparture}, {_cost}";
        }

        public static List<Flight> DigestFlightFile()
        // Parse the flights.csv file into a single list
        {
            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            string[] datasetPerLine = Resources.flights.Split('\n');

            foreach (string line in datasetPerLine)
            {
                //Skip empty lines from within the flights text file.
                if (line == "\n")
                    continue;

                char delimiter = ',';
                string[] flightData = line.TrimEnd(delimiter).TrimStart('\n').Split(delimiter);

                // Converts and assigns each string from the flights text file to its respective
                // variable related to the Flight class.
                ushort.TryParse(flightData[6].Trim(), out ushort seatsAvailable);
                double.TryParse(flightData[7].Trim(), out double cost);

                Flight flight =
                    new Flight(
                    flightData[0].ToLower(),
                    flightData[1].ToLower(),
                    flightData[2].ToLower(),
                    flightData[3].ToLower(),
                    flightData[4].ToLower(),
                    flightData[5].ToLower(),
                    seatsAvailable,
                    cost);

                FlightList.Add(flight);
                }
            return FlightList;
        }

        public static List<Flight>? searchListOfFlight(
            // it could be a void method
            string originAirport,
            string destinationAirport,
            string weekDayOfDeparture)
        {
            for (int i = 0; i < FlightList.Count; i++)
            {
                if (FlightList[i].OriginAirport == originAirport &&
                    FlightList[i].DestinationAirport == destinationAirport &&
                    FlightList[i].WeekDayOfDeparture == weekDayOfDeparture)
                // if (FlightList[i] == searchingFlight)
                {
                    if (!_matchingFlights.Contains(FlightList[i]))
                    {
                        _matchingFlights.Add(FlightList[i]);
                    }
                }
            }
            return _matchingFlights;
        }
    }
}