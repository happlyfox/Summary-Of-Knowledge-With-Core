using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Pattern
{
    public abstract class Operate
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }

        public abstract double GetResult();
    }
}
