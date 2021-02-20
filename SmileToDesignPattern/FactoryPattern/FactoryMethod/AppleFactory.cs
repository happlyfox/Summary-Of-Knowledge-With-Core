using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.FactoryMethod
{
    public class AFactory : IFruitFactory
    {
        public Fruit CreateFruit()
        {
            return new Apple();
        }
    }
}
