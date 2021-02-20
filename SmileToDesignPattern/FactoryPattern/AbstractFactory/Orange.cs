using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.AbstractFactory
{
    public class Orange : Fruit
    {
        public Orange(string name)
        {
            this.Name = name;
        }

        public override void PrintfColor()
        {
            Console.WriteLine(this.Name + "橘黄色");
        }

        public override void PrintfName()
        {
            Console.WriteLine(this.Name + "橘子");
        }
    }
}
