using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class HangmanGame
    {
        public string Word;
        public char[] WordIndiv;
        public HashSet<char> WordList = new HashSet<char>();
        public UsedLetters UsedLetters = new UsedLetters();
        public HangmanDrawing HangmanDrawing = new HangmanDrawing();
        public HangmanGame()
        {
            PickGame();
  //          Word = StartingWord();
    //        GuessCheck(Guess());

        }
        static void PickGame()
        {
            Console.WriteLine("Would you like to play Comp guess (1) Person guess (2) or Person vs Person (3)?");
            string input = Console.ReadLine();
            if(int.Parse(input) >= 0 && int.Parse(input) <= 2) {
                switch(int.Parse(input))
                {
                    case 0:
                        ComputerGuess computerGuess = new ComputerGuess();
                        break;

                    case 1:
                        HumanGuess humanGuess = new HumanGuess();
                        break;

                    default:
                        HumanVHuman humanVHuman = new HumanVHuman();
                        break;
                }
            } 
            else
            {
                PickGame();
            }
        }
        protected string StartingWord()
        {
            string word = "";
            Console.WriteLine("To get started, let's input a word:");

            word = Console.ReadLine();

            if (word.Length == 0 || word.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid!");
                startingWord();
            }

            Console.WriteLine("Okay, word is set!");

            return word;
        }
        protected char Guess()
        {
            string guessedLetter = "";
            Console.WriteLine("Input a letter:");

            guessedLetter = Console.ReadLine().ToLower();
            if (IsNotChar(guessedLetter))
            {
                Console.WriteLine("Invalid Input!");
                Guess();
            }

            if (UsedLetters.List.Contains(char.Parse(guessedLetter)))
            {
                Console.WriteLine("Already been guessed, try again!");
                Guess();
            }

            return char.Parse(guessedLetter);
        }
        protected void GuessCheck(char guessedLetter)
        {
            if(WordList.Contains(guessedLetter))
            {
                Console.WriteLine("Got one!");
                UsedLetters.Add(guessedLetter);
                WordList.Remove(guessedLetter);
                for (int i = 0; i < WordIndiv.Length; i++)
                {
                    if(WordIndiv[i] == guessedLetter)
                    {
                        WordIndiv[i] = 'X';
                    }
                }
                if(WordList.Count == 0)
                {
                    EndGame();
                }
                else
                {
                    Console.WriteLine("Let's guess again!");
                    Guess();
                }
            }
            else
            {
                Console.WriteLine("Oops! Not in the word.");
                HangmanDrawing.Count++;
                Console.WriteLine(6 - HangmanDrawing.Count + " more guesses until losing. Here's the drawing:");
                HangmanDrawing.DrawMan();
                Console.WriteLine("Let's guess again!");
                Guess();
            }
        }
        protected void EndGame()
        {
            string answer = "";
            Console.WriteLine("That's all! Play again? (Y/N)");
            answer = Console.ReadLine().ToLower();

            if (IsNotChar(answer))
            {
                Console.WriteLine("Invalid input!");
                EndGame();
            }

            char answerChar = char.Parse(answer);
            if (answerChar == 'y')
            {
                Console.WriteLine("Okay! Let's play again.");
            }
            else
            {
                Console.WriteLine("Thanks for playing.");
            }

        }

        protected bool IsNotChar(string input)
        {
            if (input.Length > 1 || input.Length == 0 || input.Any(char.IsDigit))
                return true;
            else
                return false;
        }
    }
}
