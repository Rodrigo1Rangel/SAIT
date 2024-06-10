using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Interfaces_AbstractClass
{
    internal class Dog : Animal
    {
        // ------------------------- METHODS --------------------------
        public override void Eat()
        {
            Console.WriteLine("Dogs eat meat.");
        }
        public override void Cry()
        {
            Console.WriteLine("Woof!");
        }
    }
}
