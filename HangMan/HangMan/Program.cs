
using System;
using System.Collections.Generic;

namespace hangman3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> HangManWords = new List<string>();
            HangManWords.Add("Computer");
            HangManWords.Add("television");
            HangManWords.Add("apple");
            HangManWords.Add("jumper");
            HangManWords.Add("flask");
            HangManWords.Add("laptop");
            HangManWords.Add("brother");
            HangManWords.Add("sister");
            HangManWords.Add("flowers");
            HangManWords.Add("pictures");
            HangManWords.Add("curtains ");

            bool winGame = false;
            //Select Random word from list of Hangman words using random number slector 
            var RandNum = new Random();
            int SelectWord = RandNum.Next(0, HangManWords.Count);
            string SecretWord = (HangManWords[SelectWord]);
            //Add selected secret word to a List 
            List<string> SecretWordList = new List<string>(SecretWord.Length);
            SecretWordList.Add(SecretWord);
            WelcomDisplay();
            string playGame = Console.ReadLine();
            if (playGame == "x")
            {
                EndGameDisplay();
                Console.ReadKey();
                return;
            }
            else
            {
                for (int guess = 0; guess < SecretWord.Length; guess++)
                {
                    SecretWordList.Add(" - ");
                }
                DisplaySecretWord(SecretWordList);
                while (winGame == false)
                {
                    
                    Console.WriteLine();
                    RequestLetterDisplay();
                    Console.WriteLine();
                    string inputLetter = Console.ReadLine();
                    bool checkLetter = LetterCheck(SecretWord, inputLetter);
                    DisplayResult(checkLetter);
                    char userInput = inputLetter[0];
                    ReplaceCorrectLetter(SecretWord, userInput, SecretWordList, inputLetter);
                    if (SecretWordList.Contains(" - ")==false)
                    {
                        winGame = true;
                    }
                    
                }
                if (winGame == true)
                {
                    Console.WriteLine($"You have won Congratulations");
                }

            }
        }
        /// <summary>
        /// Welecome Display explaining rules of the game
        /// </summary>
        static void WelcomDisplay()
        {
            Console.WriteLine($"Press any key to enter game press [x] to quit");
            Console.WriteLine($"Enter a letter you think is in the secret word");
            Console.WriteLine($"If you guess a correct letter the word will show itself");
            Console.WriteLine($"If your guess is incorrect you lose one of your 10 lives");
            Console.WriteLine($"Try to guess the word before you lose all of your live");
        }
        /// <summary>
        /// Displays End Game Text
        /// </summary>
        static void EndGameDisplay()
        {
            Console.WriteLine($"Game over goodbye :)");
            
        }
        /// <summary>
        /// Requests User to enter letter 
        /// </summary>
        static void RequestLetterDisplay()
        {
            Console.WriteLine($"Please enter a Letter you think is in the secret word");
        }
        /// <summary>
        /// Displays the secret word replaces the Letters with a - to keep the word secret  
        /// </summary>
        /// <param name="hangManWord">sectretWord</param>
        /// <param name="hangManWordList">secretWordList</param>
        static void DisplaySecretWord (List<string> hangManWordList)
        {
            foreach (string letter in hangManWordList)
            {
                Console.Write(letter);
            }
        }
        static bool LetterCheck(string word, string letter)
        {
            if (word.Contains(letter) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Replaces the - when user inputs a correct letter  
        /// </summary>
        /// <param name="word">SecretWord</param>
        /// <param name="userGuess">UserInput</param>
        /// <param name="hangManWordList">SecretWordList</param>
        /// <param name="letter">inputLetter</param>
        /// <returns></returns>
        static void ReplaceCorrectLetter (string word, char userGuess, List<string> hangManWordList, string letters)
        {
            for (int guess = 0; guess < word.Length; guess++)
            {
                if (word[guess].Equals(userGuess)==true)
                {
                    hangManWordList[guess] = letters;
                }
            }
            foreach (string letter in hangManWordList)
            {
                Console.Write($" {letter} ");
            }
        }
        static void DisplayResult(bool checkedLetter)
        {
            if (checkedLetter == true)
            {
                Console.WriteLine($"Correct =) you got a letter");
            }
            else
            {
                Console.WriteLine($"Incorrect =( try again ");
            }
        }
        
    }
}
