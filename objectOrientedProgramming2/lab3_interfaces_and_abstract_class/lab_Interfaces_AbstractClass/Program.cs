using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static lab_Interfaces_AbstractClass.Animal;


namespace lab_Interfaces_AbstractClass
{
    internal class Program
    {
        // -------------------------- FIELDS --------------------------
        static private List<Animal> _listRegisteredAnimals = new List<Animal>();

        // ------------------------ PROPERTIES ------------------------
        static public List<Animal> ListRegisteredAnimals { get { return _listRegisteredAnimals; } set { _listRegisteredAnimals = value; } }

        // --------------------------- MAIN ---------------------------
        static void Main(string[] args)
        {
            string specieEnumList = "";
            foreach (string specieEnum in Enum.GetNames(typeof(AnimalSpecie)))
                specieEnumList += specieEnum + ", ";

            // --------------------------- LAB PART 1 ---------------------------
            Console.WriteLine($"\nPART 1\n");
            
            // DOG
            Dog myDog = new Dog();
            myDog.Name = "Ritsu";
            myDog.Colour = "gray";
            myDog.Age = 2;

            Console.WriteLine($"\n My {myDog.Colour} dog {myDog.Name} is {myDog.Age} years old.");

            // CAT
            Cat myCat = new Cat();
            myCat.Name = "Lin";
            myCat.Colour = "black";
            myCat.Age = 3;

            Console.WriteLine($"\n My {myDog.Colour} cat {myCat.Name} is {myCat.Age} years old.");



            // --------------------------- LAB PART 2 ---------------------------
            Console.WriteLine($"\n\nPART 2\n\n");
            Console.Write($" * Welcome to the Animal system *");

            string menuUserSelection;
            do
            {
                Console.Write($"\n\n Select a menu option to continue \n\n 1. Register an animal.\n 2. Read the name of the animals registered in the system.\n 0. Exit the system.\n\n > ");
                menuUserSelection = Console.ReadLine();

                switch (menuUserSelection)
                {
                    case "1":
                        Console.Write($"\nChose an available Animal specie to register: ");
                        Console.Write(specieEnumList.TrimEnd(',', ' ') + "\n > ");
                        string specieUserSelection = Console.ReadLine().ToLower();
                        AnimalSpecie animalSpecieSelection;
                        Enum.TryParse(specieUserSelection, out animalSpecieSelection);
                        IniciateAnimal(animalSpecieSelection);
                        break;
                    case "2":
                        ReadListAnimalName();
                        break;
                    default:
                        Console.WriteLine("\n Please, enter a valid option.");
                        // TO FIX: any string with a letter defaults to the first enum AnimalSpecie
                        break;

                }
            } while (menuUserSelection != "0") ;

        }

        // ------------------------- METHODS --------------------------
        public static void IniciateAnimal(AnimalSpecie animalCategory)
        {
            if (animalCategory == AnimalSpecie.dog)
            {
                Animal newAnimal = new Dog();
                newAnimal.Specie = AnimalSpecie.dog;
                ListRegisteredAnimals.Add(RegisterAnimal(newAnimal));
            }
            else if (animalCategory == AnimalSpecie.cat)
            {
                Animal newAnimal = new Cat();
                newAnimal.Specie = AnimalSpecie.cat;
                ListRegisteredAnimals.Add(RegisterAnimal(newAnimal));
            }
            else if (animalCategory != AnimalSpecie.cat && animalCategory != AnimalSpecie.dog)
                Console.WriteLine("There is no such specie available in the system.");
        }

        public static Animal RegisterAnimal(Animal newAnimal)
        {
            int intAgeInput;
            bool isValidAge = false;
            double doubleHeightInput;
            bool isValidHeight = false;

            // NAME
            Console.Write($"\nEnter the name of the {newAnimal.Specie}: ");
            newAnimal.Name = Console.ReadLine();

            // HEIGHT
            Console.Write($"Enter the height of the {newAnimal.Specie}: ");
            do
            {
                string stringHeightInput = Console.ReadLine();
                isValidHeight = double.TryParse(stringHeightInput, out doubleHeightInput);

                if (!isValidHeight)
                {
                    Console.Write("\nPlease enter a valid height. \n > ");
                    stringHeightInput = Console.ReadLine();
                    isValidHeight = double.TryParse(stringHeightInput, out doubleHeightInput);
                }

            } while (isValidHeight == false);
            newAnimal.Height = doubleHeightInput;

            // COLOUR
            Console.Write($"Enter the colour of the {newAnimal.Specie}: ");
            newAnimal.Colour = Console.ReadLine();

            // AGE
            Console.Write($"Enter the age of the {newAnimal.Specie}: ");
            do
            {
                string stringAgeInput = Console.ReadLine();
                isValidAge = int.TryParse(stringAgeInput, out intAgeInput);
                
                if (!isValidAge)
                {
                    Console.Write("\nPlease enter a valid age. \n > ");
                    stringAgeInput = Console.ReadLine();
                    isValidAge = int.TryParse(stringAgeInput, out intAgeInput);
                }

            } while (isValidAge == false);
            newAnimal.Age = intAgeInput;

            return newAnimal;
        }

        public static void ReadListAnimalName()
        {
            string listAnimalNames = "";
            foreach (Animal animal in ListRegisteredAnimals)
                listAnimalNames += animal.Name + ", ";
            if (listAnimalNames == "")
                Console.WriteLine($"\nThere is no animal currently registered in the system.");
            else
                Console.WriteLine($"\nThe following animals are registered in the system: {listAnimalNames.TrimEnd(',', ' ')}.");
        }
    }
}
