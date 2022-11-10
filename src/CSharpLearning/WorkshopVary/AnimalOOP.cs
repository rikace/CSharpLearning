using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopVary
{
    public class Animal //: IComparer
    {
        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get;
            private set;
        }


        public override bool Equals(object obj)
        {
            Animal inputAnimal = obj as Animal;
            if (inputAnimal != null)
            {
                return inputAnimal.Name == this.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public virtual string Eat()
        {
            string message = "Animal eat food";
            Console.WriteLine(message);
            return message;
        }


        public override string ToString()
        {
            return $"The name of {base.ToString()} is {this.Name}";
        }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {

        }

        public Cat() : this("Stellina")
        {

        }

        public override string Eat()
        {
            Console.WriteLine("Cat eats fish");
            return "Cat eats fish";
        }

    }


    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {

        }
    }
}
