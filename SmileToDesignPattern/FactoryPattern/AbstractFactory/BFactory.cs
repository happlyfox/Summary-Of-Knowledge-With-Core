using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.AbstractFactory
{
    public class BFactory : IFruitFactory
    {
        public Fruit CreateApple(string name)
        {
            return new Apple(name);
        }

        public Fruit CreateOrange(string name)
        {
            return new Orange(name);
        }
    }
}
