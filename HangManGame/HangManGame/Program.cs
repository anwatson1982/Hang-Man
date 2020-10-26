using System;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLetter = "";
            int lives;
            ///create list of words to use for hangman game
            List<string> HangManWords = new List<string>();
            HangManWords.Add("computer");
            HangManWords.Add("laptop");
            HangManWords.Add("phone");
            HangManWords.Add("football");
            HangManWords.Add("rugby");
            HangManWords.Add("apple");
            HangManWords.Add("house");
            ///Create Random number to pick from the list of words 
            var randNum = new Random();
            int pickWord = randNum.Next(0, HangManWords.Count);
            string newWord = (HangManWords[pickWord]);
            Console.WriteLine(newWord);
        /// for loop that works out amount of lives users has had, if they guess an incorrect 
        /// letter they will lose a life and get asked to choose another letter 
            for (lives = 5; lives > 0; )
            {
                int wordLength = newWord.Length;
                Console.WriteLine(wordLength);
                Console.WriteLine($"Select a letter");
                inputLetter = Console.ReadLine();
                bool checkLetter = CheckWord(newWord, inputLetter);
                if (checkLetter == true)
                {
                   
                    Console.WriteLine($"You got a letter");
                }
                else
                {
                    Console.WriteLine($"Incorrect letter try again");
                    lives = lives - 1;
                }
            }
            ///Function to work out if the users letter inoutted is part of the word 
            static bool CheckWord(string n, string i)
            {
                if (n.Contains(i))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}