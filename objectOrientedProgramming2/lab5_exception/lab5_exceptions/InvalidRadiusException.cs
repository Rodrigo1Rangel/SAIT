using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_exceptions
{
    internal class InvalidRadiusException : Exception
    {
        // ---------------------------- CONSTRUCTORS -------------------------------
        public InvalidRadiusException()
        {
            Console.WriteLine("\nRadius is greater than zero.");
        }

        public InvalidRadiusException(double radius)
        {
            Console.WriteLine($"\nA radius of {radius} is not valid. It must be greater than zero.");
        }
    }
}
