using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.FactoryMethod
{
    public class Apple : Fruit
    {
        public override void PrintfColor()
        {
            Console.WriteLine("红色");
        }

        public override void PrintfName()
        {
            Console.WriteLine("苹果");
        }
    }
}
