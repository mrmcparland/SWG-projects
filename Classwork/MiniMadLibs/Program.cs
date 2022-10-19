using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMadLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            string noun1, adjective1, noun2, number, adjective2, pluralNoun1, pluralNoun2, verbPresent, verbPast, pluralNoun3 ;

            Console.WriteLine("I need a noun: ");
            noun1 = Console.ReadLine();
            Console.WriteLine("Now an adjective: ");
            adjective1 = Console.ReadLine();
            Console.WriteLine("Another noun: ");
            noun2 = Console.ReadLine();
            Console.WriteLine("And a number: ");
            number = Console.ReadLine();
            Console.WriteLine("Another adjective: ");
            adjective2 = Console.ReadLine();
            Console.WriteLine("A plural noun: ");
            pluralNoun1 = Console.ReadLine();
            Console.WriteLine("Another one: ");
            pluralNoun2 = Console.ReadLine();
            Console.WriteLine("One more: ");
            pluralNoun3 = Console.ReadLine();
            Console.WriteLine("A verb (infinitive form): ");
            verbPresent = Console.ReadLine();
            Console.WriteLine("Same verb (past participle): ");
            verbPast = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("*** NOW LET'S GET MAD(LIBS) ***");
            Console.WriteLine(noun1 + ": the " + adjective1 + " frontier.  These are the voyages of the starship " + noun2 + ".  It's the " + number + "-mission: ");
            Console.WriteLine("to explore strange " + adjective2 + " " + pluralNoun1 + ", to seek out " + adjective2 + " and " + adjective2 + " lettuce, to boldly " + verbPresent + " where no one ");
            Console.WriteLine("has " + verbPast + " before.");
            Console.ReadLine();

        }
    }
}
