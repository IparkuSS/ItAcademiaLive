using System;
using System.Collections.Generic;
using System.Text;

namespace Anton.Live
{
    public class Calculator
    {
        public Calculator(double num1, double num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
        }

        public double Num1 { get; }
        public double Num2 { get; }

        public double SumNum()
        {
            return Num1 + Num2;
        }

    }
}
