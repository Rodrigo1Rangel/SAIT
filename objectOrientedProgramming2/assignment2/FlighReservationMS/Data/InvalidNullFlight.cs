using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    internal class InvalidNullFlight : Exception
    {
        public InvalidNullFlight()
        {
            Console.WriteLine($"\nA flight must be selected upon reservation creation.");
        }
    }
}
