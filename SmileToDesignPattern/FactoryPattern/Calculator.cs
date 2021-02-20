using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class Calculator
    {
        public double GetResult(double A, double B, string operate)
        {
            double result = 0d;
            switch (operate)
            {
                case "+": 
                    result = A + B;
                    break;
                case "-":
                    result = A - B;
                    break;
                case "*":
                    result = A * B;
                    break;
                case "/":
                    result = A / B;
                    break;
                default: break;
            }
            return result;
        }
    }
}
