using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Interfaces_AbstractClass
{
    internal abstract class Animal : IAnimal
    {
        // -------------------------- FIELDS --------------------------
        private string _name;
        private string _colour;
        private int _age;

        // ------------------------ PROPERTIES ------------------------
        public string Name { get { return _name; } set { _name = value; } }
        public string Colour { get { return _colour; } set { _colour = value; } }
        public int Age { get { return _age; } set { _age = value; } }

        // ------------------------- METHODS --------------------------
        public abstract void Eat();
        public abstract void Cry();
    }
}
