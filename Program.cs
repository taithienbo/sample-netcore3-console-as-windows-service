using System;
using System.IO;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentTime = DateTime.Now;
            var holder = "";
            if (currentTime.Hour < 12)
            {
                holder = "morning";
            }
            else if (currentTime.Hour > 12 && currentTime.Hour < 17)
            {
                holder = "afternoon";
            }
            else
            {
                holder = "Evening";
            }
            using (var fs = new StreamWriter("output.txt", true))
            {
                fs.WriteLine($"Good {holder}. The time is {currentTime}");
            }          
        }
    }
}
