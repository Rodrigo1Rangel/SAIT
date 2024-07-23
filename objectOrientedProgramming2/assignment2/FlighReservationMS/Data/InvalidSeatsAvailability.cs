using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    internal class InvalidSeatsAvailability : Exception
    {
            public InvalidSeatsAvailability()
            {
                Console.WriteLine($"\nThere is no seat available left in this flight.");
            }
    }
}
