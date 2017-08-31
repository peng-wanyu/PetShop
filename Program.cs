using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    interface ICatchMice
    {
        void CatchMice();
    }
    interface IClimbTree
    {
        void ClimbTree();
    }
    abstract public class Pet
    {
        public Pet(string name)
        {
            _name = name;
        }
        protected string _name;
        public void PrintName()
        {
            Console.WriteLine( "Pent's name is "+_name);
        }
        abstract public void Speak();
        virtual public void Move()
        {
        }
    }
    public class Dog:Pet
    {
        public Dog(string name) : base(name)
        {
        }
        new public void PrintName()
        {
            Console.WriteLine( "宠物的名字是"+_name);
        }
        sealed override public void Speak()
        {
            Console.WriteLine(_name + " is speaking:"+"wow");
        }
        public override void Move()
        {
        }
    }
    public class Labrador : Dog
    {
        public Labrador(string name)
            : base(name)
        {
        }
    }
    public class Cat:Pet,ICatchMice,IClimbTree
    {
        public Cat(string name) : base(name)
        {
        }
        public override void Speak()
        {
            Console.WriteLine(_name + " is speaking:"+"meow");
        }
        public void CatchMice()
        {
            Console.WriteLine("Catch mice");
        }
        public void ClimbTree()
        {
            Console.WriteLine("Climb tree");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pet[] pets = new Pet[] { new Dog("Jack"), new Cat("Tom") };
            for (int i = 0; i<pets.Length; ++i)
            {
                pets[i].Speak();
            }
            Cat c = new Cat("Tom2");
            IClimbTree climb = (IClimbTree)c;
            c.CatchMice();
            climb.ClimbTree();
            ICatchMice catchM = (ICatchMice)c;
            catchM.CatchMice();
        }
    }
}
