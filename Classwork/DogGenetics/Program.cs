using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> BreedList = new List<string>() {"Blue Heeler","Corgi","German shepherd","Malinois","Chocolate Lab","Black Lab","Yellow Lab","Chesapeake Bay Retriever","Golden Retreiver","Alaskan Malamute", "Siberian Husky", "Newfoundland", "Boxer", "Beagle", "Basset Hound", "Irish Setter", "Border Collie", "Great Dane", "Greyhound", "French Bulldog", "American Bulldog", "English Bulldog", "Boston Terrier" };

            string YourDogName;
            int DogMixInt;
            Random r = new Random();
            
            Random DogMixRand = new Random();

            DogMixInt = DogMixRand.Next(1, 6);
           
            List<int> BreedsPerDogList = new List<int>();

            

            int BreedPercentage = r.Next(1, 95);

           
            for(int i = DogMixInt-1; i >0; i--)
            {
                int AddToBreed = 100 - BreedPercentage;
                int RemainderToBreed = r.Next(1, AddToBreed);
                BreedsPerDogList.Add(RemainderToBreed);
                

            }

            int LastBreedPiece = 100 - BreedsPerDogList.Sum();
            
            int runningTotal = BreedsPerDogList.Sum() + LastBreedPiece;

            
            BreedsPerDogList.Add(LastBreedPiece);
          
            
            Console.WriteLine("What is the name of your dog?");
            YourDogName = Console.ReadLine();
            Console.WriteLine(YourDogName + " is :");
            
            while(BreedsPerDogList.Count > 0)
            {
                 for(int i = DogMixInt ; i > 0; i--)
                {
                    int BreedCount = r.Next(BreedList.Count);
                    Console.WriteLine(BreedsPerDogList[i - 1] + "% " + BreedList[BreedCount]);
                   
                    BreedList.RemoveAt(BreedCount);
                    BreedsPerDogList.RemoveAt(i-1);

                    
                    
                    

                }
            }
            Console.WriteLine("That is QUITE a dog");
            Console.ReadLine();
            
            


        }
    }
}
