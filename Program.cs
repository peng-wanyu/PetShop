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
        static int AddDogNum;
        static int ReduceDogNum;
        static Dog()
        {
            AddDogNum = 0;
            ReduceDogNum = 0;
         }

        public Dog(string name) : base(name)
        {
            ++AddDogNum;
            --ReduceDogNum;
        }
        new public void PrintName()
        {
            Console.WriteLine( "宠物的名字是"+_name);
        }
        sealed override public void Speak()
        {
            Console.WriteLine(_name + "的叫声是;"+"wow");
        }
        public void Swim()
        {
            Console.WriteLine(_name + "会游泳");
        }
        public void LookHouse()
        {
            Console.WriteLine(_name + "会看家");
        }
        public override void Move()
        {
        }
        static public void ShowDogNum()
        {
            Console.WriteLine("宠物店一共收养过"+ AddDogNum + "只狗"+"被领走"+-ReduceDogNum+"只狗");
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
        static int AddCatNum;
        static int ReduceCatNum;
        static Cat()
        {
            AddCatNum = 0;
            ReduceCatNum = 0;
        }
        public Cat(string name) : base(name)
        {
            ++AddCatNum;
            --ReduceCatNum;
        }
        public override void Speak()
        {
            Console.WriteLine(_name + " 的叫声是:"+"meow");
        }
        public void CatchMice()
        {
            Console.WriteLine(_name+"会抓老鼠");
        }
        public void ClimbTree()
        {
            Console.WriteLine(_name+"会爬树");
        }
        static public void ShowCatNum()
        {
            Console.WriteLine("宠物店一共收养过" + AddCatNum + "只猫" + "被领走" +- ReduceCatNum + "只猫");
        }
    }

    static public class PetGuide
    {
        static public void vedio(this Pet pet)
        {
            Console.WriteLine("播放喂养指南");
        }
        static public void FeedCat(this Cat cat)
        {
            Console.WriteLine("猫喜欢吃鱼，食物以蛋白质为主");
        }
        static public void FeedDog(this Dog dog)
        {
            Console.WriteLine("狗喜欢吃肉，食物以蛋白质为主");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pet[] pets = new Pet[] { new Dog("Jack"),new Dog("Kiki"), new Cat("Tom"),new Cat("CoCo") };
            for (int i = 0; i<pets.Length; ++i)
            {
                pets[i].Speak();
            }
            Cat CoCo = new Cat("CoCo");
            IClimbTree climb = (IClimbTree)CoCo;
            ICatchMice catchM = (ICatchMice)CoCo;
            climb.ClimbTree();
            CoCo.CatchMice();
            CoCo.FeedCat();
            CoCo.vedio();


            Dog Jack = new Dog("Jcak");
            Jack.Swim();
            Jack.LookHouse();
            Jack.FeedDog();
            Jack.vedio();
            




            Dog.ShowDogNum();
            Cat.ShowCatNum();
        }
    }
}



/*宠物被领养数量错误，且Tom2数据隐藏
 
    
     
     
 */
