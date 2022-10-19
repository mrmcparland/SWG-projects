using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestForUserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            string yourName;
            string yourQuest;
            double velocityOfSwallow;

            Console.WriteLine("What is your name? ");
            yourName = Console.ReadLine();

            Console.WriteLine("What is your quest? ");
            yourQuest = Console.ReadLine();

            Console.WriteLine("What is the airspeed velocityof an unladen swallow?");
            velocityOfSwallow = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.Write("How do you know " + velocityOfSwallow + " is correct, " + yourName + "?");
            Console.WriteLine("You didn't even know if the swallow was African or European!");
            Console.WriteLine("Maybe skip answering things about birds and instead go " + yourQuest + ".");
            Console.ReadLine();
        }
    }
}
