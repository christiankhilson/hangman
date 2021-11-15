using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class ComputerGuess : HangmanGame
    {
        public void WordRemains()
        {
            for (int i = 0; i < WordIndiv.Length; i++)
            {
                Console.Write(WordIndiv[i] + "   ");
            }
        }
        public void GuessCheck(char guessedLetter)
        {
            if (WordList.Contains(guessedLetter))
            {
                Console.WriteLine("Got one!");
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
                else
                {
                    Console.WriteLine("Let's guess again!");
                    Guess();
                }
            }
        }
    }
}
