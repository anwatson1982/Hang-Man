
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
namespace HangMan2
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of words one will randomly be selected as the secret word the user has to guess 
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
            int Lives = 10;
            string PlayGame = "";
            //Selects random word from list above 
            var RandNum = new Random();
            int SelectWord = RandNum.Next(0, HangManWords.Count);
            string SecretWord = (HangManWords[SelectWord]);
            //Turns secret word into Character Array 
            char[] SecretWordArray = SecretWord.ToCharArray();
            WelcomDisplay();
            PlayGame = Console.ReadLine();
            if (PlayGame == "x")
            {
                EndGameDisplay();
                return;
            }
            else
            {
                Console.Clear();

                //Main for loop whilst users lives are above 0 it will continue running through the loop
                for (Lives = 10; Lives > 0;)
                {
                    DisplaySecretWord(SecretWordArray);
                    Console.WriteLine();
                    RequestLetterDisplay();
                    string InputLetter = Console.ReadLine();
                    List<string> LetterList = new List<string>();
                    LetterList.Add(InputLetter);
                    bool WordCheck = CheckWord(SecretWord, InputLetter);
                    int NewLifeCount = LivesCounter(Lives, WordCheck);
                    DisplayLives(NewLifeCount);
                    Lives = NewLifeCount;
                    DisplayResult(WordCheck);
                    if (Lives == 0)
                    {
                        Console.Clear();
                        EndGameDisplay();
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Welcome Screen Display
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
        /// GameOver Display
        /// </summary>
        static void EndGameDisplay()
        {
            Console.WriteLine($"You ran out of guesses. Game over goodbye :)");
        }
        /// <summary>
        /// Request Letter Display
        /// </summary>
        static void RequestLetterDisplay()
        {
            Console.WriteLine($"Please enter a Letter you think is in the secret word");
        }
        /// <summary>
        /// Displays secret Word
        /// </summary>
        /// <param name="WordArray">SecretWordArray</param>
        static void DisplaySecretWord(char[] WordArray)
        {
            foreach (char LetterArray in WordArray)
            {
                Console.Write($" - ");
            }
        }
        /// <summary>
        /// Checks if user inout letter is in the secret word 
        /// </summary>
        /// <param name="Word">SecretWord</param>
        /// <param name="Letter">InputLetter</param>
        /// <returns>True if Letter is in the secret word, False if not </returns>
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
        /// <summary>
        /// Displays the result if user input letter was correct 
        /// </summary>
        /// <param name="WordChecked">CheckWord function</param>
        static void DisplayResult(bool WordChecked)
        {
            if (WordChecked == true)
            {
                Console.WriteLine($"You got a letter");
            }
            else
            {
                Console.WriteLine($"The letter you picked is not in the sectret word please try again");
            }
        }
        /// <summary>
        /// Works out Lives user has left, if user guesses a correct letter lives stay the same if incorrect
        /// lives go down by 1
        /// </summary>
        /// <param name="trys">Lives</param>
        /// <param name="WordCheked">CheckWord</param>
        /// <returns></returns>
        static int LivesCounter(int trys, bool WordChecked)
        {
            if (WordChecked == false)
            {
                trys--;
                return trys;
            }
            else
                return trys;
        }
        /// <summary>
        /// Displays ammount of lives user has left 
        /// </summary>
        /// <param name="trys">Lives</param>
        static void DisplayLives(int trys)
        {
            Console.WriteLine($"You have {trys} lives left");
        }
    }
}