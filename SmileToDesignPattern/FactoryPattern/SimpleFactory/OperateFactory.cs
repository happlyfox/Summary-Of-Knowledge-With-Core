using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Pattern
{
    public class OperateFactory
    {
        public static Operate GetOperateFactory(string operate)
        {
            Operate fac = null;
            switch (operate)
            {
                case "+":
                    fac = new OperateAdd();
                    break;
                case "-":
                    fac = new OperateSub();
                    break;
                case "*":
                    fac = new OperateMul();
                    break;
                case "/":
                    fac = new OperateDiv();
                    break;
                default:
                    break;
            }
            return fac;
        }

    }
}
