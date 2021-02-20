using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.FactoryMethod
{
    public class OrangeFactory : IFruitFactory
    {
        public Fruit CreateFruit()
        {
            return new Orange();
        }
    }
}
