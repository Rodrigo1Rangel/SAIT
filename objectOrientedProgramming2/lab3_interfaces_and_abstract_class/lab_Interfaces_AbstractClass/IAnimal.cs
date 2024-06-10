using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_Interfaces_AbstractClass
{
    internal interface IAnimal
    {
        // ------------------------ PROPERTIES ------------------------
        string Name { get ; set; }
        string Colour { get; set; }
        double Height { get; set; }
        int Age { get; set; }

        // ------------------------- METHODS --------------------------
        void Eat();
        void Cry();
    }
}
