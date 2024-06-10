using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Interfaces_AbstractClass
{
    internal class Cat : Animal
    {
        // ------------------------- METHODS --------------------------
        public override void Eat()
        {
            Console.WriteLine("Cats eat mice.");
        }
        public override void Cry()
        {
            Console.WriteLine("Meow!");
        }
    }
}
