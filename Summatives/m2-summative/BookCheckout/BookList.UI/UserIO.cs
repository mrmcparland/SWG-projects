using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.UI
{
    public class UserIO
    {
        public string ReadString(string prompt)
        {
            string UserInput = "";

            while(UserInput == "")
            {
                Console.WriteLine(prompt);
                UserInput = Console.ReadLine().Trim();

                if(UserInput == "")
                {
                    Console.WriteLine("That was not a valid input. Try again.");
                }
            }
            return UserInput;
        }
        public int ReadInt(string prompt, int min, int max)
        {
            int output;

            while(true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput,out output))
                {
                    if(output >= min && output <=max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That number was not between {0} and {1}. Please try again.", min, max);
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input, please try again.");
                }
            }
            return output;
        }
    }
}
