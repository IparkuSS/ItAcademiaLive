using System.Threading.Channels;

namespace Anton.Live
{
    class Program
    {
        static void Main()
        {

            var calc = new Calculator(2.4, 5);

            Console.WriteLine(calc.SumNum()); 




        }

    }
}
