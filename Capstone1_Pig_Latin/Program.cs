//Mina Stanton
//January 24, 2020
//Program description: This program will take a word from the user as input and convert it into pig latin then display it on the console. 

using System;
using System.Text;

namespace Capstone1_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            //greeting the user 
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Hello, and welcome to Pig Latin encoder!");
            //created a while loop so the user can go again as many times as they want
            bool userContinue = true;
            while (userContinue)
            { 
                //prompting user to enter a word
                Console.WriteLine("Please enter a word:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                //input word from user and send to the method to find the vowel index
                string newWord = Console.ReadLine().ToLower();
                //sending word to check if the word contains a vowel or contains a "Y"
                bool containsVowel = HasVowel(newWord);
                if (containsVowel == true)
                {
                    int vowelIndex = FindVowel(newWord); //calling the function to find the index position of the vowel
                    PrintInPigLatin(newWord, vowelIndex);//calling function to print out the encoded text
                }
                else 
                {
                    bool containsY = ContainsY(newWord);
                        if (containsY == true)
                        { 
                            int yIndex = FindY(newWord);
                            PrintInPigLatin(newWord, yIndex);
                        }
                        else
                        {
                            Console.WriteLine("Sorry but what you entered is NOT a word!");
                        }
                }
                //prompting the user to see if they would like to enter another word
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Would like to enter another word? (y/n)");
                string userInput = Console.ReadLine().ToLower(); 
                //if the user doesn't enter a vaild y or n then it will keep prompting the user until they do
                while(userInput != "y" && userInput != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter (y) to continue or (n) to exit.");
                    userInput = Console.ReadLine().ToLower();
                }
                //if the user doesn't want to continue then it will exit the while loop
                if(userInput == "n")
                {
                    break; 
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Thanks trying out Pig Latin Encoder, Bye!");
        }

        //checks to see if the string contains a y and returns true or false
        public static bool ContainsY(string word)
        {
            bool y = false;
            for(int i = 0; i < word.Length; i++)
            {
                if(word[i] == 'y')
                {
                    y = true;
                    break;
                }
            }
            return y; 
        }
        //checks to see if the string contains a vowel
        public static bool HasVowel(string word)
        {
            bool vowel = false;
            for(int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    vowel = true;
                    break;
                }
            }
            return vowel; 
        }
        //finds the position index of the first "y"
        public static int FindY(string word) 
        {
            int i;
            for(i = 0; i < word.Length; i++)
            {
                if(word[i] == 'y')
                {
                    break;
                }
            }
            return i; 
        }
        //this method will find the first vowel and return the index of that vowel with the assumption the string has a vowel
        public static int FindVowel(string word)
        {
            int i; 
            for(i = 0; i < word.Length; i++)
            {
                if(word[i] == 'a'|| word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    break; 
                }
            }
            return i; 
        }
        //method will take a word and the index of the first vowel and will print out the pig latin translation
        public static void PrintInPigLatin(string newWord, int vowelIndex)
        {
            if (vowelIndex == 0)//if the vowel is the first letter then converts it to a StringBuilder to add "way" at the end and prints to console
            {
                StringBuilder newString = new StringBuilder(newWord);
                newString.Append("way");
                Console.WriteLine( newString);
            }
            else//otherwise it will create a substring of the word at the index of the vowel and then add the constant letters to the end along with "ay"
            {
                StringBuilder newString2 = new StringBuilder(newWord.Substring(vowelIndex));//creates a StringBuilder with the substring begining at the vowel location
                for (int i = 0; i < vowelIndex; i++)
                {
                    newString2.Append(newWord[i]);//adds the constant letters from the beginning of the word to the end
                }
                newString2.Append("ay");//adds "ay" to the end of the string
                Console.WriteLine(newString2);//prints out the final word
            }
        }
    }
}
