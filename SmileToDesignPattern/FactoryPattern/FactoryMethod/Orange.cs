using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.FactoryMethod
{
    public class Orange : Fruit
    {
        public override void PrintfColor()
        {
            Console.WriteLine("橘黄色");
        }

        public override void PrintfName()
        {
            Console.WriteLine("橘子");
        }
    }
}
