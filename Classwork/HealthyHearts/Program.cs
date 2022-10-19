using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            string AgeInput;
            int YourAge, MaxHeartRate; 
            Double TargetZoneMin, TargetZoneMax;
            Console.WriteLine("What is your age?");
            AgeInput = Console.ReadLine();
            YourAge = Convert.ToInt32(AgeInput);

            MaxHeartRate = 220 - YourAge;

            TargetZoneMax = .85 * MaxHeartRate;
            TargetZoneMin = .5 * MaxHeartRate;

            Console.WriteLine("Your maximum heart rate should be " + MaxHeartRate + " and your target HR zone is between " + TargetZoneMin + " and " + TargetZoneMax + " beats per minute.");
            Console.ReadLine();

        }
    }
}
