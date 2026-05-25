using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olga.Live
{
    public class Numbers
    {

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public Numbers(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }
        public int GetSum()
        {
            return FirstNumber + SecondNumber;
        }
    }
}
