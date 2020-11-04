using System;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
                string inputLetter = Console.ReadLine();
                List <string> LetterList = new List<string>();
                LetterList.Add(inputLetter);
                Console.Write(LetterList);
                foreach (string letters in LetterList)
                {
                    Console.WriteLine(letters);
                }
                
              
                bool checkLetter = CheckWord(newWord, inputLetter);
                
                

                
               
                   
              
            }
           
            
            static bool CheckWord(string Word, string Letter)
            {
                if (Word.Contains(Letter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        static void DisplayResult(bool CheckedLetter, int Attempts)
        {
                if (CheckedLetter == true)
                {
                    Console.WriteLine($"Incorrect letter try again");
                    Attempts = Attempts - 1;
                }
                else
                {
                    Console.WriteLine($"You got a letter");
                }
            }
        }
    }
