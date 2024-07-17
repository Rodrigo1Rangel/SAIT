using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    internal class InvalidNullCitizenship : Exception
    {
        public InvalidNullCitizenship()
        {
            Console.WriteLine($"\nA customer's citizenship must be entered upon reservation creation.");
        }
    }
}
