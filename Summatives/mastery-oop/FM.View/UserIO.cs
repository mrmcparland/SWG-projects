using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.View
{
    public class UserIO
    {
        public bool ReadName(string cName)
        {
            var list = new[] { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "\"" };
            return list.Any(cName.Contains);
        }
        public string ReadString(string prompt)
        {
            string UserInput = "";

            while (UserInput == "")
            {
                Console.WriteLine(prompt);
                UserInput = Console.ReadLine().Trim();

                if(UserInput == "")
                {
                    Console.WriteLine("That was not a valid input.  Please try again");
                }
            }
            return UserInput;
        }
        public int ReadInt(string prompt, int min, int max)
        {
            int output;

            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out output))
                {
                    if (output >= min && output <= max)
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
        public DateTime ReadDate()
        {
            DateTime dt;
            Console.WriteLine("Enter the date of the order in MM/DD/YYYY format: ");
            while(true)
            {
                
                string ParseDate = Console.ReadLine();
                
                if (DateTime.TryParse(ParseDate, out dt))
                {
                    //does dt match one of the order files?
                    if(dt > DateTime.Now)
                    {
                        
                        break;
                    }
                    else if (dt< DateTime.Now)
                    {
                        Console.WriteLine("Date must be in the future!");
                    }
                    else if(ParseDate == "")
                    {
                        Console.WriteLine("Please enter a valid date.");
                    }
                    else
                    {
                        Console.WriteLine("Date not found among order files; please try again.");
                    }
                    
                }
                
                else
                {
                    Console.WriteLine("Unable to read date, please try again.");

                }
            }
            return dt;
        }
        
        public DateTime ReadDateAny()
        {
            DateTime dt;
            Console.WriteLine("Enter the date of the order in MM/DD/YYYY format: ");
            while (true)
            {

                string ParseDate = Console.ReadLine();

                if (DateTime.TryParse(ParseDate, out dt))
                {
                    if (ParseDate == "")
                    {
                        Console.WriteLine("Please enter a valid date.");
                    }
                    else
                    {
                        break;
                    }

                }

                else
                {
                    Console.WriteLine("Unable to read date, please try again.");

                }
            }
            return dt;
        }
        public decimal ReadDecimal(string ParseDecimal)
        {
            string UserInput = "";

            while(UserInput == "")
            {
                Console.WriteLine(ParseDecimal);
                UserInput = Console.ReadLine().Trim();
                try
                {
                    if (UserInput == "")
                    {
                        Console.WriteLine("Not valid input, please try again");
                        UserInput = "";
                    }
                    else if (Convert.ToDecimal(UserInput) < 100)
                    {
                        Console.WriteLine("Please enter a value greater than 100.");
                        UserInput = "";
                    }
                }
                catch(System.FormatException)
                {
                    Console.WriteLine("Not valid input, please try again");
                    UserInput = "";
                }
                
            }
            decimal amt = decimal.Parse(UserInput);

            return amt;
        }
        public int ReadOrderNumber(string prompt)
        {
            int output;

            while(true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput, out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unable to locate order number, please try again.");
                }
            }
            return output;

        }
        public bool ReadOrderConfirm(string prompt)
        {
            
            string UserInput = "";
            while(UserInput == "")
            {
                Console.WriteLine(prompt);
                UserInput = Console.ReadLine().Trim();
                if (UserInput != "N" && UserInput != "Y")
                {
                    Console.WriteLine("Please enter 'Y' for yes or 'N' for no.");
                    UserInput = "";
                    continue;
                }
                else if (UserInput == "Y")
                {

                    break;
                    
                }
                else if (UserInput == "N")
                {
                    
                    break;
                    
                }
                

            }
            if(UserInput == "Y")
            {
                return true;
            }
            else if(UserInput == "N")
            {
                return false;
            }
            return false;
        }
        

    }
}
