using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class ComputerGuess : HangmanGame
    {
        public ComputerGuess()
        {
            Word = StartingWord();
            GuessCheck(Guess());
        }
        private char Guess()
        {
            string list = "abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();
            int num = rand.Next(0, list.Length);
            char returnChar = list[num];
            if(UsedLetters.List.Contains(returnChar))
            {
                Guess();
            }
            return returnChar;
        }
        private void GuessCheck(char guessedLetter)
        {
            Console.WriteLine("The Computer guessed " + guessedLetter);
            if (WordList.Contains(guessedLetter))
            {
                Console.WriteLine("The Computer got one!");
                UsedLetters.Add(guessedLetter);
                WordList.Remove(guessedLetter);
                for (int i = 0; i < WordIndiv.Length; i++)
                {
                    if (WordIndiv[i] == guessedLetter)
                    {
                        WordIndiv[i] = 'X';
                    }
                }
                if (WordList.Count == 0)
                {
                    EndGame();
                }
            }
            else
            {
                Console.WriteLine("Not quite!");
                UsedLetters.Add(guessedLetter);
            }
            WordRemains();
            GuessCheck(Guess());
        }
        private void WordRemains()
        {
            Console.WriteLine("Would you like to see the word remains?")
            string answer = Console.ReadLine().ToLower();

            if (IsNotChar(answer))
            {
                Console.WriteLine("Invalid input!");
                WordRemains();
            }

            char answerChar = char.Parse(answer);
            if (answerChar == 'y')
            {
                Console.WriteLine("Okay!");
                for (int i = 0; i < WordIndiv.Length; i++)
                {
                    Console.Write(WordIndiv[i] + "   ");
                }
            }
            else
            {
                Console.WriteLine("Okay!");
            }
        }
    }
}
