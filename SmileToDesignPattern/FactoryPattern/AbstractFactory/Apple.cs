using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.AbstractFactory
{
    public class Apple : Fruit
    {
        public Apple(string name)
        {
            this.Name = name;
        }

        public override void PrintfColor()
        {
            Console.WriteLine(this.Name + "红色");
        }

        public override void PrintfName()
        {
            Console.WriteLine(this.Name + "苹果");
        }
    }
}
