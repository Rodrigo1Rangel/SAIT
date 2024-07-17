using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    public class Reservation : Flight
    {
        // ====================================  INSTANCE FIELDS =====================================
        private string _name;
        private string _citizenship;
        private string _status;
        private readonly string _reservationCode;

        // =======================================  PROPERTIES =======================================
        public string Name { get { return _name; } set { _name = value; } }
        public string Citizenship { get { return _citizenship; } set { _citizenship = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public string ReservationCode { get { return _reservationCode; } }

        // =========================================  METHODS  ========================================
        public override string ToString()
        {
            return $"{_reservationCode}, {_flightCode}, {_airline}, {_cost}, {_name}, {_citizenship}, {_status}";
        }

        // ======================================  CONSTRUCTOR  =======================================
        public Reservation(
            string flightCode,
            string airline,
            string originAirport,
            string destinationAirport,
            string weekDayOfDeparture,
            string timeOfDeparture,
            ushort seatsAvailable,
            double cost,
            string name,
            string citizenship,
            string status,
            string reservationCode) :
            base(
                flightCode,
                airline,
                originAirport,
                destinationAirport,
                weekDayOfDeparture,
                timeOfDeparture,
                seatsAvailable,
                cost)
        {
            _name = name;
            _citizenship = citizenship;
            _status = status;
            _reservationCode = reservationCode;
        }
    }
}
