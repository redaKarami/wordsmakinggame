using System;

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
            List<string> possibleWordsCount = new List<string>() { "sea", "swear", "wear", "ear", "war", "raw", "saw", "was" };
            List<string> possibleWords = new List<string>() { "sea", "swear", "wear", "ear", "war", "raw", "saw", "was" };
            List<string> guessedWords = new List<string>();
            bool onPlay = true;
            while (onPlay == true)
            {
                Console.Write($"make a word from these letters : ({scrambledLetters}) : ");
                string? userLetters = Console.ReadLine();
                userLetters = nullOrEmptyChecker(userLetters);
                userLetters = userLetters.ToLower();
                List<char> userWordList = new List<char>();
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
                    Console.WriteLine($"Good Job, you guessed {counter} word out of {possibleWordsCount.Count}");
                    possibleWords.Remove(userWord);
                    guessedWords.Add(userWord);
                }
                else if (!possibleWords.Contains(userWord))
                {
                    Console.Clear();
                    errorCounter++;
                    Console.WriteLine($"False, you made {errorCounter} mistakes !, you have {maxErrors - errorCounter} lives left !");
                }
                onPlay = winOrLossChecker(errorCounter, counter, maxErrors, possibleWordsCount, onPlay);
            }
        }
        private static bool winOrLossChecker(int errCnt, int cnt, int mxErr, List<string> strLst, bool bl)
        {
            if (errCnt == mxErr)
            {
                Console.Clear();
                Console.WriteLine("You have no lives left, good luck next time :) !");
                bl = false;
            }
            else if (cnt == strLst.Count)
            {
                Console.WriteLine("Congratulations, you guessed all words !");
                bl = false;
            }
            return bl;
        }
        private static string nullOrEmptyChecker(string? str)
        {
            while (str == string.Empty || str == null)
            {
                Console.WriteLine("You did not enter anything, try again please");
                str = Console.ReadLine();
            }
            return str;
        }
    }
}