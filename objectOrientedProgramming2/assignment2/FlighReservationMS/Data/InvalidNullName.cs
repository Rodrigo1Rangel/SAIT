using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighReservationMS.Data
{
    internal class InvalidNullName : Exception
    {
        public InvalidNullName()
        {
            Console.WriteLine($"\nA customer's name must be entered upon reservation creation.");
        }
    }
}
