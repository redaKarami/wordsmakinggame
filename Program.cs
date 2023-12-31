﻿using System;

namespace makeWordsGame
{
    class MakeWordsGame
    {
        static void Main(string[] args)
        {
            string scrambledLetters = "e r s a w";
            Console.WriteLine("Welcome to word gesser, from these letters, try to make as much words as possible, if you guess all words you win");
            Console.WriteLine($"The words : {scrambledLetters}");
            int counter = 0;
            int errorCounter = 0;
            int maxErrors = 3;
            List<string> possibleWords = new() { "sea", "swear", "wear", "ear", "war", "raw", "saw", "was" };
            int possibleWordsCount = possibleWords.Count;
            List<string> guessedWords = new();
            bool onPlay = true;
            while (onPlay == true)
            {
                Console.Write($"make a word from these letters : ({scrambledLetters}) : ");
                string? userLetters = default;
                userLetters = ReadUserEntry();
                userLetters = userLetters.ToLower();
                List<char> userWordList = new();
                foreach (char c in userLetters)
                {
                    if (c == ' ')
                    {
                        continue;
                    }
                    userWordList.Add(c);
                }
                string userWord = String.Join("", userWordList);
                userWord = userWord.ToLower();
                if (guessedWords.Contains(userWord))
                {
                    Console.Clear();
                    Console.WriteLine("You already guessed that word");
                }
                else if (possibleWords.Contains(userWord))
                {
                    Console.Clear();
                    counter++;
                    Console.WriteLine($"Good Job, you guessed {counter} word out of {possibleWordsCount}");
                    possibleWords.Remove(userWord);
                    guessedWords.Add(userWord);
                }
                else if (!possibleWords.Contains(userWord))
                {
                    Console.Clear();
                    errorCounter++;
                    Console.WriteLine($"False, you made {errorCounter} mistakes !, you have {maxErrors - errorCounter} lives left !");
                }
                onPlay = WinOrLossChecker(errorCounter, counter, maxErrors, possibleWordsCount);
            }
        }
        private static bool WinOrLossChecker(int errCnt, int cnt, int mxErr, int strCnt)
        {
            bool setter = true;
            if (errCnt == mxErr)
            {
                Console.Clear();
                Console.WriteLine("You have no lives left, good luck next time :) !");
                setter = false;
            }
            else if (cnt == strCnt)
            {
                Console.WriteLine("Congratulations, you guessed all words !");
                setter = false;
            }
            return setter;
        }
        private static string ReadUserEntry()
        {
            string? str = default;
            do
            {
                str = Console.ReadLine();
                if (str == null || str == string.Empty)
                {
                    Console.WriteLine("You did not enter anything. Try again.");
                }
            } while (str == null || str == string.Empty);
            return str;
        }
    }
}
