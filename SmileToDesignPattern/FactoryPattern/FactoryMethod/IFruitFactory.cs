using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.FactoryMethod
{
    public interface IFruitFactory
    {
        Fruit CreateFruit();
    }
}
