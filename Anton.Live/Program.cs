using System.Threading.Channels;

namespace Anton.Live
{
    class Program
    {
        static void Main()
        {
            var statusTracker = new StatusTracker();
            
            Console.WriteLine(statusTracker.Status);

            statusTracker.SetStatus("Good");

            Console.WriteLine(statusTracker.Status);

            //statusTracker.Status = "";
        }
    }
}
