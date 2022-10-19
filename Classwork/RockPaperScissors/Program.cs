using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        
        public static void Main()
        {
            string MaxRounds, UserChoice;
            string UserChoiceDisplay, ComputerChoiceDisplay, AnotherRound;
            int CurrentRound = 1;
            int MaxRoundsInt;
            int UserWin = 0, ComputerWin = 0, Tie = 0;
            int UserChoiceInt;
            bool PlayAgain = true;
            //int CompChoiceInt;
            Random CompChoice = new Random();

            Console.WriteLine("Let's play Rock, Paper, Scissors");
            Console.WriteLine("How many rounds would you like to play? Max of 10.");
            MaxRounds = Console.ReadLine();
            MaxRoundsInt = Convert.ToInt32(MaxRounds);
            if (MaxRoundsInt > 10 || MaxRoundsInt < 1)
            {
                Console.WriteLine("That is not a valid amount of rounds; press any key to exit.");
                Console.ReadLine();
                return;
            }
            while (PlayAgain == true) 
            {
                while (CurrentRound <= MaxRoundsInt)
                {
                    Console.WriteLine("What is your choice for this round? Input 1 for Rock, 2 for Paper, or 3 for Scissors");
                    UserChoice = Console.ReadLine();
                    UserChoiceInt = Convert.ToInt32(UserChoice);

                    int CompChoiceInt = CompChoice.Next(1, 4);
                    if (UserChoiceInt == 1)
                    {
                        UserChoiceDisplay = "Rock";
                    }
                    else if (UserChoiceInt == 2)
                    {
                        UserChoiceDisplay = "Paper";
                    }
                    else
                    {
                        UserChoiceDisplay = "Scissors";
                    }
                    if (CompChoiceInt == 1)
                    {
                        ComputerChoiceDisplay = "Rock";
                    }
                    else if (CompChoiceInt == 2)
                    {
                        ComputerChoiceDisplay = "Paper";
                    }
                    else
                    {
                        ComputerChoiceDisplay = "Scissors";
                    }
                    if (UserChoiceInt == CompChoiceInt)
                    {
                        Console.WriteLine("We have a tie! You chose " + UserChoiceDisplay);
                        Console.Write("The computer chose " + ComputerChoiceDisplay);
                        Console.WriteLine();

                        Tie++;
                        CurrentRound++;

                    }
                    else if (UserChoiceInt == 1 && CompChoiceInt == 2)
                    {
                        Console.WriteLine("You win! You chose " + UserChoiceDisplay);
                        Console.WriteLine("The computer chose " + ComputerChoiceDisplay);
                        UserWin++;
                        CurrentRound++;
                    }
                    else if (UserChoiceInt == 1 && CompChoiceInt == 3)
                    {
                        Console.WriteLine("You lost; you chose " + UserChoiceDisplay);
                        Console.WriteLine("The computer chose " + ComputerChoiceDisplay);
                        ComputerWin++;
                        CurrentRound++;
                    }
                    else if (UserChoiceInt == 2 && CompChoiceInt == 1)
                    {
                        Console.WriteLine("You win! You chose " + UserChoiceDisplay);
                        Console.WriteLine("The computer chose " + ComputerChoiceDisplay);
                        UserWin++;
                        CurrentRound++;
                    }
                    else if (UserChoiceInt == 2 && CompChoiceInt == 3)
                    {
                        Console.WriteLine("You lost; you chose " + UserChoiceDisplay);
                        Console.WriteLine("The computer chose " + ComputerChoiceDisplay);
                        ComputerWin++;
                        CurrentRound++;
                    }
                    else if (UserChoiceInt == 3 && CompChoiceInt == 1)
                    {
                        Console.WriteLine("You lost; you chose " + UserChoiceDisplay);
                        Console.WriteLine("The computer chose " + ComputerChoiceDisplay);
                        ComputerWin++;
                        CurrentRound++;
                    }
                    else if (UserChoiceInt == 3 && CompChoiceInt == 2)
                    {
                        Console.WriteLine("You win! You chose " + UserChoiceDisplay);
                        Console.WriteLine("The computer chose " + ComputerChoiceDisplay);
                        UserWin++;
                        CurrentRound++;
                    }
                    Console.WriteLine(""); //for readability upon loop
                }

                Console.WriteLine("We have played all the rounds, " + (CurrentRound) + " in total");
                Console.WriteLine("You had " + UserWin + " victories, the computer had " + ComputerWin + " victories, and there were " + Tie + " ties.");
                if(UserWin>ComputerWin)
                {
                    Console.WriteLine("You have bested the computer!");
                }
                else if (ComputerWin > UserWin)
                {
                    Console.WriteLine("Sorry, the computer has beaten you overall.");
                }
                else if(ComputerWin == UserWin)
                {
                    Console.WriteLine("Looks like you and the computer are evenly matched!");
                }
                Console.WriteLine("Would you like to play again? Enter 'Y' for yes, any other response will be interpreted as a 'no'.");
                AnotherRound = Console.ReadLine();
                if(AnotherRound == "Y")
                {
                    
                    Console.WriteLine("How many rounds would you like to play? Max of 10.");
                    MaxRounds = Console.ReadLine();
                    MaxRoundsInt = Convert.ToInt32(MaxRounds)-1;
                    CurrentRound = 0;
                    Tie = 0;
                    UserWin = 0;
                    ComputerWin = 0;
                    PlayAgain = true;

                }
                else 
                {
                    Console.WriteLine("Thanks for playing! Press any key to exit.");
                    Console.ReadKey();
                    PlayAgain = false;
                    break;
                }
            }
            


        }
        
    }
}
