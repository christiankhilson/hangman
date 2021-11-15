Console.WriteLine("Let's play Hangman!");



static string startingWord ()
{
    string word = "";
    Console.WriteLine("To get started, let's input a word:");

    word = Console.ReadLine();

    if(word.Length == 0 || word.Any(char.IsDigit))
    {
        Console.WriteLine("Invalid!");
        startingWord();
    }
    return word;
}