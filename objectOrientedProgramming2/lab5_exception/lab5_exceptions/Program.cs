using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circlePositiveRadius = new Circle(10);

            Circle circleNegativeRadius = new Circle(-10);

            Circle circleZeroRadius = new Circle(0);
        }
    }
}