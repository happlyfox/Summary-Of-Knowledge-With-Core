using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Pattern
{
    /// <summary>
    /// 乘法
    /// </summary>
    public class OperateMul : Operate
    {
        public override double GetResult()
        {
            return this.NumberA * this.NumberB;
        }
    }
}
