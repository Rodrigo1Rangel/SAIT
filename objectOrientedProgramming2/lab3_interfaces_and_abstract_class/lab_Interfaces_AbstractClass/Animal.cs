using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Interfaces_AbstractClass
{
    internal abstract class Animal : IAnimal
    {
        public enum AnimalSpecie
        {
            cat,
            dog
        }

        // -------------------------- FIELDS --------------------------
        private string _name;
        private string _colour;
        private int _age;
        private double _height;
        private AnimalSpecie _specie;

        // ------------------------ PROPERTIES ------------------------
        public string Name { get { return _name; } set { _name = value; } }
        public string Colour { get { return _colour; } set { _colour = value; } }
        public double Height { get { return _height; } set { _height = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public AnimalSpecie Specie { get { return _specie; } set { _specie = value; } }


        // ------------------------- METHODS --------------------------
        public abstract void Eat();
        public abstract void Cry();
    }
}
