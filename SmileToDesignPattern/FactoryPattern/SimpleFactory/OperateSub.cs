using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Pattern
{
    public class OperateSub : Operate
    {
        public override double GetResult()
        {
            return this.NumberA - this.NumberB;
        }
    }
}
