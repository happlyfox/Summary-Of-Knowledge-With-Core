using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Pattern
{
    public class OperateDiv : Operate
    {
        public override double GetResult()
        {
            return this.NumberA / this.NumberB;
        }
    }
}
