using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class UsedLetters
    {
        public HashSet<char> List = new HashSet<char>();
        public void Add(char letter)
        {
            List.Add(letter);
        }
        public bool Check(char letter)
        {
            if (List.Contains(letter))
                return true;
            return false;
        }
        public void Print()
        {
            foreach (char letter in List)
                Console.Write(letter + "   ");
            Console.WriteLine();
        }
    }
}
