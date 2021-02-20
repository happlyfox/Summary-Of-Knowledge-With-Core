using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.AbstractFactory
{
    public interface IFruitFactory
    {
        Fruit CreateApple(string name);
        Fruit CreateOrange(string name);
    }
}
