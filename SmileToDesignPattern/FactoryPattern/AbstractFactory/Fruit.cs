using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.AbstractFactory
{
    public abstract class Fruit
    {
        public string Name { get; set; }
        public abstract void PrintfColor();
        public abstract void PrintfName();
    }
}