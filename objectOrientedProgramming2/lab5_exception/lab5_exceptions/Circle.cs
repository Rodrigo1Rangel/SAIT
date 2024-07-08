using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_exceptions
{
    internal class Circle
    {
        // --------------------------- INSTANCE FIELDS -----------------------------
        private double _radius;

        // ----------------------------- PROPERTIES --------------------------------

        public double Radius { get { return _radius; } set { _radius = value; } }

        // ---------------------------- CONSTRUCTORS -------------------------------

        public Circle (double radius)
        {
            SetRadius(radius);
        }

        // ------------------------------- METHODS ---------------------------------

        public void SetRadius(double radius) 
        {
            try
            {
                if (radius > 0)
                    Radius = radius;
                else
                    throw new InvalidRadiusException(radius);
            }
            catch (InvalidRadiusException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
