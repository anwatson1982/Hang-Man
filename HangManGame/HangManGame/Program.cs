using System;
using System.Collections.Generic;


namespace sandbox
{
    class Program
    {
        public enum CheckStake
        {
            threeCoins,
            twoCoins,
            oneCoin,
        }
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
            
            string PlayGame = "";
            var RandNum = new Random();
            int SelectWord = RandNum.Next(0, HangManWords.Count);
            string SecretWord = (HangManWords[SelectWord]);
            List<string> LetterList = new List<string>();
            int lives = 10;
            char[] SecretWordArray = SecretWord.ToCharArray();
            string UserInput = "";

            WelcomDisplay();
            DisplayLives(lives);
            PlayGame = Console.ReadLine();
            if (PlayGame == "x")
            {
                EndGameDisplay();
                return;
            }
            else
                while (LetterList.Count < SecretWordArray.Length + 10)
                {
                    Console.Clear();
                    DisplaySecretWord(SecretWordArray);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Please Enter a Letter");
                    
                    UserInput = Console.ReadLine();
                    if (LetterList.Contains(UserInput))
                    {
                        DisplaySecretWord(SecretWordArray);
                        Console.WriteLine();
                        Console.WriteLine($"You have already entered this letter please enter another letter");
                    }
                    LetterList.Add(UserInput);                  
                    bool ValidLetterCheck = LetterValid(SecretWord, UserInput);
                    DisplayResult(ValidLetterCheck);
                    int NewLives = LivesCounter(lives, ValidLetterCheck);
                    lives = NewLives;
                    DisplayLives(lives);
                    if (lives == 0)
                    {
                        EndGameDisplay();
                        return;
                    }
                    Console.ReadKey();
                }        
        }
        static bool LetterValid(string word, string letter)
        {
            if (word.Contains(letter))
            {
                return true;
            }
            else
                return false;
        }
        static void WelcomDisplay()
        {
            Console.WriteLine($"Press any key to enter game press [x] to quit");
            Console.WriteLine($"Enter a letter you think is in the secret word");
            Console.WriteLine($"If you guess a correct letter the word will show itself");
            Console.WriteLine($"If your guess is incorrect you lose one of your 10 lives");
            Console.WriteLine($"Try to guess the word before you lose all of your live");
        }
        static void DisplaySecretWord(char[] WordArray)
        {
           
                foreach (char LetterArray in WordArray)
                {
                    Console.Write($" - ");
                }
            
        }
        static int LivesCounter (int trys, bool ValidLetter)
        {
            if (ValidLetter == false)
            {
                trys--;
                return trys;
            }
            else
                return trys;
        }
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

        static void DisplayLives (int trys)
        {
            Console.WriteLine($"**************************");
            Console.WriteLine($"You have {trys} lives left");
            Console.WriteLine($"**************************");
        }
        static void EndGameDisplay()
        {
            Console.WriteLine($"Game over goodbye :)");
        }

    }
}
      
