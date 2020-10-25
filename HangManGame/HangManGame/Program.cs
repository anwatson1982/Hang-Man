using System;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine(HangManWords[pickWord]);
        }
    }
}
