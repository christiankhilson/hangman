using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class HangmanDrawing
    {
        public int Count = 0;
        public void DrawMan ()
        {
            switch(Count)
            {
                case 0:
                    Console.WriteLine("The drawing board is currently empty!");
                    break;
                case 1:
                    Console.WriteLine("O");
                    break;
                case 2:
                    Console.WriteLine("O");
                    Console.WriteLine("|");
                    break;
                case 3:
                    Console.WriteLine(" O");
                    Console.WriteLine("-|");
                    break;
                case 4:
                    Console.WriteLine(" O");
                    Console.WriteLine("-|-");
                    break;
                case 5:
                    Console.WriteLine(" O");
                    Console.WriteLine("-|-");
                    Console.WriteLine("/");
                    break;
                case 6:
                    Console.WriteLine(" O");
                    Console.WriteLine("-|-");
                    Console.WriteLine("/ \\");
                    Console.WriteLine("Game Over!");
                    break;
            }
        }
    }
}
